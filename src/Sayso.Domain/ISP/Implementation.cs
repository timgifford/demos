using System;
using System.Web.Security;

namespace Sayso.Domain.ISP
{
    public class CouchDbMembershipFinder : IMembershipFinder
    {
        public MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
    }

    public class CouchDbMembershipActions : IMembershipAction
    {
        public MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }


        public void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }
    }

    public class CouchDbPasswordActions : IPasswordActions
    {
        public string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

    }
}