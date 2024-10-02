using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.Domain.Dtos
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage="Code has to be a minimum of 3 ccccharacters")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }

    }
}
