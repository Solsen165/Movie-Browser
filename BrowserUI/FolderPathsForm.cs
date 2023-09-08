using BrowserLibrary.DataAccess;
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
    public partial class FolderPathsForm : Form
    {
        BindingList<string> folderPaths = new BindingList<string>();
        MainForm caller;
        bool isEdited = false;
        public FolderPathsForm(List<string> paths, MainForm caller)
        {
            InitializeComponent();
            removeButton.Enabled = false;
            folderPaths = new BindingList<string>(paths);
            WireUpList();
            this.caller = caller;
        }

        private void WireUpList()
        {
            //pathListBox.DataSource = null;
            pathListBox.DataSource = folderPaths;
        }

        private void pathListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pathListBox.SelectedItems.Count > 0)
            {
                removeButton.Enabled = true;
            }
            else
            {
                removeButton.Enabled = false;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string filePath = "";
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.InitialDirectory = "C:\\";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = folderBrowserDialog.SelectedPath;
                    SqlConnector.CreateFolderPath(filePath);
                    folderPaths.Add(filePath);
                    WireUpList();
                    isEdited = true;
                    removeButton.Enabled = true;
                }
                else
                {
                    return;
                }
            }

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            string path = (string)pathListBox.SelectedItem;
            SqlConnector.DeleteFolderPath(path);
            folderPaths.Remove(path);
            WireUpList();
            isEdited = true;
        }

        private void FolderPathsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isEdited)
            {
                caller.FinishEditingPaths(folderPaths.ToList());
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
