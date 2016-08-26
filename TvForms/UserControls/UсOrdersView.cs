using System.Windows.Forms;

namespace TvForms
{
    public partial class UсOrdersView : UserControl
    {
        private int CurrenUserId { get; set; }

        public UсOrdersView(int currentUserId)
        {
            InitializeComponent();
            CurrenUserId = currentUserId;

        }


    }
}
