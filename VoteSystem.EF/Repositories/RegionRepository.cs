using System;
using System.Collections.Generic;
using System.Text;
using VoteSystem.Data.Repositories;
using VoteSystem.Data.Entities.RegionPolicyAggregate;
using System.Linq;

namespace VoteSystem.EF.Repositories
{
    class RegionRepository : IRegionRepository
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

        public List<RegionPolicy> GetAllRegionPolicies(int id)
        {
            using (var ctx = new VoteContext())
            {
                return ctx.RegionPolicies.ToList().Where(p => p.Id == id).ToList();
            }
        }
    }
}
