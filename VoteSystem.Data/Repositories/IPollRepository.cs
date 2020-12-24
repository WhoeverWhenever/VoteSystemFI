using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.PollAggregate;

namespace VoteSystem.Data.Repositories
{
    public interface IPollRepository
    {
        void Create(Poll poll);
        void CreateChoice(Choice choice, int pollId);
        List<Choice> GetChoices(int pollId);
        void AddChoiceToPoll(Choice choice, int pollId);
        void Update(Poll poll);
        Poll Get(int id);
        Poll Get(string pollName);
        List<Poll> GetPolls(int id);
        string[] GetPollDetails(int id);
        Choice GetChoice(int choiceId);
    }
}
