using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Domain.Interfaces
{
    interface IPolicyChecker
    {
        bool CheckPolicy(int userId, int pollId);
    }
}
