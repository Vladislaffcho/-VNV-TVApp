using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcFavoirute : UserControl
    {
        BaseRepository<UserSchedule> _schedRepository = new BaseRepository<UserSchedule>();
        BaseRepository<OrderChannel> _orChRepository = new BaseRepository<OrderChannel>();
        BaseRepository<Order> _orderRepo = new BaseRepository<Order>();
        BaseRepository<Account> _accountRepo = new BaseRepository<Account>();

        private int CurrentUserId { get; set; }

        public UcFavoirute(int currentUserId)
        {
            InitializeComponent();
            CurrentUserId = currentUserId;
            SetMoneyToTextBoxs();
            LoadFavouriteMedia();
        }

        private void SetMoneyToTextBoxs()
        {
            var orderPrice = _orderRepo.Get(x => x.Id == CurrentUserId).FirstOrDefault();
            tbTotalPrice.Text = orderPrice?.TotalPrice.ToString(CultureInfo.CurrentCulture) ?? "0.00";

            var firstOrDefault = _accountRepo.Get(x => x.Id == CurrentUserId).FirstOrDefault();
            tbAccountBalance.Text = firstOrDefault?.Balance.ToString(CultureInfo.CurrentCulture) ?? "0.00";
        }

        private void LoadFavouriteMedia()
        {
            var number = 1;
            foreach (var sced in _schedRepository.Get(x => x.User.Id == CurrentUserId).ToList())
            {
                var item = new ListViewItem(number.ToString());

                var chName = _orChRepository.Get(x => x.Channel.Id == sced.TvShow.Channel.Id)
                    .FirstOrDefault()?.Channel.Name ?? "/-channel not paid-/";
                item.SubItems.Add(chName);

                var isAdult = _orChRepository.Get(x => x.Channel.Id == sced.TvShow.Channel.Id)
                    .FirstOrDefault()?.Channel.IsAgeLimit ?? false;
                item.SubItems.Add(isAdult ? "+" : string.Empty);

                var price = _orChRepository.Get(x => x.Channel.Id == sced.TvShow.Channel.Id)
                    .FirstOrDefault()?.Channel.Price.ToString(CultureInfo.CurrentCulture) ?? "0.00";
                item.SubItems.Add(price);

                item.SubItems.Add(sced.TvShow.Date.Day + "/" + sced.TvShow.Date.Month);
                item.SubItems.Add(sced.TvShow.Date.ToShortTimeString());
                item.SubItems.Add(sced.TvShow.Name);
                lvFavouriteProgs.Items.Add(item);
                number++;
            }

            
        }
    }
}
