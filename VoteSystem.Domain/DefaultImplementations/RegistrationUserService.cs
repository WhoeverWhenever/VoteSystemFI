using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    class RegistrationUserService : IRegistrationUserService
    {
        IVoteRepository _voteRepos;
        IRegionRepository _regionRepos;
        IUserRepository _userRepos;
        IContextRegistration _contextRegistration;
        public RegistrationUserService(IContextRegistration contextRegistration,  IVoteRepository voteRepository, IRegionRepository regionRepository, IUserRepository userRepository)
        {
            _voteRepos = voteRepository;
            _regionRepos = regionRepository;
            _userRepos = userRepository;
            _contextRegistration = contextRegistration;
        }
        public bool RegistrateUser(string Name, string Surname, string Email, string password, string RegionName)
        {
            string PaspCode = _contextRegistration.GetPassportInfo()[0];
            int IndefCode = Int32.Parse(_contextRegistration.GetPassportInfo()[1]);
            var user = _userRepos.GetUser(PaspCode, IndefCode);
            user.Name = Name;
            user.Surname = Surname;
            user.Email = Email;
            user.Password = password;
            user.RegionId = _regionRepos.GetRegiondIdByName(RegionName);
            _userRepos.CreateUser(user);
            return true;
        }
        public bool ValidateUser(string PaspCode, int IndefCode)
        {
            return _userRepos.UserExists(PaspCode, IndefCode);
        }
    }
}
