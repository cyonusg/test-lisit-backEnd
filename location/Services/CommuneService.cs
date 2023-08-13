using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using location.Entities;
using location.Models.Commune;
using location.Repositories;
using users.Helpers;

namespace location.Services
{
    public interface ICommuneService
    {
        Task<IEnumerable<Commune>> GetAll();
        Task<Commune> GetById(string id);
        Task Create(CreateRequest model);
        //Task Update(string id, UpdateRequest model);
        Task Delete(string id);
    }
    public class CommuneService : ICommuneService
    {
        private readonly ICommuneRepository _communeRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public CommuneService(ICommuneRepository communeRepository, IRegionRepository regionRepository, IMapper mapper)
        {
            _communeRepository = communeRepository;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Commune>> GetAll()
        {
            return await _communeRepository.GetAll();
        }

        public async Task<Commune> GetById(string id)
        {
            Commune Commune = await _communeRepository.GetOne(id) ?? throw new KeyNotFoundException("Country not found");
            return Commune;
        }
        public async Task Create(CreateRequest model)
        {
            Region region = await _regionRepository.GetOne(model.RegionId) ?? throw new AppException("Region Id '" + model.RegionId + "' not exists");

            Commune commune = _mapper.Map<Commune>(model);

            await _communeRepository.Create(commune);
        }

        //update

        public async Task Delete(string id)
        {
            await _communeRepository.Delete(id);
        }
    }
}