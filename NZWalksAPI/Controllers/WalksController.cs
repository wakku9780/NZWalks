using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.Domain.Dtos;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }



        //create walk
        //post:/api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {

            //Map Dto to Domain Models
            // mapper.Map<Walk>(source)
            var WalkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(WalkDomainModel);

            //MapDomain model into Dto Beacuse Sending back to the client
            return Ok(mapper.Map<WalkDto>(WalkDomainModel));


        }

        //GET walks
        //GET:/api/walks

        [HttpGet]

        public async Task<IActionResult> GetAllAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? IsAscending,
            [FromQuery]int pageNumber = 1, [FromQuery] int pageSize=1000)
        {

            var WalksDomainModel = await walkRepository.GetAllAsync(filterOn,filterQuery,sortBy,IsAscending??true,
                pageNumber,pageSize);

            return Ok(mapper.Map<List<WalkDto>>(WalksDomainModel));
        }

        //Get: Walk By Id
        //GET:/api/walks/

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var WalkDomainModel = await walkRepository.GetById(id);

            if(WalkDomainModel== null)
            {
                return NotFound();
            }

            //Map Domain Model to Dto

            return Ok(mapper.Map<WalkDto>(WalkDomainModel));



        }

        //Update walk  by id
        //PUT: /api/Walks/{id}
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdateWalkRequestDto updateWalkRequestDto)

        {

            //Map DTO to Domain Model

            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel= await walkRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model To Dto


            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }


        //Delete a walk by id
        // DELETE:/api/walks/{id}

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {


            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            //Map domain to dto

            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));  



        }

        //Search Walks by Name
        // GET: /api/walks/search/{name}

        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchByName([FromRoute] string name)
        {
            var walksDomainModel = await walkRepository.SearchByNameAsync(name);

            if(walksDomainModel==null || !walksDomainModel.Any())
            {
                return NotFound("No walks found with the given name.");
            }

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        // GET: /api/walks/filterByLength?minLength=1&maxLength=10

        [HttpGet("filterByLength")]

        public async Task<IActionResult> FilterbyLengthAsync([FromQuery] double minLength, [FromQuery] double maxLength)
        {
            var walks = await walkRepository.GetByLengthRangeAsync(minLength, maxLength);
            return Ok(mapper.Map<List<WalkDto>>(walks));
        }



        // GET: /api/walks/region/{regionId}

        [HttpGet("region/{regionId:Guid}")]

        public async Task<IActionResult> GetByRegion([FromRoute] Guid regionId )
        {
            var walksInRegion =await walkRepository.GetByRegionAsync(regionId);

            if (!walksInRegion.Any())
            {

                return NotFound("No walks found in the specified region.");

            }

            return Ok(mapper.Map<List<WalkDto>>(walksInRegion));
        }



        [HttpGet("recent/{numberOfWalks}")]
        public async Task<IActionResult> GetRecentWalks([FromRoute] int numberOfWalks)
        {
            // Fetch recent walks from the repository
            var recentWalksDomain = await walkRepository.GetRecentWalksAsync(numberOfWalks);

            // Check if there are any recent walks
            if (recentWalksDomain == null || recentWalksDomain.Count == 0)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            var recentWalksDto = mapper.Map<List<WalkDto>>(recentWalksDomain);

            // Return the DTOs
            return Ok(recentWalksDto);
        }










    }
}
