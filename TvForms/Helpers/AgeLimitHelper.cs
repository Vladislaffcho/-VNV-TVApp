namespace TvForms
{
    public static class AgeLimitHelper
    {
        // extension method for bool
        // returns string:
        // yes - if the content / service is 18+
        // no - if allowed for all ages
        public static string AgeLimitedContent(this bool isLimited)
        {
            if (isLimited)
            {
                return "Yes";
            }
            return "No";
        }
    }
}