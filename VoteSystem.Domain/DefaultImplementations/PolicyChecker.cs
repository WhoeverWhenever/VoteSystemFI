using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    public class PolicyChecker : IPolicyChecker
    {
        IPollService _policyInfo;
        public PolicyChecker(IPollService policyInfo)
        {
            _policyInfo = policyInfo;
        }
        public bool CheckPolicy(int userId, int pollId)
        {
            foreach (var a in _policyInfo.GetAllAvailablePollIds(userId))
            {
                if (a == pollId)
                    return true;
            }
            return false;
        }
    }
}
