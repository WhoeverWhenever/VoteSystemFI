using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    class ManagePolicy : IManagePolicy
    {
        IUserRepository _userRepos;
        public ManagePolicy(IUserRepository userRepository)
        {
            _userRepos = userRepository;
        }
        public bool GivePolicyToUser(int userId, int pollId, PolicyType policyType)
        {
            if (_userRepos.GetUser(userId) == null)
                return false;
            UserPolicy userPolicy = new UserPolicy()
            {
                PolicyType = policyType,
                user = _userRepos.GetUser(userId),
                PollId = pollId
            };
            _userRepos.CreateUserPolicy(userPolicy);
            return true;
        }
    }
}
