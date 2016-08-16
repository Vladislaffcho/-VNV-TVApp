using System.Linq;
using System.Text.RegularExpressions;
using TVContext;

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
            var userRepo = new BaseRepository<User>();
            return userRepo.Get(x => x.Login == login).Any();
        }
    }
}