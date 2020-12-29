﻿using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Entities.VoteAggregate;
using System.Linq;

namespace VoteSystem.EF.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        public void Create(Vote vote)
        {
            using (var ctx = new VoteContext())
            {
                ctx.Votes.Add(vote);
                ctx.SaveChanges();
            }
        }

        public void CreateVoteChoice(VoteChoice voteChoice)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                voteContext.Votes.Attach(voteChoice.Vote);
                voteContext.Entry(voteChoice.Vote).State = System.Data.Entity.EntityState.Unchanged;
                voteContext.VoteChoices.Add(voteChoice);
                voteContext.SaveChanges();
            }
        }

        public bool IsVoted(int userId, string pollName)
        {
            using (var ctx = new VoteContext())
            {
                var resp = (from v in ctx.Votes
                           join vc in ctx.VoteChoices on v.Id equals vc.Vote.Id
                           join c in ctx.Choices on vc.choiceId equals c.Id
                           join p in ctx.Polls on c.Poll.Id equals p.Id
                           where v.UserId == userId && p.Name == pollName
                            select new  { UserId = v.UserId }).ToList();

                if (resp.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        //public List<Vote> GetAllForUser(int userId)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Vote> GetAllForUser(int userId)
        {
            using (var ctx = new VoteContext())
            {
                return ctx.Votes.Where(u => u.UserId == userId).ToList();
            }
        }
        public Dictionary<int, int> GetResultInVote(int voteId)
        {
            throw new NotImplementedException();
        }

        public Vote GetVote(int voteId)
        {
            using (var ctx = new VoteContext())
            {
                Vote vote = ctx.Votes.FirstOrDefault(vote => vote.Id == voteId);
                if (vote == null)
                    return null;
                return vote;
            }
        }

        public void Update(Vote vote)
        {
            throw new NotImplementedException();
        }
        //        public void Update(Vote vote)
        //        {
        //            using (var ctx = new VoteContext())
        //            {
        //               ctx.Votes.FirstOrDefault(vote => vote.Id == vote.Id).voteStart = vote.voteStart;
        //                ctx.Votes.FirstOrDefault(vote => vote.Id == vote.Id).voteEnd = vote.voteEnd;
        //                ctx.Votes.FirstOrDefault(vote => vote.Id == vote.Id).choiceId = vote.choiceId;
        //            }
        //        }

        public bool ExistingUser(int userId)
        {
            using (var ctx = new VoteContext())
            {
                return ctx.Votes.Any(u => u.UserId == userId);
            }
        }
        //public List<VoteChoice> GetVoteChoices(int choiceId)
        //{ 
            
        //}
    }
}
