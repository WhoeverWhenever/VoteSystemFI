using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Cosnole
{
    class ContextRegistration : IContextRegistration
    {
        private string _passportCode;
        private int _indefCode;
        public Tuple<string, int> GetPassportInfo()
        {
            return new Tuple<string, int>(_passportCode, _indefCode);
        }

        public bool SetPasswordInfo(string passportCode, int indefCode)
        {
            _passportCode = passportCode;
            _indefCode = indefCode;
            return true;
        }
    }
}
