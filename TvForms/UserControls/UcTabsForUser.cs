using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcTabsForUser : UserControl
    {
        private readonly BaseRepository<Channel> _channelRepo = new BaseRepository<Channel>();

        //ToDO Use only one UC
        private List<Channel> CurrentWeekChannel { get; set; }

        public UcTabsForUser()
        {
            
            //ToDo Load channels for put in into constructor of ucChannelShowInfo
            InitializeComponent();

            //CurrentWeekChannel = new List<Channel>();
            CurrentWeekChannel = _channelRepo.GetAll().ToList();
            tabPan_AllChannels.Controls.Add(new UcAllChannels(CurrentWeekChannel));
            
        }
        
        public int GetIndexTabForUsers()
        {
            return tabForUsers.SelectedIndex;
        }

        private void tabForUsers_Selected(object sender, TabControlEventArgs e)
        {
            //ChosenChannels = TabInfo.MyChannelsChoose;

            //switch (GetIndexMainTab())
            //{
            //    case 0:
            //        ChosenChannels = TabInfo.MyChannelsChoose;
            //        TabInfo = _allChannelInfo;
            //        break;
            //    case 1:
            //        //ChosenChannels = new List<Channel>();
            //        ChosenChannels = TabInfo.MyChannelsChoose;
            //        _myChannelInfo.MyChannelsChoose = ChosenChannels;
            //        _myChannelInfo.ShowMyChannelsAndAllShows();
            //        TabInfo = _myChannelInfo;
            //        break;
            //    case 2:
            //        ChosenChannels = TabInfo.MyChannelsChoose;
            //        _myShowsInfo.MyChannelsChoose = ChosenChannels;
            //        _myShowsInfo.ShowMyChanAndMyShows();
            //        TabInfo = _myShowsInfo;
            //        break;
            //}

            //tabForUsers.SelectedTab.Controls.Add(TabInfo);
        }
    }
}
