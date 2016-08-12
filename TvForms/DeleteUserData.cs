using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public class DeleteUserData
    {
        // based on which user data type has been passed to the class, corresponding method will be called
        public DeleteUserData(int DeleteRecordID, string type)
        {
            switch (type)
            {
                case "Address":
                    DeleteAddress(DeleteRecordID);
                    break;
            }
        }


        // Waiting for user's confirmation
        // If user confirms, selected address gets deleted from the db
        private void DeleteAddress(int addressID)
        {
            int i = 0;
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