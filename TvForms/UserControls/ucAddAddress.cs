using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcAddAddress : UserControl
    {
        //ToDo Remove this fields
        private string _comment;
        private string _address;
        private string _type;

        public UcAddAddress()
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
                //ToDo Why?))
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
            /* The below method works perfectly, but without the reository pattern */
            /*using (var context = new TvDBContext())
            {
                UserAddress address = new UserAddress
                {
                    Address = tbUserAddress.Text,
                    Comment = tbComment.Text,
                    TypeConnect = context.TypeConnects.First(x => x.NameType == _type),
                    User = context.Users.First(l => l.Id == UserID)
                };
                context.UserAddresses.Add(address);
                context.SaveChanges();
            }*/


            /* Attempt 1. Get error in Insert method */
            var userAddressRepo = new BaseRepository<UserAddress>();
            var typeConnectRepo = new BaseRepository<TypeConnect>();
            var userRepo = new BaseRepository<User>();
            UserAddress address = new UserAddress
            {
                Address = tbUserAddress.Text,
                Comment = tbComment.Text,

                /* Problematic fields */
                TypeConnect = typeConnectRepo.Get(x => x.NameType == cbAddressType.Text).First(),
                User = userRepo.Get(l => l.Id == UserID).First()
                /* End of problematic fields */
            };
            userAddressRepo.Insert(address);


            /* below there are some other not working attempts of the same functionality */
            /*Attempt 2*/
            /*var userAddressRepo = new BaseRepository<UserAddress>();
            var connectTypeRepo = new BaseRepository<TypeConnect>();
            var userRepo = new BaseRepository<User>();
            var addressToAdd = new UserAddress();
            addressToAdd.Address = tbUserAddress.Text;
            addressToAdd.Comment = tbComment.Text;
            addressToAdd.TypeConnect = connectTypeRepo.Get(x => x.NameType == cbAddressType.Text).First();
            addressToAdd.User = userRepo.Get(l => l.Id == UserID).First();
            userAddressRepo.Insert(addressToAdd);*/

            /*Attempt 3*/
            /*using (var context = new TvDBContext())
            {
                var userAddressRepo = new BaseRepository<UserAddress>();
                var addressToAdd = new UserAddress();
                addressToAdd.Address = tbUserAddress.Text;
                addressToAdd.Comment = tbComment.Text;
                addressToAdd.TypeConnect = context.TypeConnects.First(x => x.NameType == _type);
                addressToAdd.User = context.Users.First(l => l.Id == UserID);
                userAddressRepo.Insert(addressToAdd);
            }*/

        }
    }
}
