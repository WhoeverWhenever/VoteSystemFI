using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using System.Linq;

namespace VoteSystem.EF.Repositories
{
    class UserRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                voteContext.Users.Add(user);
                voteContext.SaveChangesAsync();
            }
        }
        public bool UserExists(string paspCode, int IndefCode)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.FirstOrDefault(u => u.PassportCode == paspCode).IdentificationCode == IndefCode;
            }
        }

        public List<User> GetAllUsersForRegion(int regionId)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.ToList().Where(u => u.RegionId == regionId).ToList();
            }
        }

        public bool IsInRegion(int regionId, int userId)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.FirstOrDefault(u => u.Id == userId).RegionId == regionId;
            }
        }

        public void UpdateUser(User user)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                User usertemp = voteContext.Users.FirstOrDefault(u => u.Id == user.Id);
                usertemp = user;
                voteContext.SaveChangesAsync();
            }
        }

        public List<UserPolicy> GetAllUserPolicies()
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.UserPolicies.ToList();
            }
        }
        public User GetUser(string PaspCode, int IndefCode)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Users.
                    FirstOrDefault(p => (p.PassportCode == PaspCode) && (p.IdentificationCode == IndefCode));
            }
        }
    }
}
