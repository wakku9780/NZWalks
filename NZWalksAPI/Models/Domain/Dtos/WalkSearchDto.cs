namespace NZWalksAPI.Models.Domain.Dtos
{
    public class WalkSearchDto
    {


        public string? Name { get; set; }

        // Optional filter for Minimum Length in Km
        public double? MinLength { get; set; }

        // Optional filter for Maximum Length in Km
        public double? MaxLength { get; set; }

        // Optional filter for DifficultyId (can be null)
        public Guid? DifficultyId { get; set; }

        // Optional filter for RegionId (can be null)
        public Guid? RegionId { get; set; }
    }


}
