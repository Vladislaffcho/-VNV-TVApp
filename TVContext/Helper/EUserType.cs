namespace TVContext
{
    /// <summary>
    /// Enumeration of types of all user in project
    /// </summary>
    public enum EUserType
    {
        /// <summary>
        /// When user doesn't intialised
        /// </summary>
        ACCESS_DENIED = 0,
        /// <summary>
        /// Administrator of project. Has full permission in the DB, besides change user's data
        /// </summary>
        ADMIN = 1,

        /// <summary>
        /// Can order any programm, add services and shows. Can change only personal information and recharge account
        /// </summary>
        CLIENT,

        /// <summary>
        /// other types of users
        /// </summary>
        
        MANAGER,
        CHIEF
    }
}