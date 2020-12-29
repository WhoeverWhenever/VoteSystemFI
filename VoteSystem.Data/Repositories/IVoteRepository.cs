using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoteSystem.Data.Entities.VoteAggregate;

namespace VoteSystem.Data.Repositories
{
    public interface IVoteRepository
    {
        void Create(Vote vote);
        void CreateVoteChoice(VoteChoice voteChoice);
        bool IsVoted(int userId, string pollName);
        void Update(Vote vote);
        Vote GetVote(int voteId);
        List<Vote> GetAllForUser(int userId);
        Dictionary<int, int> GetResultInVote(int voteId);
        public bool ExistingUser(int userId);
    }
}
