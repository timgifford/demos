using System.Web.Security;

namespace Sayso.Domain.ISP
{
    public class MembershipConfiguration
    {
        public bool EnablePasswordRetrieval
        {
            get; set;
        }

        public bool EnablePasswordReset
        {
            get; 
            set;
        }

        public bool RequiresQuestionAndAnswer
        {
            get;
            set;
        }

        public  string ApplicationName
        {
            get;
            set;
        }

        public int MaxInvalidPasswordAttempts
        {
            get;
            set;
        }

        public  int PasswordAttemptWindow
        {
            get;
            set;
        }

        public  bool RequiresUniqueEmail
        {
            get;
            set;
        }

        public  MembershipPasswordFormat PasswordFormat
        {
            get;
            set;
        }

        public  int MinRequiredPasswordLength
        {
            get;
            set;
        }

        public  int MinRequiredNonAlphanumericCharacters
        {
            get;
            set;
        }

        public  string PasswordStrengthRegularExpression
        {
            get;
            set;
        }
    }
}