using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Entities.RegionPolicyAggregate;
using System.Linq;

namespace VoteSystem.EF.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        public void CreateRegion(Region region)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                voteContext.Regions.Add(region);
                voteContext.SaveChangesAsync();
            }
        }

        public void UpdateRegion(Region region)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                Region regiontemp = voteContext.Regions.FirstOrDefault(r => r.Id == region.Id);
                regiontemp = region;
                voteContext.SaveChangesAsync();
            }
        }
        public Region Get(int id)
        {
            using (var ctx = new VoteContext())
            {
                return ctx.Regions.FirstOrDefault(p => p.Id == id);
            }
        }
        public int GetRegiondIdByName(string name)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                return voteContext.Regions.FirstOrDefault(r => r.Name == name).Id;
            }
        }

        public List<int> GetAllPollIdsForRegionPolicies(int id)
        {
            using (VoteContext voteContext = new VoteContext())
            {
                List<RegionPolicy> regionPolicies = voteContext.RegionPolicies.Where(p => p.Region.Id == id).ToList();
                List<int> outlist = new List<int>();
                foreach (var a in regionPolicies)
                {
                    outlist.Add((a.PollId).Value);
                }
                return outlist;
            }
        }
    }
}
