﻿using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private string imgPath;
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
                formTextReponseDisplay.ShowText(text);
                formTextReponseDisplay.HideProgressBar();
            });
        }

        private void Client_OnConnectionFailed()
        {
            Invoke((MethodInvoker)delegate {
                ShowConfirmDialog("Error", 
                    "Failed to connect to server. Would you like to reconnect", 
                    () => { }, 
                    () => { formTextReponseDisplay.Hide(); });
                btnSelectImg.Enabled = false;
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
            imgPath = Util.SelectImg();
            if (!string.IsNullOrEmpty(imgPath))
            {
                DisplayImg();
                btnConvert.Enabled = true;
            }
        }

        private void DisplayImg()
        {
            Image img = null;
            using (var fileStream = File.OpenRead(imgPath))
            {
                img = Image.FromStream(fileStream);
            }
            pictureBox.Image = img;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            Task.Run(() => client.RequestImgToText(imgPath));
            formTextReponseDisplay.ShowDialog();
        }
    }
}
