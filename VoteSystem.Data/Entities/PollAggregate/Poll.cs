using System;
using System.Collections.Generic;
using System.Text;

namespace VoteSystem.Data.Entities.PollAggregate
{
    public class Poll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PollOwnerUserId { get; set; }
        public DateTime PollStartDate { get; set; }
        public DateTime PollEndDate { get; set; }
        public bool MutlipleSelection { get; set; }
        public List<Choice> Choices { get; set; }
    }
}
