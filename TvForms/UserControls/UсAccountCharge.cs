using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TVContext;

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

            var month = 0;
            var year = 0;
            int.TryParse(mtbDateCard.Text.Split('.').First().Trim(), out month);
            int.TryParse(mtbDateCard.Text.Split('.').Last().Trim(), out year);

            if (month <= 0 || month > 12 || year < (DateTime.Now.Year - 2000))
            {
                errorMessage += $"Entered wrong month - '{month}' or year - '{year}'" + Environment.NewLine;
                isValidCardDatas = false;
            }

            var cvvCode = 0;
            int.TryParse(mtbCvvCode.Text.Trim(), out cvvCode);
            if (mtbCvvCode.Text.Trim() == string.Empty || mtbCvvCode.Text.Trim().Length != 3)
            {
                errorMessage += "CVV-code cannot be empty or length not than 3 digits" + Environment.NewLine;
                isValidCardDatas = false;
            }

            var summ = 0.0;
            var isDouble = double.TryParse(tbSummRecharge.Text, NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture, out summ);
            if (isDouble == false || tbSummRecharge.Text.Trim() == string.Empty || summ <= 0.0)
            {
                errorMessage += "Summ to recharge entered incorrect" + Environment.NewLine;
                isValidCardDatas = false;
            }

            if (isValidCardDatas)
            {
                using (var context = new TvDBContext())
                {
                    var accountRepo = new BaseRepository<Account>(context);
                    var userAcc = accountRepo.Get(a => a.User.Id == CurrentUserId).FirstOrDefault();
                    if (userAcc != null)
                    {
                        userAcc.Balance += summ;
                        accountRepo.Update(userAcc);
                    }
                    else
                    {
                        var user =
                            new BaseRepository<User>(context).Get(u => u.Id == CurrentUserId).FirstOrDefault();
                            
                        var newAccount = new Account
                        {
                            Balance = summ,
                            Comment = "automatically created new account",
                            IsActiveStatus = true,
                            User = user
                        };
                        accountRepo.Insert(newAccount);
                    }
                }
                MessagesContainer.DisplayInfo($"Your account was succesfull charged on {summ} грн.", "Succesfull");

            }
            else
            {
                MessagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidCardDatas;

        }

    }
}
