using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public static class DeleteUserData
    {
        // Remove phone functionality
        public static void DeleteTelephone(int phoneId)
        {
            DialogResult result = MessageBox.Show(@"Do you want to remove selected telephone?", @"Remove email", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var phoneToRemove = BaseRepository<UserPhone>.Get(x => x.Id == phoneId).First();
                //var userPhonesRepo = BaseRepository<UserPhone>.GetAll();
                //var phoneToRemove = userPhonesRepo.Get(x => x.Id == phoneId).First();
                BaseRepository<UserPhone>.Remove(phoneToRemove);
            }
        }

        // Remove email functionality
        public static void DeleteEmail(int emailId)
        {
            DialogResult result = MessageBox.Show(@"Do you want to remove selected email?", @"Remove email", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var emailToRemove = BaseRepository<UserEmail>.Get(x => x.Id == emailId).First();
                //var userEmailsRepo = new BaseRepository<UserEmail>();
                ////var emailToRemove = userEmailsRepo.Get(x => x.Id == emailId).First();
                BaseRepository<UserEmail>.Remove(emailToRemove);
            }
        }


        // Remove address functionality
        public static void DeleteAddress(int addressId)
        {
            DialogResult result = MessageBox.Show(@"Do you want to remove selected address?", @"Remove address", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var addressToRemove = BaseRepository<UserAddress>.Get(x => x.Id == addressId).First();
                //var userAddressRepo = new BaseRepository<UserAddress>();
                //var addressToRemove = userAddressRepo.Get(x => x.Id == addressID).First();
                BaseRepository<UserAddress>.Remove(addressToRemove);
            }
        }
    }
}