using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    class PolicyInfo : IPolicyInfo
    {
        IUserRepository _userRepos;
        IRegionRepository _regionRepos;
        public PolicyInfo(IUserRepository userRepository, IRegionRepository regionRepository)
        {
            _userRepos = userRepository;
            _regionRepos = regionRepository;
        }
        public List<int> GetAllPolicies(int userId)
        {
            List<int> allpolicies = new List<int>();
            allpolicies.AddRange(_userRepos.GetAllUserPollIdsWithPolicies(userId));
            allpolicies.AddRange(_regionRepos.GetAllPollIdsForRegionPolicies(_userRepos.GetRegionId(userId)));
            return allpolicies;
        }
    }
}
