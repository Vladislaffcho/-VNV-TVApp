using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    // class to remove user data
    public static class DeleteUserData
    {
        // Remove phone functionality
        public static void DeleteTelephone(int phoneId)
        {
            var result = MessageBox.Show(@"Do you want to remove selected telephone?", @"Remove email", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var phoneRepo = new BaseRepository<UserPhone>();
                var phoneToRemove = phoneRepo.Get(x => x.Id == phoneId).FirstOrDefault();
                //var userPhonesRepo = BaseRepository<UserPhone>.GetAll();
                //var phoneToRemove = userPhonesRepo.Get(x => x.Id == phoneId).First();
                phoneRepo.Remove(phoneToRemove);
            }
        }

        // Remove email functionality
        public static void DeleteEmail(int emailId)
        {
            var result = MessageBox.Show(@"Do you want to remove selected email?", @"Remove email", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var emailRepo = new BaseRepository<UserEmail>();
                var emailToRemove = emailRepo.Get(x => x.Id == emailId).First();
                //var userEmailsRepo = new BaseRepository<UserEmail>();
                ////var emailToRemove = userEmailsRepo.Get(x => x.Id == emailId).First();
                emailRepo.Remove(emailToRemove);
            }
        }


        // Remove address functionality
        public static void DeleteAddress(int addressId)
        {
            var result = MessageBox.Show(@"Do you want to remove selected address?", @"Remove address", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var userAddressRepo = new BaseRepository<UserAddress>();
                var addressToRemove = userAddressRepo.Get(x => x.Id == addressId).First();
                userAddressRepo.Remove(addressToRemove);
            }
        }
    }
}