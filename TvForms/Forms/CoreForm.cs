using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Xml.Linq;
using TVContext;
using System.Xml.Serialization;

namespace TvForms
{
    public partial class CoreForm : Form
    {
        //ToDo Review need to store all user data
        private User CurrentUser { get; set; }

        //ToDo Review WTF? Naming convention!!!
        private UcTabsForUser UserWindow { get; set; }
        private ucAdminView AdminWindow { get; set; }

        
        //public CoreForm(User whoUser)
        //{
        
        //    InitializeComponent();
        //    CurrentUser = whoUser;

        //    switch (CurrentUser.UserType.Id)
        //    {
        //        case EUserType.ADMIN: //admin
        //            panelCore.Controls.Add(new ucAdminView(CurrentUser));
        //            break;
        //        case EUserType.CLIENT: //user
        //            panelCore.Controls.Add(new TabsForUser());
        //            break;
        //    }
            
        //}

        public CoreForm()
        {

            InitializeComponent();
            ShowLoginForm();

            switch (CurrentUser.UserType.Id)
            {
                case EUserType.ADMIN: //admin
                    panelCore.Controls.Add(new ucAdminView(CurrentUser));
                    break;
                case EUserType.CLIENT: //user
                    panelCore.Controls.Add(new UcTabsForUser());
                    break;
            }

        }

        private void ShowLoginForm()
        {
            PassFormCopy lg = new PassFormCopy();
            if (lg.ShowDialog() == DialogResult.OK)
            {
                CurrentUser = lg.CurrentUser;
            }
            else
            {
                Close();
            }
        }


        private void bCancelCore_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSaveCore_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void openXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ToDo Naming convention!
            OpenFileDialog OpenXml = new OpenFileDialog();

            //String savePath = @"c:\temp\uploads\";

            OpenXml.DefaultExt = "*.xml";
            OpenXml.Filter = "XML Files|*.xml";

            if (OpenXml.ShowDialog() == DialogResult.OK &&
               OpenXml.FileName.Length > 0)
            {
                //
                //Parse needs correct
                //
                XmlFileHelper.ParseChannel(OpenXml.FileName);
                //UserWindow.TabInfo.ParseChannel(OpenXml.FileName);
            }
        }

      
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            
        

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        
        //Uncomment when bookmarks will be ready end specify appropriate one!!!!
        //private void tVShowsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ActionForm action = new ActionForm(new ucTvShow());
        //    action.Show();
        //    this.Enabled = false;

        }
    }
}
