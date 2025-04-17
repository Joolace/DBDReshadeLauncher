using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace DBDReshadeLauncher
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            labelTitle.Left = (this.ClientSize.Width - labelTitle.Width) / 2;
            pictureBoxLogo.Left = (this.ClientSize.Width - pictureBoxLogo.Width) / 2;
            buttonRunScript.Left = (this.ClientSize.Width - buttonRunScript.Width) / 2;
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

        private void buttonRunScript_Click(object sender, EventArgs e)
        {
            try
            {
                string scriptFolder = Path.Combine(Application.StartupPath, "ScriptFolder");

                string scriptPath = Path.Combine(scriptFolder, "dbdreshade.ps1");

                string script = $@"
                    Set-Location -Path '{scriptFolder}'
                    .\dbdreshade.ps1
                ";

                string result = PowerShellHelper.EseguiScript(script);
                MessageBox.Show(result, "Result Script", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during script execution: " + ex.Message);
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
