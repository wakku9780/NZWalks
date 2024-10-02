using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public Task<Region?> Create(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>()
            {
                new Region()
                {
                    Id=Guid.NewGuid(),
                    Code="Some Random Region",
                    Name="Some some some"

                }

            };
        }

        public Task<Region?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> Update(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
