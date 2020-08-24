using System;

namespace NotifyAuthenticationHandler.Models
{
    /// <summary>
    /// Represents the basic information needed about a user from OnBase.
    /// </summary>
    public sealed class OnBaseUserBasicInformation
    {
        /// <summary>
        /// Represents the username that belongs to a user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Represents the group nae that a user belongs to.
        /// </summary>
        public string UserGroupName { get; set; }


        /// <summary>
        /// Represents the group nae that a user belongs to.
        /// </summary>
        public string Usernum { get; set; }

        /// <summary>
        /// Represents when a user logged into the system for last time.
        /// </summary>
        public DateTime LastLogOn { get; set; }
    }
}
