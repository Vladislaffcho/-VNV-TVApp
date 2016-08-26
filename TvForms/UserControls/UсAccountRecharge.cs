using System.Windows.Forms;

namespace TvForms
{
    public partial class UсAccountRecharge : UserControl
    {
        private int CurrentUserId { get; set; }

        public UсAccountRecharge(int userId)
        {
            InitializeComponent();
            CurrentUserId = userId;
            mtbCvvCode.UseSystemPasswordChar = true;
        }

        public bool ValidateControls()
        {
            //var type = _updateConnectType;
            //switch (type)
            //{
            //    case EUserDetailType.Address:
            //        return ucAddress.ValidateControls();
            //    case EUserDetailType.Email:
            //        return ucEmail.ValidateControls();
            //    case EUserDetailType.Telephone:
            //        return ucTelephone.ValidateControls();
            //    case EUserDetailType.User:
            //        return ucUserNames.ValidateControls();
            //    default:
            //        return true; /* return false, change validation */
            //}
            return true;
        }

    }
}
