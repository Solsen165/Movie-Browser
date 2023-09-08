using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserUI
{
    public partial class HelpForm : Form
    {
        List<Image> images = new List<Image>();
        int index = 0;
        public HelpForm()
        {
            InitializeComponent();
            images.Add(Properties.Resources.main_page);
            images.Add(Properties.Resources.movie_info);
            images.Add(Properties.Resources.show_info);
            images.Add(Properties.Resources.multiselect);
            images.Add(Properties.Resources.reidentification);
            index = 0;
            LoadImage();
        }
        private void LoadImage()
        {
            helpPictureBox.Image = images[index];
            if (index == 0)
            {
                previousButton.Enabled = false;
            }
            else
            {
                previousButton.Enabled = true;
            }

            if (index == 4)
            {
                nextButton.Enabled = false;
            }
            else
            {
                nextButton.Enabled = true;
            }
            if (index == 0)
            {
                pictureLabel.Text = "Main Page";
            }
            if (index == 1)
            {
                pictureLabel.Text = "Movie Panel";
            }
            if (index == 2)
            {
                pictureLabel.Text = "TV Show Panel After Arranging Files Into Season Format";
            }
            if (index == 3)
            {
                pictureLabel.Text = "You can multi-select shows to save time";
            }
            if (index == 4)
            {
                pictureLabel.Text = "Reidentifying the show or movie";
            }

            numberLabel.Text = $"{index + 1} / {images.Count}";
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            index -= 1;
            LoadImage();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            index += 1;
            LoadImage();
        }
    }
}
