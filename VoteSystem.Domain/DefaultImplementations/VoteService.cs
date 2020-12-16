using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.UserPolicyAggregate;
using VoteSystem.Data.Entities.VoteAggregate;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    class VoteService : IVoteService
    {
        IVoteRepository _voteRepos;
        public VoteService(IVoteRepository voteRepository)
        {
            _voteRepos = voteRepository;
        }
        public Vote Vote(User user, int Idchoice)
        {
            var votechoice = new VoteChoice()
            {
                choiceId = Idchoice
            };
            var vote = new Vote()
            {
                UserId = user.Id,
                VoteDate = DateTime.Now
            };
            vote.VoteChoices.Add(votechoice);
            _voteRepos.Create(vote);
            return vote;
        }
    }
}
