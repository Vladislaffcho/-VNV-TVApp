using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UсAccountCharge : UserControl
    {
        private int CurrentUserId { get; set; }

        public UсAccountCharge(int userId)
        {
            InitializeComponent();
            CurrentUserId = userId;
            mtbCvvCode.UseSystemPasswordChar = true;
        }

        public bool ValidateControls()
        {
            var errorMessage = "Error(s):" + Environment.NewLine;
            var isValidCardDatas = true;

            mtbCardNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            var cardNumber = mtbCardNumber.Text.Trim();
            mtbCardNumber.TextMaskFormat = MaskFormat.IncludeLiterals;

            if (cardNumber == string.Empty || cardNumber.Length < 16)
            {
                errorMessage += "Card number cannot be empty or shorter than 16 digits" + Environment.NewLine;
                isValidCardDatas = false;
            }

            int month;
            int year;
            int.TryParse(mtbDateCard.Text.Split('.').First().Trim(), out month);
            int.TryParse(mtbDateCard.Text.Split('.').Last().Trim(), out year);

            if (month <= 0 || month > 12 || year < (DateTime.Now.Year - 2000))
            {
                errorMessage += $"Entered wrong month - '{month}' or year - '{year}'" + Environment.NewLine;
                isValidCardDatas = false;
            }

            int cvvCode;
            int.TryParse(mtbCvvCode.Text.Trim(), out cvvCode);
            if (mtbCvvCode.Text.Trim() == string.Empty || mtbCvvCode.Text.Trim().Length != 3)
            {
                errorMessage += "CVV-code cannot be empty or length not than 3 digits" + Environment.NewLine;
                isValidCardDatas = false;
            }

            double summ;
            var isDouble = double.TryParse(tbSummRecharge.Text, NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture, out summ);
            if (isDouble == false || tbSummRecharge.Text.Trim() == string.Empty || summ <= 0.0)
            {
                errorMessage += "Summ to recharge entered incorrect" + Environment.NewLine;
                isValidCardDatas = false;
            }

            if (isValidCardDatas)
            {

                var accountRepo = new BaseRepository<Account>();
                var userAcc = accountRepo.Get(a => a.User.Id == CurrentUserId).FirstOrDefault();
                if (userAcc != null)
                {
                    userAcc.Balance += summ;
                    accountRepo.Update(userAcc);
                }
                else
                {
                    var user = new BaseRepository<User>(accountRepo.ContextDb)
                        .Get(u => u.Id == CurrentUserId).FirstOrDefault();
                            
                    var newAccount = new Account
                    {
                        Balance = summ,
                        Comment = "automatically created new account",
                        IsActiveStatus = true,
                        User = user
                    };
                    accountRepo.Insert(newAccount);
                }
                
                MessageContainer.DisplayInfo($"Your account was succesfull charged on {summ} UAH", "Succesfull");

            }
            else
            {
                MessageContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidCardDatas;

        }

        // Simple check to make sure link is valid,
        // can be modified to check for other protocols:
        private bool IsHttpURL(string url)
        {
            return
                ((!string.IsNullOrWhiteSpace(url)) &&
                (url.ToLower().StartsWith("http")));
        }

        //start browser with specified link
        private void StartBrowser(string url)
        {
            if (IsHttpURL(url))
                Process.Start(url);
        }

        // Performs the actual browser launch to follow link:
        //goto appropriate site if url correct
        //VISA
        //text link
        private void lLbLicenceVisa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartBrowser("https://www.visaeurope.com/");
        }

        //VISA
        //picture double click
        private void pbVisa_DoubleClick(object sender, EventArgs e)
        {
            StartBrowser("https://www.visaeurope.com/");
        }

        //MASTERCARD
        //text link
        private void lLbLicenceMaster_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartBrowser("http://www.mastercard.com/ua/consumer/index.html");
        }

        //MASTERCARD
        //picture double click
        private void pbMasterCard_DoubleClick(object sender, EventArgs e)
        {
            StartBrowser("http://www.mastercard.com/ua/consumer/index.html");
        }

        //MAESTRO CIRUS
        //text link
        private void lLbLicenceMaestro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartBrowser("http://www.maestrocard.com/gateway/index.html");
        }

        //MAESTRO CIRUS
        //picture double click
        private void pbMaestro_DoubleClick(object sender, EventArgs e)
        {
            StartBrowser("http://www.maestrocard.com/gateway/index.html");
        }


    }
}
