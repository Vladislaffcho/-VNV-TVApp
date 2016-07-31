using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class ucAdminView : UserControl
    {
        public ucAdminView()
        {
            using (var context = new TvDBContext())
            {
                var defaultEmail = new List<UserEmail> {
                    new UserEmail {
                        EmailName = "root@root.com",
                        Comment = "Admin's email",
                        TypeConnect = context.TypeConnects.First(x => x.Id == 1),
                        User = context.Users.First(l => l.Id == 1)
                    },
                    new UserEmail {
                        EmailName = "user@user.com",
                        Comment = "User's email",
                        TypeConnect = context.TypeConnects.First(x => x.Id == 2),
                        User = context.Users.First(l => l.Id == 2)
                    }
                };

                foreach (var item in defaultEmail)
                {
                    context.UserEmails.Add(item);
                }

                context.SaveChanges();
            }
            

            InitializeComponent();
            initForAdmin();

        }

        private void initForAdmin()
        {
            using (var context = new TvDBContext())
            {
                // Filling the user list List View
                var usr = from u in context.Users
                          select u;

                usr.ToList();

                foreach (var i in usr)
                {
                    var lvItem = new ListViewItem(i.Id.ToString());
                    lvItem.SubItems.Add(i.Login);
                    lvItem.SubItems.Add(i.FirstName + " " + i.LastName);
                    lvUserList.Items.Add(lvItem);
                }
            }
        }

        private void gbUsers_Enter(object sender, EventArgs e)
        {

        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
