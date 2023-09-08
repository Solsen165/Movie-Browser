using BrowserLibrary;
using BrowserLibrary.DataAccess;
using BrowserLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserUI
{
    public partial class EditForm : Form
    {
        MainForm caller;
        ShowModel show;
        bool changedImage = false;
        public EditForm(ShowModel show, MainForm caller)
        {
            InitializeComponent();
            this.caller = caller;
            this.show = show;
            WireUpInfo();
        }

        private void WireUpInfo()
        {
            //if (show.Type == "TvShow" && show.Seasons.Count > 0)
            //{
            //    rearrangeButton.Visible = true;
            //}
            //else
            //{
            //    rearrangeButton.Visible = false;
            //}
            pictureBox.Image = ShowLoader.LoadPoster(show);
            if (pictureBox.Image == null)
            {
                pictureBox.Image = Properties.Resources._default;
            }
            titleValue.Text = show.Title;
            descriptionValue.Text = show.Description;
        }

        private void correctButton_Click(object sender, EventArgs e)
        {
            WrongShowForm frm = new WrongShowForm(show, caller);
            frm.ShowDialog();
            this.Close();
        }
        //private void rearrangeButton_Click(object sender, EventArgs e)
        //{
        //    RearrangeEpisodesForm frm = new RearrangeEpisodesForm(show, caller);
        //    frm.ShowDialog();
        //    this.Close();
        //}

        private void changePhotoButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                open.InitialDirectory = "C:\\";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string filePath = open.FileName;
                    pictureBox.Image = Image.FromFile(filePath);
                    changedImage = true;
                }
                else
                {
                    return;
                }
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (show.Title != titleValue.Text || show.Description != descriptionValue.Text)
            {
                show.Title = titleValue.Text;
                show.Description = descriptionValue.Text;
                SqlConnector.UpdateShow(show);
            }

            if (changedImage)
            {
                Image poster = pictureBox.Image;
                poster.Save($"./Database/Posters/{show.Id}.jpg");
            }
            caller.EditFinish();
            this.Close();
        }

    }
}
