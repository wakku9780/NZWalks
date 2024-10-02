using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext  dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk; 
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {

            var existingWalk=await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool? IsAscending = true,
            int pageNumber = 1, int pageSize = 1000)
        {

            var walks = await dbContext.Walks
                    .Include("Difficulty")
                    .Include("Region")
                    .ToListAsync();
            //filtering 

            // Apply filtering after awaiting the data
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery)).ToList();
                }
            }

            // Sorting perform here

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                bool ascending = IsAscending ?? true; // Default to true if IsAscending is null

                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = ascending ? walks.OrderBy(x => x.Name).ToList() : walks.OrderByDescending(x => x.Name).ToList();

                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = ascending ? walks.OrderBy(x => x.LengthInKm).ToList() : walks.OrderByDescending(x => x.LengthInKm).ToList();

                }  
            }

            //Pagination perform here

            var skippResults = (pageNumber - 1) * pageSize;


            return  walks.Skip(skippResults).Take(pageSize).ToList();
            //return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetById(Guid id)
        {
           return  await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<Walk>> GetByLengthRangeAsync(double minLength, double maxLength)
        {
            // Fetch data from the database
            var walks = await dbContext.Walks
                .Include(w => w.Region)
                .Include(w => w.Difficulty)
                .ToListAsync();

            // Filter data in memory
            return walks
                .Where(w => double.TryParse(w.LengthInKm, out double lengthInKm) &&
                            lengthInKm >= minLength &&
                            lengthInKm <= maxLength)
                .ToList();
        }

        public async Task<List<Walk>> GetByRegionAsync(Guid regionId)
        {
            return await dbContext.Walks
                .Where(w => w.RegionId == regionId)
                .Include(w => w.Region)
                .Include(w => w.Difficulty)
                .ToListAsync();
        }

        public async Task<List<Walk>> GetRecentWalksAsync(int numberOfWalks)
        {
            return await dbContext.Walks
                .OrderByDescending(w => w.CreatedAt)
                .Take(numberOfWalks)
                .Include(w => w.Region)
                .Include(w => w.Difficulty)
                .ToListAsync();
        }


        public async Task<List<Walk>> SearchByNameAsync(string name)
        {
            return await dbContext.Walks
                .Where(w => w.Name.Contains(name))
                .Include(w => w.Region)
                .Include(w => w.Difficulty)
                .ToListAsync();
        }


        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
           
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();

            return existingWalk;


        }
    }
}
