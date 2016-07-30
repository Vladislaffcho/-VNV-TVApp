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
            InitializeComponent();
            initForAdmin();

        }

        private void initForAdmin()
        {
            using (var context = new TvDBContext())
            {
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
