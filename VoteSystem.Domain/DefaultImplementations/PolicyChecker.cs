using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    public class PolicyChecker : IPolicyChecker
    {
        IUserService _userService;
        public PolicyChecker( IUserService userService)
        {
            _userService = userService;
        }
        public bool CheckPolicy(int userId, int pollId)
        {
            foreach (var a in _userService.GetAllAccessPolicies(userId))
            {
                if (a.PollId == pollId)
                    return true;
            }
            return false;
        }
        public bool CheckAdminPolicy(int userId, int pollId)
        {
            foreach (var a in _userService.GetAllAdminPolicies(userId))
            {
                if (a.PollId == pollId)
                    return true;
            }
            return false;
        }
    }
}
