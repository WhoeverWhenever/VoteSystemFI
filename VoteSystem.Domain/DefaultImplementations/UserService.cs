
using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepos;
        public UserService(IUserRepository userRepository)
        {
            _userRepos = userRepository;
        }

        public List<UserPolicy> GetAllAccessPolicies(int userId)
        {
            return _userRepos.GetAllAccessPolicies(userId);
        }

        public List<UserPolicy> GetAllAdminPolicies(int userId)
        {
            return _userRepos.GetAllAdminPolicies(userId);
        }

        public User GetUserByEmail(string Email)
        {
            return _userRepos.GetUser(Email);
        }

        public User GetUserById(int userId)
        {
            return _userRepos.GetUser(userId);
        }
        public User GetUserByMainInfo(string passportCode, int indefCode)
        {
            return _userRepos.GetUser(passportCode, indefCode);
        }
    }
}
