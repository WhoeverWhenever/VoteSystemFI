using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using VoteSystem.Data.Entities.VoteAggregate;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    public class VoteService : IVoteService
    {
        IVoteRepository _voteRepos;
        IPollRepository _pollRepos;
        public VoteService(IVoteRepository voteRepository, IPollRepository pollRepository)
        {
            _pollRepos = pollRepository;
            _voteRepos = voteRepository;
        }
        public Vote Vote(int userId, int Idchoice)
        {
            var votechoice = new VoteChoice()
            {
                choiceId = Idchoice
            };
            var vote = new Vote()
            {
                UserId = userId,
                VoteDate = DateTime.Now,
                VoteChoices = new List<VoteChoice>()
            };

            vote.VoteChoices.Add(votechoice);
            _voteRepos.Create(vote);
            return vote;
        }
        public bool CheckVote(int userId, string pollName)
        {
            foreach (var a in _voteRepos.GetAllForUser(userId))
            {
                if (a.Id == )
                {

                }
            }

            return true;
        }
    }
}
