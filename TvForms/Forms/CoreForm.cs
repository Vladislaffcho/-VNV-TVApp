using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Schema;
using TVContext;

namespace TvForms
{
    public partial class CoreForm : Form
    {
        //ToDo Review need to store all user data
        private int CurrentUserId { get; set; }

        //ToDo Review WTF? Naming convention!!!
        private UcTabsForUser UserWindow { get; set; }

        private UcAdminView AdminWindow { get; set; }

        public CoreForm()
        {

            InitializeComponent();
            ShowLoginForm();
            LoadMainControl();

            //if (CurrentUserId != 0)
            //{
            //    var user = new BaseRepository<User>();
            //    var userType = user.Get(x => x.Id == CurrentUserId).FirstOrDefault().UserType.Id;

            //    switch (userType)
            //    {
            //        case (int)EUserType.ADMIN: //admin
            //            panelCore.Controls.Add(new UcAdminView(CurrentUserId));
            //            break;
            //        case (int)EUserType.CLIENT: //user
            //            panelCore.Controls.Add(new UcTabsForUser());
            //            break;
            //    }
            //}
        }

        private void LoadMainControl()
        {
            if (CurrentUserId != 0)
            {
                var user = new BaseRepository<User>();
                var userType = user.Get(x => x.Id == CurrentUserId).FirstOrDefault().UserType.Id;

                switch (userType)
                {
                    case (int) EUserType.ADMIN: //admin
                        panelCore.Controls.Add(new UcAdminView(CurrentUserId));
                        break;
                    case (int) EUserType.CLIENT: //user
                        panelCore.Controls.Add(new UcTabsForUser());
                        break;
                }
            }
        }
        
        private void ShowLoginForm()
        {
            PassForm lg = new PassForm();
            if (lg.ShowDialog() == DialogResult.OK)
            {
                CurrentUserId = lg.CurrentUserId;
            }
            else
            {
                Close();
            }
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void openXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ToDo Naming convention!
            var openXmlFile = new OpenFileDialog
            {
                DefaultExt = "*.xml",
                Filter = "XML Files|*.xml"
            };
            
            if (openXmlFile.ShowDialog() != DialogResult.OK || openXmlFile.FileName.Length <= 0) return;
         
            XmlFileHelper.ParseChannel(openXmlFile.FileName);
            XmlFileHelper.ParseProgramm(openXmlFile.FileName);
        }

      
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uncomment when bookmarks will be ready end specify appropriate one!!!!
            var actions = new ActionForm(CurrentUserId);
            actions.Show();
        }
    }
}
