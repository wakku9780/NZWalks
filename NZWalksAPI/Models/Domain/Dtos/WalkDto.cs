namespace NZWalksAPI.Models.Domain.Dtos
{
    public class WalkDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        // Changed to double to match the actual length type
        public double LengthInKm { get; set; }

        // Nullable, as per your current definition
        public string? WalkImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        // Region and Difficulty DTOs for relationship mapping
        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }

        // Add the MaxLength property to match your database schema
        public double MaxLength { get; set; }
    }
}
