using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Domain.Interfaces
{
    interface IPolicyInfo
    {
        List<int> GetAllPolicies(int userId);
    }
}
