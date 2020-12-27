using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Entities.PollAggregate;

namespace VoteSystem.Domain.Interfaces
{
    public interface IPollService
    {
        List<int> GetAllAvailablePollIds(int userId);
        int CreatePoll(string Name, string Desc, int userOwnerId, 
                        DateTime start, DateTime end, bool MultipleSelection);
        bool AddChoiceToPoll(string name, string desc, int pollId);
        Choice CreateChoice(string name, string desc, int pollId);
        Poll GetPoll(string PollName);
        List<Choice> GetChoices (string pollName);
    }
}
