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

namespace Client
{
    public partial class FormClient : MaterialSkin.Controls.MaterialForm
    {
        private string ImgPath;

        public FormClient()
        {
            InitializeComponent();

            ChangeSkin();

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void ChangeSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {
            ImgPath = Util.SelectImg();
            if (!string.IsNullOrEmpty(ImgPath))
            {
                DisplayImg();
            }
        }

        private void DisplayImg()
        {
            pictureBox.Image = Image.FromFile(ImgPath);
        }
    }
}
