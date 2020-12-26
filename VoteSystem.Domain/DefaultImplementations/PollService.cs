using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.PollAggregate;
using VoteSystem.Data.Repositories;
using VoteSystem.Domain.Interfaces;

namespace VoteSystem.Domain.DefaultImplementations
{
    public class PollService : IPollService
    {
        IUserRepository _userRepos;
        IRegionRepository _regionRepos;
        IPollRepository _pollRepos;
        public PollService(IUserRepository userRepository, IRegionRepository regionRepository, IPollRepository pollRepository)
        {
            _userRepos = userRepository;
            _regionRepos = regionRepository;
            _pollRepos = pollRepository;
        }

        public bool AddChoiceToPoll(string name, string desc, int pollId)
        {
            var choiceForAdd = CreateChoice(name, desc, pollId);
            //_pollRepos.AddChoiceToPoll(choiceForAdd, pollId);
            return true;
        }

        public Choice CreateChoice(string name, string desc, int pollId)
        {
            var choice = new Choice()
            {
                Name = name,
                Description = desc
            };
            //choice.Poll = _pollRepos.Get(pollId);
            _pollRepos.GetChoices(pollId).Add(choice);
            _pollRepos.CreateChoice(choice, pollId);
            return choice;
        }

        public int CreatePoll(string name, string Desc, int userOwnerId, DateTime start, DateTime end, 
                               bool multipleSelection)
        {
            var poll = new Poll()
            {
                Name = name,
                Description = Desc,
                PollOwnerUserId = userOwnerId,
                PollStartDate = start,
                PollEndDate = end,
                MutlipleSelection = multipleSelection,
                Choices = new List<Choice>()
            };
            return _pollRepos.Create(poll);
        }

        public List<int> GetAllAvailablePollIds(int userId)
        {
            List<int> allpolicies = new List<int>();
            allpolicies.AddRange(_userRepos.GetAllUserPollIdsWithPolicies(userId));
            allpolicies.AddRange(_regionRepos.GetAllPollIdsForRegionPolicies(_userRepos.GetRegionId(userId)));
            return allpolicies;
        }

        public Poll GetPoll(string PollName)
        {
            return _pollRepos.Get(PollName);
        }

        public List<Poll> ShowAllPolls()
        {
            return _pollRepos.GetPolls();
        }
    }
}
