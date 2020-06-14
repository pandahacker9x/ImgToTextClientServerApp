using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgToTextClientApp
{
    public partial class FormImageInput : MaterialSkin.Controls.MaterialForm
    {
        private string selectedImgPath, imgPathToGetText;
        private Client client;
        private FormTextReponseDisplay formTextReponseDisplay;

        public FormImageInput()
        {
            InitializeComponent();
            InitUI();
            InitClient();
        }

        private void InitUI()
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ChangeSkin();
            formTextReponseDisplay = new FormTextReponseDisplay();
        }

        private void ChangeSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void InitClient()
        {
            client = new Client();
            client.OnConnectionFailed += Client_OnConnectionFailed;
            client.OnImageToTextResponse += Client_OnImageToTextResponse;        
        }

        private void Client_OnImageToTextResponse(string text)
        {
            Invoke((MethodInvoker)delegate {
                formTextReponseDisplay.SetText(text);
                formTextReponseDisplay.SetWaiting(false);
            });
        }

        private void Client_OnConnectionFailed()
        {
            Invoke((MethodInvoker)delegate {
                ShowConfirmDialog("Error", 
                    "Failed to connect to server. Would you like to reconnect", 
                    () => {
                        // Request again
                        imgPathToGetText = "";
                        btnGetText_Click(null, null); 
                    }, 
                    () => { formTextReponseDisplay.Hide(); });
            });
        }

        delegate void ComfirmAction();
        private void ShowConfirmDialog(string title, string msg, 
            ComfirmAction onYes, ComfirmAction onNo)
        {
            var result = MessageBox
                .Show(msg, title, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                onYes.Invoke();
            else onNo.Invoke();
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {
            selectedImgPath = Utils.SelectImg();
            
            if (!string.IsNullOrEmpty(selectedImgPath))
            {
                DisplayImg();
                btnGetText.Enabled = true;
            }
        }

        private void DisplayImg()
        {
            Image img = null;
            using (var fileStream = File.OpenRead(selectedImgPath))
            {
                img = Image.FromStream(fileStream);
            }
            pictureBox.Image = img;
        }

        private void btnGetText_Click(object sender, EventArgs e)
        {
            if (IsNewImgToTextRequest())
            {
                formTextReponseDisplay.SetWaiting(true);
                Task.Run(() => client.RequestImgToText(selectedImgPath));
                imgPathToGetText = selectedImgPath;
            }
            else
            {
                if (!formTextReponseDisplay.IsWaiting)
                    formTextReponseDisplay.SetWaiting(false);
            }
            formTextReponseDisplay.ShowDialog();
        }

        private bool IsNewImgToTextRequest()
        {
            return selectedImgPath != imgPathToGetText;
        }
    }
}
