using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using location.Entities;
using location.Models.Region;
using location.Repositories;
using users.Helpers;

namespace location.Services
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> GetAll();
        Task<Region> GetById(string id);
        Task Create(CreateRequest model);
        //Task Update(string id, UpdateRequest model);
        Task Delete(string id);
    }
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICommuneRepository _communeRepository;

        private readonly IMapper _mapper;

        public RegionService(IRegionRepository regionRepository, ICountryRepository countryRepository, ICommuneRepository communeRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _countryRepository = countryRepository;
            _communeRepository = communeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await _regionRepository.GetAll();
        }

        public async Task<Region> GetById(string id)
        {
            Region region = await _regionRepository.GetOne(id) ?? throw new KeyNotFoundException("Region not found");
            if(region != null ) {
                IList<Commune> communes = (IList<Commune>)await _communeRepository.GetByRegionId(region.Id);
                region.Communes = communes;
            }
            return region;
        }
        public async Task Create(CreateRequest model)
        {
            Country country = await _countryRepository.GetOne(model.CountryId) ?? throw new AppException("Country Id '" + model.CountryId + "' not exists");

            Region region = _mapper.Map<Region>(model);

            await _regionRepository.Create(region);
        }

        //update

        public async Task Delete(string id)
        {
            await _regionRepository.Delete(id);
        }
    }
}