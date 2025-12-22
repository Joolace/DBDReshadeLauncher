using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;


namespace DBDReshadeLauncher
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            labelTitle.Left = (this.ClientSize.Width - labelTitle.Width) / 2;
            pictureBoxLogo.Left = (this.ClientSize.Width - pictureBoxLogo.Width) / 2;
            string imagePath = Path.Combine(Application.StartupPath, "Resources", "dbdreshade_logo.png");
            pictureBoxLogo.Image = Image.FromFile(imagePath);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            try
            {
                string iconPath = Path.Combine(Application.StartupPath, "Resources", "favicon.ico");
                if (File.Exists(iconPath))
                {
                    this.Icon = new System.Drawing.Icon(iconPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading icon: " + ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void labelVersion_Click(object sender, EventArgs e)
        {
            
        }

        private async void buttonRunScript_Click(object sender, EventArgs e)
        {
            try
            {
                string scriptFolder = Path.Combine(Application.StartupPath, "ScriptFolder");
                string scriptPath = Path.Combine(scriptFolder, "dbdreshade.ps1");

                if (!File.Exists(scriptPath))
                {
                    MessageBox.Show($"Script not found:\n{scriptPath}", "File Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                buttonRunScript.Enabled = false;

                await Task.Run(() =>
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments =
                            $"-NoProfile -ExecutionPolicy Bypass -File \"{scriptPath}\"",
                        WorkingDirectory = scriptFolder,

                        UseShellExecute = true
                    };

                    Process.Start(psi);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during script execution: " + ex.Message);
            }
            finally
            {
                buttonRunScript.Enabled = true;
            }
        }

        private void D3DaylightButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Full path to D3Daylight.exe inside the "D3Daylight" subfolder
                string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "D3Daylight", "D3Daylight.exe");

                if (File.Exists(exePath))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = exePath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("D3Daylight.exe was not found in the 'D3Daylight' folder.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to launch D3Daylight.exe:\n" + ex.Message, "Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void labelDisclaimer_Click(object sender, EventArgs e)
        {

        }
    }
}
