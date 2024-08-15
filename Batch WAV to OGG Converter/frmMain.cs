using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Batch_WAV_to_OGG_Converter
{
	public partial class frmMain : Form
	{
		private List<string> filenames;
		private int currentFile;
		private bool isManualOverride = false;
		private bool isCanceled = false;
		private bool isProtected = false;
		private Process process;

		public frmMain()
		{
			InitializeComponent();
		}

		private void btnChooseSource_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					txtSource.Text = fbd.SelectedPath;
				}
			}
		}

		private void btnChooseTarget_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					txtTarget.Text = fbd.SelectedPath;
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (process != null && !process.HasExited)
			{
				process.Kill();
			}

			isCanceled = true;
			lblStatus.Text = "Stopped";
			convertProgress.Value = 0;

			if (btnCancel.Text == "Reset")
			{
				ResetUI();
			}
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			isCanceled = false;
			currentFile = 0;
			ToggleUIForConversion(false);

			filenames = boolRecursive.Checked
				? Directory.GetFiles(txtSource.Text, "*.wav", SearchOption.AllDirectories).ToList()
				: Directory.GetFiles(txtSource.Text, "*.wav", SearchOption.TopDirectoryOnly).ToList();

			ConvertFile();
		}

		private void ConvertFile()
		{
			if (isCanceled || currentFile >= filenames.Count)
			{
				FinalizeConversion();
				return;
			}

			string sourceFilePath = filenames[currentFile];
			string relativePath = GetRelativePath(txtSource.Text, sourceFilePath);
			string truncatedRelativePath = TrimRelativePath(relativePath);

			string targetFilePath = Path.Combine(txtTarget.Text, truncatedRelativePath);
			string outputFilePath = PrepareTargetDirectory(targetFilePath);

			lblStatus.Text = $"Processing {truncatedRelativePath}...";

			if (File.Exists(outputFilePath) && !boolOverride.Checked)
			{
				currentFile++;
				ConvertFile();
				return;
			}

			StartConversionProcess(sourceFilePath, outputFilePath);
		}

		private void StartConversionProcess(string sourceFilePath, string outputFilePath)
		{
			process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), @"ffmpeg\ffmpeg.exe"),
					Arguments = $"-i \"{sourceFilePath}\" -acodec libvorbis -f ogg \"{outputFilePath}\"",
					UseShellExecute = false,
					CreateNoWindow = true
				}
			};

			process.Start();

			while (!process.HasExited)
			{
				if (isCanceled)
				{
					process.Kill();
					DeleteFileIfExists(outputFilePath);

					lblStatus.Text = "Canceled";
					FinalizeConversion();
					return;
				}

				System.Threading.Thread.Sleep(10);
				Application.DoEvents();
			}

			currentFile++;
			convertProgress.Value = (int)((double)currentFile / filenames.Count * 100.0);
			ConvertFile();
		}

		private void FinalizeConversion()
		{
			convertProgress.Value = 100;
			lblStatus.Text = "Conversion Complete";

			if (boolDelete.Checked)
			{
				lblStatus.Text = "Deleting old WAV files...";
				filenames.ForEach(file => RetryDeleteFile(GetRelativePath(txtSource.Text, file)));
			}

			isProtected = false;
			btnCancel.Text = "Reset";
			btnCancel.Show();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			lblStatus.Text = "Idle";
			btnCancel.Hide();

			txtSource.TextChanged += txtSource_TextChanged;
			txtTarget.TextChanged += txtTarget_TextChanged;

			btnCancel.Click += btnCancel_Click;
		}

		private void txtSource_TextChanged(object sender, EventArgs e) => ValidateSourcePath();

		private void txtTarget_TextChanged(object sender, EventArgs e) => ValidateTargetPath();

		private void ValidateSourcePath()
		{
			if (string.IsNullOrWhiteSpace(txtSource.Text) || !Directory.Exists(txtSource.Text))
			{
				group_step4.Hide();
				return;
			}

			CheckIfStep4ShouldBeShown();
		}

		private void ValidateTargetPath()
		{
			if (string.IsNullOrWhiteSpace(txtTarget.Text) || !Directory.Exists(txtTarget.Text))
			{
				group_step4.Hide();
				return;
			}

			CheckIfStep4ShouldBeShown();
		}

		private void txtSource_Validating(object sender, CancelEventArgs e)
		{
			if (this.ActiveControl == btnChooseSource)
			{
				btnChooseSource_Click(btnChooseSource, EventArgs.Empty);
				return;
			}

			ValidatePath(e, txtSource, "The source directory does not exist. Please enter a valid directory.");
		}

		private void txtTarget_Validating(object sender, CancelEventArgs e)
		{
			if (this.ActiveControl == btnChooseTarget)
			{
				btnChooseTarget_Click(btnChooseTarget, EventArgs.Empty);
				return;
			}

			ValidatePath(e, txtTarget, "The target directory does not exist. Please enter a valid directory.");
		}

		private void CheckIfStep4ShouldBeShown()
		{
			if (Directory.Exists(txtSource.Text) && Directory.Exists(txtTarget.Text))
			{
				if (string.Equals(txtSource.Text.Trim(), txtTarget.Text.Trim(), StringComparison.OrdinalIgnoreCase))
				{
					MessageBox.Show("Source and Target folders cannot be the same. Please select a different target folder.", "Invalid Folders", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					group_step4.Hide();
				}
				else
				{
					group_step4.Show();
				}
			}
			else
			{
				group_step4.Hide();
			}
		}

		private string GetRelativePath(string fromPath, string toPath)
		{
			Uri fromUri = new Uri(fromPath);
			Uri toUri = new Uri(toPath);

			if (fromUri.Scheme != toUri.Scheme) { return toPath; }

			Uri relativeUri = fromUri.MakeRelativeUri(toUri);
			string relativePath = Uri.UnescapeDataString(relativeUri.ToString());

			return toUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase)
				? relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar)
				: relativePath;
		}

		private string TrimRelativePath(string relativePath)
		{
			if (relativePath.StartsWith(Path.GetFileName(txtSource.Text) + Path.DirectorySeparatorChar))
			{
				return relativePath.Substring(Path.GetFileName(txtSource.Text).Length + 1);
			}

			return relativePath;
		}

		private string PrepareTargetDirectory(string targetFilePath)
		{
			string targetDirectory = Path.GetDirectoryName(targetFilePath);

			if (!Directory.Exists(targetDirectory))
			{
				Directory.CreateDirectory(targetDirectory);
			}

			return Path.ChangeExtension(targetFilePath, ".ogg");
		}

		private bool RetryDeleteFile(string relativeFilePath)
		{
			int retryCount = 0;
			const int maxRetry = 10;
			string filePath = Path.Combine(txtSource.Text, relativeFilePath);

			while (retryCount < maxRetry)
			{
				if (TryDeleteFile(filePath)) return true;

				retryCount++;
				System.Threading.Thread.Sleep(retryCount * 2000);
			}

			isProtected = true;
			return false;
		}

		private bool TryDeleteFile(string filePath)
		{
			try
			{
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
					return true;
				}
			}
			catch (IOException) { }

			return false;
		}

		private void DeleteFileIfExists(string outputFilePath)
		{
			if (File.Exists(outputFilePath))
			{
				File.Delete(outputFilePath);
			}
		}

		private void ValidatePath(CancelEventArgs e, TextBox textBox, string errorMessage)
		{
			if (string.IsNullOrWhiteSpace(textBox.Text) || !Directory.Exists(textBox.Text))
			{
				MessageBox.Show(errorMessage);
				e.Cancel = true;
				textBox.Focus();
			}
		}

		private void ToggleUIForConversion(bool enable)
		{
			btnChooseSource.Enabled = enable;
			btnChooseTarget.Enabled = enable;
			boolDelete.Enabled = enable;
			boolRecursive.Enabled = enable;
			boolOverride.Enabled = enable;
			txtSource.ReadOnly = !enable;
			txtTarget.ReadOnly = !enable;
			btnConvert.Visible = enable;
			btnCancel.Visible = !enable;
			convertProgress.Visible = !enable;
		}

		private void ResetUI()
		{
			btnCancel.Hide();
			btnConvert.Show();
			convertProgress.Hide();
			ToggleUIForConversion(true);
			lblStatus.Text = "Idle";
		}

		// Empty functions required for assembly
		private void groupBox1_Enter(object sender, EventArgs e) { }
		private void label5_Click(object sender, EventArgs e) { }
		private void label1_Click(object sender, EventArgs e) { }
		private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
		private void button1_Click(object sender, EventArgs e) { }
		private void label5_Click_1(object sender, EventArgs e) { }
		private void checkBox2_CheckedChanged(object sender, EventArgs e) { }
	}
}
