﻿namespace NZWalksAPI.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public string  MinLength { get; set; }
        public string MaxLength { get; set; } = "0";

        public DateTime CreatedAt { get; set; }


        public Guid DifficultyId { get; set; } 
        public Guid RegionId { get; set; }



        // Navigation Property

        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }



    }
}
