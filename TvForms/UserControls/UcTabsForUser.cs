using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TvForms;
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
            CurrentWeekChannel = _channelRepo.GetAll().ToList();
            tabPan_AllChannels.Controls.Add(new UcAllChannels(CurrentWeekChannel));
            tabPan_MyFavourite.Controls.Add(new UcFavoirute(CurrentWeekChannel));

        }
        
        public int GetIndexTabForUsers()
        {
            return tabForUsers.SelectedIndex;
        }


        private void tabForUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //0 - AllChannels tab, 1 - MyFavourite tab
            //throw new NotImplementedException();

        }
    }
}
