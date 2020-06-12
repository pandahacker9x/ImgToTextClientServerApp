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
    public partial class FormClient : MaterialSkin.Controls.MaterialForm
    {
        private string imgPath;
        private Client client;

        public FormClient()
        {
            InitializeComponent();
            InitUI();
            InitClient();
        }

        private void InitUI()
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ChangeSkin();
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
        }

        private void Client_OnConnectionFailed()
        {
            ShowMsg("Failed to connect to server");
            btnSelectImg.Enabled = false;
        }

        private void ShowMsg(string msg)
        {
            MessageBox.Show(msg);
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
            client.SendImg(imgPath);
        }
    }
}
