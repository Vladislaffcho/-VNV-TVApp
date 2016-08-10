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
    public partial class ucAddAddress : UserControl
    {
        private string _comment;
        private string _address;
        private string _type;

        public ucAddAddress()
        {
            InitializeComponent();
            SetControlView();
        }

        private void SetControlView()
        {
            using (var context = new TvDBContext())
            {
                var types = from t in context.TypeConnects
                            select t;
                types.ToList();

                foreach (var typeConnect in types)
                {
                    cbAddressType.Items.Add(typeConnect.NameType);
                }
            }
            cbAddressType.SelectedIndex = 0;
        }


        public bool ValidateControls()
        {
            if (tbUserAddress.Text.Trim() == String.Empty)
            {
                return false;
            }
            _address = tbUserAddress.Text;
            _comment = tbComment.Text;
            _type = cbAddressType.SelectedItem.ToString();
            return true;
        }

        public void SaveAddedDetails(int UserID)
        {
            
            using (var context = new TvDBContext())
            {
                UserAddress address = new UserAddress
                {
                    Address = _address,
                    Comment = _comment,
                    TypeConnect = context.TypeConnects.First(x => x.NameType == _type),
                    User = context.Users.First(l => l.Id == UserID)
                };
                context.UserAddresses.Add(address);
                context.SaveChanges();
            }
        }
    }
}
