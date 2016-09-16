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
            return new BaseRepository<User>().Get(x => x.Login == login).Any();
        }

        // regex to validate email
        public static bool IsValidEmail(this string email)
        {
            return Regex.IsMatch(email, 
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase);
        }

        // check email number uniqueness
        public static bool IsUniqueEmail(this string email)
        {
            return new BaseRepository<UserEmail>().Get(x => x.EmailName == email).Any();
        }

        // check phone number uniqueness
        public static bool IsUniqueNumber(this int number)
        {
            return new BaseRepository<UserPhone>().Get(x => x.Number == number).Any();
        }

        // chack if the newly-added address is unique
        public static bool IsUniqueAddress(this string address)
        {
            return new BaseRepository<UserAddress>().Get(x => x.Address == address).Any();
        }

        // validate phone number
        public static bool IsValidPhone(this string number)
        {
            return Regex.IsMatch(number, @"^([0-9]{5,9})$");
        }

        // validate comment length
        public static bool IsValidComment(this string comment)
        {
            if (comment.Length <= 500)
            {
                return true;
            }
            return false;
        }

        // method to validate new service names
        public static bool IsValidService(this string service)
        {
            Regex r = new Regex("^[a-zA-Z0-9 ]*$");
            if (r.IsMatch(service))
            {
                return true;
            }
            return false;
        }

    }
}