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

namespace ImgToTextClientApp
{
    public partial class FormTextReponseDisplay : MaterialSkin.Controls.MaterialForm
    {

        public FormTextReponseDisplay()
        {
            InitializeComponent();
            UnitUI();
        }

        private void UnitUI()
        {
            ChangeSkin();
        }

        private void ChangeSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        internal void ShowText(string text)
        {
            richTextBox.Visible = true;
            richTextBox.Text = text;
        }

        internal void HideProgressBar()
        {
            progressBar.Hide();
        }

    }
}
