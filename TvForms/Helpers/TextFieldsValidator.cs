using System.Linq;
using System.Text.RegularExpressions;
using TvContext;

namespace TvForms
{
    public static class TextFieldsValidator
    {
        // method to validate first and last names
        public static bool IsValidName(this string name)
        {
            Regex r = new Regex("^[a-zA-Z ]*$");
            if (r.IsMatch(name))
            {
                return true;
            }
            return false;
        }

        // method to validate user's login and password
        public static bool IsValidLoginAndPassword(this string name)
        {
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (r.IsMatch(name))
            {
                return true;
            }
            return false;
        }

        // method which checks login uniqness
        public static bool IsUniqueLogin(this string login)
        {
            return BaseRepository<User>.Get(x => x.Login == login).Any();
        }

        // regex to validate email
        public static bool IsValidEmail(this string email)
        {
            return Regex.IsMatch(email, 
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase);
        }

        public static bool IsUniqueEmail(this string email)
        {
            return BaseRepository<UserEmail>.Get(x => x.EmailName == email).Any();
        }

        public static bool IsUniqueNumber(this int number)
        {
            return BaseRepository<UserPhone>.Get(x => x.Number == number).Any();
        }

        public static bool IsUniqueAddress(this string address)
        {
            return BaseRepository<UserAddress>.Get(x => x.Address == address).Any();
        }

        public static bool IsValidPhone(this string number)
        {
            return Regex.IsMatch(number, @"^([0-9]{5,9})$");
        }

        public static bool IsValidComment(this string comment)
        {
            if (comment.Length <= 500)
            {
                return true;
            }
            return false;
        }

    }
}