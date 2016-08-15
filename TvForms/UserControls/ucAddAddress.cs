using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcAddAddress : UserControl
    {
        public UcAddAddress()
        {
            InitializeComponent();
            SetControlView();
        }

        private void SetControlView()
        {
            var typeConnectRepo = new BaseRepository<TypeConnect>();
            var types = typeConnectRepo.GetAll();

            foreach (var typeConnect in types)
            {
                cbAddressType.Items.Add(typeConnect.NameType);
            }
            cbAddressType.SelectedIndex = 0;
        }


        public bool ValidateControls()
        {
            if (tbUserAddress.Text.Trim() == String.Empty)
            {
                return false;
            }
            return true;
        }

        public void SaveAddedDetails(int UserID)
        {
            TvDBContext context = new TvDBContext();
            var userAddressRepo = new BaseRepository<UserAddress>(context);
            var typeConnectRepo = new BaseRepository<TypeConnect>(context);
            var userRepo = new BaseRepository<User>(context);
            UserAddress address = new UserAddress
            {
                Address = tbUserAddress.Text,
                Comment = tbComment.Text,
                TypeConnect = typeConnectRepo.Get(x => x.NameType == cbAddressType.Text).First(),
                User = userRepo.Get(l => l.Id == UserID).First()
            };
            userAddressRepo.Insert(address);
        }
    }
}
