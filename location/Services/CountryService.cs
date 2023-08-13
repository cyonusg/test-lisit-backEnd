using AutoMapper;
using location.Entities;
using location.Models.Country;
using location.Repositories;

namespace location.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAll();
        Task<Country> GetById(string id);
        Task Create(CreateRequest model);
        //Task Update(string id, UpdateRequest model);
        Task Delete(string id);
    }
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IRegionRepository regionRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _countryRepository.GetAll();
        }

        public async Task<Country> GetById(string id)
        {
            Country country = await _countryRepository.GetOne(id) ?? throw new KeyNotFoundException("Country not found");
            if(country != null ) {
                IList<Region> regions = (IList<Region>)await _regionRepository.GetByCountryId(country.Id);
                country.Regions = regions;
            }
            return country;
        }
        public async Task Create(CreateRequest model)
        {

            Country country = _mapper.Map<Country>(model);

            await _countryRepository.Create(country);
        }

        //update

        public async Task Delete(string id)
        {
            await _countryRepository.Delete(id);
        }
    }
}