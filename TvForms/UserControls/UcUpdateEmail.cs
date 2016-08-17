using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVContext;

namespace TvForms.UserControls
{
    public partial class UcUpdateEmail : UserControl
    {
        private int _emailId;
        UserEmail _email = new UserEmail();
        public UcUpdateEmail()
        {
            InitializeComponent();
        }

        public void UpdateEmail(int emailId)
        {
            _emailId = emailId;
            SetControlView();
        }

        private void SetControlView()
        {
            int i = 0;
            using (var context = new TvDBContext())
            {
                var types = from t in context.TypeConnects
                            select t;
                types.ToList();

                _email = context.UserEmails.First(c => c.Id == _emailId);
                tbUserEmail.Text = _email.EmailName;
                tbComment.Text = _email.Comment;
                foreach (var typeConnect in types)
                {
                    cbEmailType.Items.Add(typeConnect.NameType);
                    if (typeConnect.NameType == _email.TypeConnect.NameType)
                    {
                        cbEmailType.SelectedIndex = i;
                    }
                    i++;
                }
            }
        }

        // validate entered data
        public bool ValidateControls()
        {
            string errorMessage = "Error:";
            bool isValidEmail = true;
            if (tbUserEmail.Text.Trim() != String.Empty)
            {
                if (!tbUserEmail.Text.Trim().IsValidEmail())
                {
                    errorMessage += "\nPlease enter email in valid format";
                    isValidEmail = false;
                }
                else if (tbUserEmail.Text.Trim().IsUniqueEmail())
                {
                    errorMessage += "\nEmail already exists. Please enter another one";
                    isValidEmail = false;
                }
            }
            else
            {
                errorMessage += "\nEmail field cannot be empty";
                isValidEmail = false;
            }

            if (!tbComment.Text.Trim().IsValidComment())
            {
                errorMessage += "\nComment cannot be longer than 500 characters";
                isValidEmail = false;
            }

            if (isValidEmail)
            {
                SaveAddedDetails();
            }
            else
            {
                ErrorMassages.DisplayError(errorMessage, "Invalid input");
            }
            return isValidEmail;
        }

        public void SaveAddedDetails()
        {
            using (var context = new TvDBContext())
            {
                var userEmailRepo = new BaseRepository<UserEmail>(context);
                var typeConnectRepo = new BaseRepository<TypeConnect>(context);
                var emailToUpdate = userEmailRepo.Get(x => x.Id == _emailId)
                    .Include(x => x.TypeConnect)
                    .Include(x => x.User).First();
                emailToUpdate.EmailName = tbUserEmail.Text;
                emailToUpdate.Comment = tbComment.Text;
                emailToUpdate.TypeConnect = typeConnectRepo.Get(l => l.NameType == cbEmailType.SelectedItem.ToString()).First();
                userEmailRepo.Update(emailToUpdate);
            }
        }
    }
}
