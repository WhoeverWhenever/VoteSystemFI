using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.UserPolicyAggregate;

namespace VoteSystem.Domain.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int userId);
        User GetUserByEmail(string Email);
        List<UserPolicy> GetAllAdminPolicies(int userId);
        List<UserPolicy> GetAllAccessPolicies(int userId);
        public User GetUserByMainInfo(string passportCode, int indefCode);
    }
}
