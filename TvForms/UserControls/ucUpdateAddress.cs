using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcUpdateAddress : UserControl
    {
        private int _addressID;
        UserAddress _address = new UserAddress();
        public UcUpdateAddress()
        {
            InitializeComponent();
        }

        public void UpdateAddress(int addressID)
        {
            _addressID = addressID;
            SetControlView();
        }
        
        private void SetControlView()
        {
            int i = 0;
            using (var context = new TvDBContext())
            {
                var types = from t in context.TypeConnects
                            select t;
                types.ToList();

                _address = context.UserAddresses.First(c => c.Id == _addressID);
                tbUserAddress.Text = _address.Address;
                tbComment.Text = _address.Comment;
                foreach (var typeConnect in types)
                {
                    cbAddressType.Items.Add(typeConnect.NameType);
                    if (typeConnect.NameType == _address.TypeConnect.NameType)
                    {
                        cbAddressType.SelectedIndex = i;
                    }
                    i++;
                }
            }
        }

        public bool ValidateControls()
        {
            if (tbUserAddress.Text.Trim() == String.Empty)
            {
                return false;
            }
            return true;
        }

        public void SaveAddedDetails()
        {
            using (var context = new TvDBContext())
            {
                var userAddressRepo = new BaseRepository<UserAddress>(context);
                var typeConnectRepo = new BaseRepository<TypeConnect>(context);
                var addressToUpdate = userAddressRepo.Get(x => x.Id == _addressID)
                    .Include(x => x.TypeConnect)
                    .Include(x => x.User).First();
                addressToUpdate.Address = tbUserAddress.Text;
                addressToUpdate.Comment = tbComment.Text;
                addressToUpdate.TypeConnect = typeConnectRepo.Get(l => l.NameType == cbAddressType.SelectedItem.ToString()).First();
                userAddressRepo.Update(addressToUpdate);
            }
        }
    }
}
