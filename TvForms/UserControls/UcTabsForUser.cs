using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UcTabsForUser : UserControl
    {
        //private readonly List<Channel> _channelRepo = BaseRepository<Channel>.GetAll().ToList();

        private int CurrentUserId { get; set; }

        private int CurrentOrderId { get; set; }

        //ToDO Use only one UC
        //private List<Channel> CurrentWeekChannel { get; set; }

        private UcAllChannels AllChannelControl { get; set; }

        private UcFavoirute MyFavouriteControl { get; set; }

        public UcTabsForUser(int userId)
        {
            
            //ToDo Load channels for put in into constructor of ucChannelShowInfo
            InitializeComponent();
            CurrentUserId = userId;
            LoadControls(CurrentUserId);
            
        }

        private void LoadControls(int userId)
        {
            AllChannelControl = new UcAllChannels(userId);
            tabPan_AllChannels.Controls.Add(AllChannelControl);
        }


        private void tabForUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //0 - AllChannels tab, 1 - MyFavourite tab
            CurrentOrderId = AllChannelControl.CurrentOrderId;
            MyFavouriteControl?.Dispose();
            MyFavouriteControl = new UcFavoirute(CurrentUserId, CurrentOrderId);
            tabPan_MyFavourite.Controls.Add(MyFavouriteControl);
            
        }

        
    }
}
