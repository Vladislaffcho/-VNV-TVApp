using System.Windows.Forms;

namespace TvForms
{
    public partial class UcPayments : UserControl
    {
        private int CurrentUserId { get; set; }

        public UcPayments(int currentUserId)
        {
            InitializeComponent();
            CurrentUserId = currentUserId;
        }
    }
}
