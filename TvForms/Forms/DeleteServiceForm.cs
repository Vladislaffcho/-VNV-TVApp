using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvContext;

namespace TvForms.Forms
{
    // functionality to delete obsolete company service
    public partial class DeleteServiceForm : Form
    {
        public DeleteServiceForm()
        {
            InitializeComponent();
            SetPageView();
        }

        // set form view on opening or after removing a service
        private void SetPageView()
        {
            lvAdditionalServices.Items.Clear();
            var servicesRepo = new BaseRepository<AdditionalService>();
            var services = servicesRepo.GetAll();
            foreach (var service in services)
            {
                var lvItem = new ListViewItem(service.Name);
                lvItem.SubItems.Add(service.Price.ToString());
                lvItem.SubItems.Add(service.IsAgeLimit.AgeLimitedContent());
                lvItem.SubItems.Add(service.Id.ToString());
                lvAdditionalServices.Items.Add(lvItem);
            }
        }

        // once a user selected a service and clicked Delete button
        // service gets deleted from the DB
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lvAdditionalServices.SelectedItems.Count > 0)
            {
                var serviceId = lvAdditionalServices
                   .SelectedItems[0].SubItems[3].Text.GetInt();
                var serviceReposotory = new BaseRepository<AdditionalService>();
                var serviceToRemove = serviceReposotory.Get(x => x.Id == serviceId)
                    .First();
                serviceReposotory.Remove(serviceToRemove);
                MessagesContainer.DisplayInfo("Service removed successfully", "Success");
                SetPageView();
            }
            else
            {
                MessagesContainer.DisplayError("Select a service to remove", "Error");
            }
        }
    }
}
