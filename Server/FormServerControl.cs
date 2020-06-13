using Share;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgToTextServerApp
{
    public partial class FormServerControl : MaterialSkin.Controls.MaterialForm
    {
        private Server server;
       
        public FormServerControl()
        {
            server = new Server();
            InitializeComponent();
            ChangeSkin();
            btnStartStop_Click(null, null);
        }

        private void ChangeSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (server.Running == false)
            {
                btnStartStop.Text = "Stop";
                server.Start();
            } else
            {
                btnStartStop.Text = "Start";
                server.Stop();
            }
        }
    }
}
