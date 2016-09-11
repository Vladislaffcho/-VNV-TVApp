using System;
using System.Linq;
using System.Windows.Forms;
using TvContext;

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
                lvItem.SubItems.Add(service.IsAgeLimit.AgeLimitedContent());
                lvItem.SubItems.Add(service.Id.ToString());
                lvAvailableAdditionalServices.Items.Add(lvItem);
            }

            var userServices = servicesRepo.ContextDb.OrderServices.Where(s => s.Order.User.Id == _currentUser);
            foreach (var service in userServices)
            {
                var lvItem = new ListViewItem(service.AdditionalService.Name);
                lvItem.SubItems.Add(service.AdditionalService.Price.ToString());
                lvItem.SubItems.Add(service.AdditionalService.IsAgeLimit.AgeLimitedContent());
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
                if (!orderServiceReposotory
                    .Get(x => x.AdditionalService.Id == serviceId)
                    .Any(u => u.Order.User.Id == _currentUser)
                    )
                {
                    var orderedService = new OrderService
                    {
                        AdditionalService = orderServiceReposotory.ContextDb.AddServices
                            .FirstOrDefault(c => c.Id == serviceId),
                        // create new global order which will represent exact service order in the db
                        Order = orderServiceReposotory.ContextDb.Orders.FirstOrDefault(o => o.User.Id == _currentUser 
                            && o.IsPaid == false && o.IsDeleted == false) /*new Order
                        {
                            DateOrder = DateTime.Now,
                            FromDate = DateTime.Now,
                            DueDate = new DateTime(2016, 12, 31),
                            TotalPrice = orderServiceReposotory.ContextDb.AddServices
                                .First(x => x.Id == serviceId)
                                .Price,
                            IsPaid = false,
                            IsDeleted = false,
                            User = orderServiceReposotory.ContextDb.Users
                                .First(u => u.Id == _currentUser)
                        }*/
                    };

                    orderedService.Order.TotalPrice += orderedService.AdditionalService.Price;
                    orderedService.Order.User = orderServiceReposotory.ContextDb.Users
                                .FirstOrDefault(u => u.Id == _currentUser);

                    orderServiceReposotory.Insert(orderedService);
                    MessagesContainer.DisplayInfo("Chosen item has successfully been added to your orders", "Success");
                    var userServices = orderServiceReposotory.ContextDb.OrderServices.Where(s => s.Order.User.Id == _currentUser);
                    lvMyAdditionalService.Items.Clear();
                    foreach (var service in userServices)
                    {
                        var lvItem = new ListViewItem(service.AdditionalService.Name);
                        lvItem.SubItems.Add(service.AdditionalService.Price.ToString());
                        lvItem.SubItems.Add(service.AdditionalService.IsAgeLimit.AgeLimitedContent());
                        lvItem.SubItems.Add(service.AdditionalService.Id.ToString());
                        lvMyAdditionalService.Items.Add(lvItem);
                    }
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
    }
}
