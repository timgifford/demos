using System.Web.Security;

namespace Sayso.Domain.ISP
{
    public interface IMembershipFinder
    {
        MembershipUser GetUser(object providerUserKey, bool userIsOnline);
        MembershipUser GetUser(string username, bool userIsOnline);
        string GetUserNameByEmail(string email);
        bool DeleteUser(string username, bool deleteAllRelatedData);
        MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords);
        int GetNumberOfUsersOnline();
        MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords);
        MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords);
    }

    public interface IMembershipAction
    {
        MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status);
        void UpdateUser(MembershipUser user);
        bool ValidateUser(string username, string password);
        bool UnlockUser(string userName);
        bool DeleteUser(string username, bool deleteAllRelatedData);
    }

    public interface IPasswordActions
    {
        string GetPassword(string username, string answer);
        bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer);
        bool ChangePassword(string username, string oldPassword, string newPassword);
        string ResetPassword(string username, string answer);
    }

}