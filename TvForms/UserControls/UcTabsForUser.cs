using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcTabsForUser : UserControl
    {
        BaseRepository<Channel> _channelRepo = new BaseRepository<Channel>();

        //ToDO Use only one UC
        private ucChannelShowInfo _allChannelInfo;
        private ucChannelShowInfo _myChannelInfo;
        private ucChannelShowInfo _myShowsInfo;

        public ucChannelShowInfo TabInfo { get; set; }

        //private List<Channel> _chosenChannels;

        public List<Channel> ChosenChannels { get; set; }

        //public ucChannelShowInfo MyChannelTab = new ucChannelShowInfo(true, true);
        //public ucChannelShowInfo MyShowTab = new ucChannelShowInfo(false, true);

        public UcTabsForUser()
        {
            //ToDo Load channels for put in into constructor of ucChannelShowInfo
            InitializeComponent();

            //_chosenChannels = new List<Channel>();
            ChosenChannels = new List<Channel>();

            //_allChannelInfo = new ucChannelShowInfo(0);
            //_myChannelInfo = new ucChannelShowInfo(1);
            //_myShowsInfo = new ucChannelShowInfo(2);
            ChosenChannels = _channelRepo.GetAll().ToList();
            //TabInfo = _allChannelInfo;
            //tabForUsers.SelectedTab.Controls.Add(TabInfo);
            tabPan_AllChannels.Controls.Add(new ucChannelShowInfo(ChosenChannels));
            //tabPan_MyShow.Controls.Add(MyShowTab);
        }
        
        public int GetIndexMainTab()
        {
            return tabForUsers.SelectedIndex;
        }

        private void tabForUsers_Selected(object sender, TabControlEventArgs e)
        {
            //ChosenChannels = TabInfo.MyChannelsChoose;

            switch (GetIndexMainTab())
            {
                case 0:
                    ChosenChannels = TabInfo.MyChannelsChoose;
                    TabInfo = _allChannelInfo;
                    break;
                case 1:
                    //ChosenChannels = new List<Channel>();
                    ChosenChannels = TabInfo.MyChannelsChoose;
                    _myChannelInfo.MyChannelsChoose = ChosenChannels;
                    _myChannelInfo.ShowMyChannelsAndAllShows();
                    TabInfo = _myChannelInfo;
                    break;
                case 2:
                    ChosenChannels = TabInfo.MyChannelsChoose;
                    _myShowsInfo.MyChannelsChoose = ChosenChannels;
                    _myShowsInfo.ShowMyChanAndMyShows();
                    TabInfo = _myShowsInfo;
                    break;
            }

            tabForUsers.SelectedTab.Controls.Add(TabInfo);
        }
    }
}
