using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    class PolicyChecker : IPolicyChecker
    {
        IPolicyInfo _policyInfo;
        public PolicyChecker(IPolicyInfo policyInfo)
        {
            _policyInfo = policyInfo;
        }
        public bool CheckPolicy(int userId, int pollId)
        {
            foreach (var a in _policyInfo.GetAllPolicies(userId))
            {
                if (a == pollId)
                    return true;
            }
            return false;
        }
    }
}
