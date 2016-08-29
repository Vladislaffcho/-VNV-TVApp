using System;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public static class DeleteUserData
    {
        // Remove phone functionality
        public static void DeleteTelephone(int phoneId)
        {
            DialogResult result = MessageBox.Show("Do you want to remove selected telephone?", "Remove email", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var userPhonesRepo = new BaseRepository<UserPhone>();
                var phoneToRemove = userPhonesRepo.Get(x => x.Id == phoneId).First();
                userPhonesRepo.Remove(phoneToRemove);
            }
        }

        // Remove email functionality
        public static void DeleteEmail(int emailId)
        {
            DialogResult result = MessageBox.Show("Do you want to remove selected email?", "Remove email", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var userEmailsRepo = new BaseRepository<UserEmail>();
                var emailToRemove = userEmailsRepo.Get(x => x.Id == emailId).First();
                userEmailsRepo.Remove(emailToRemove);
            }
        }


        // Remove address functionality
        public static void DeleteAddress(int addressID)
        {
            DialogResult result = MessageBox.Show("Do you want to remove selected address?", "Remove address", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var userAddressRepo = new BaseRepository<UserAddress>();
                var addressToRemove = userAddressRepo.Get(x => x.Id == addressID).First();
                userAddressRepo.Remove(addressToRemove);
            }
        }
    }
}