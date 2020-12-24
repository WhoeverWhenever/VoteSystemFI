
using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Domain.Interfaces
{
    public interface IContextRegistration
    {
        bool SetPasswordInfo(string passportCode, int indefCode);
        Tuple<string, int> GetPassportInfo();
    }
}
