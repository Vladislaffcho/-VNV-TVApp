using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVContext;

namespace TvForms.Forms
{
    public partial class AdditionalServicesForm : Form
    {
        private int _currentUser;

        public AdditionalServicesForm(int currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            SetPageView();
        }

        // set form view on opening
        private void SetPageView()
        {
            var servicesRepo = new BaseRepository<AdditionalService>();
            var services = servicesRepo.GetAll();
            foreach (var service in services)
            {
                var lvItem = new ListViewItem(service.Name);
                lvItem.SubItems.Add(service.Price.ToString());
                lvItem.SubItems.Add(AgeLimitedContent(service.IsAgeLimit));
                lvItem.SubItems.Add(service.Id.ToString());
                lvAvailableAdditionalServices.Items.Add(lvItem);
            }

            var userServices = servicesRepo._context.OrderServices
                .Where(s => s.Order.User.Id == _currentUser);
            foreach (var service in userServices)
            {
                var lvItem = new ListViewItem(service.AdditionalService.Name);
                lvItem.SubItems.Add(service.AdditionalService.Price.ToString());
                lvItem.SubItems.Add(AgeLimitedContent(service.AdditionalService.IsAgeLimit));
                lvItem.SubItems.Add(service.AdditionalService.Id.ToString());
                lvMyAdditionalService.Items.Add(lvItem);
            }
        }

        private void btAddService_Click(object sender, EventArgs e)
        {
            // if user has not signed up for a service before, then create a service order
            if (lvAvailableAdditionalServices.SelectedItems.Count > 0)
            {
                var serviceId = lvAvailableAdditionalServices
                    .SelectedItems[0].SubItems[3].Text.GetInt();
                var orderServiceReposotory = new BaseRepository<OrderService>();
                if (!orderServiceReposotory.Get(x => x.AdditionalService.Id == serviceId)
                    .Where(u => u.Order.User.Id == _currentUser)
                    .Any()
                    )
                {
                    var orderedService = new OrderService
                    {
                        AdditionalService = orderServiceReposotory._context.AddServices
                            .Where(c => c.Id == serviceId).FirstOrDefault(),
                        // create new global order which will represent exact service order in the db
                        Order = new Order
                        {
                            DateOrder = DateTime.Now,
                            FromDate = DateTime.Now,
                            DueDate = new DateTime(2016, 12, 31),
                            TotalPrice = orderServiceReposotory._context.AddServices
                                .Where(x => x.Id == serviceId)
                                .First()
                                .Price,
                            IsPaid = false,
                            IsDeleted = false,
                            User = orderServiceReposotory._context.Users
                                .Where(u => u.Id == _currentUser)
                                .First()
                        }
                    };
                    orderServiceReposotory.Insert(orderedService);
                    MessagesContainer.DisplayInfo("Chosen item has successfully been added to your orders", "Success");
                }

                else
                {
                    MessagesContainer.DisplayError("You already have this service", "Error");
                }
            }
            else
            {
                MessagesContainer.DisplayError("You should select a service to add", "Error");
            }
        }

        private string AgeLimitedContent(bool isLimited)
        {
            if (isLimited)
            {
                return "Yes";
            }
            return "No";
        }
    }
}
