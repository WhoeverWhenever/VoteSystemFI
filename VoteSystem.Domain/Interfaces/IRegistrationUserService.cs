using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Domain.Interfaces
{
    interface IRegistrationUserService
    {
        bool ValidateUser(string PaspCode, int IndefCode);
        bool RegistrateUser(string Name, string Surname, string Email, string password, string RegionName);
    }
}
