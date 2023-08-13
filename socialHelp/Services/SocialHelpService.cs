using AutoMapper;
using socialHelp.Entities;
using Models = socialHelp.Models;
using socialHelp.Repositories;

namespace socialHelp.Services
{
    public interface ISocialHelpService
    {
        Task<IEnumerable<SocialHelp>> GetAll();
        Task<SocialHelp> GetById(string id);
        Task Create(Models.SocialHelp.RequestCreate model);
        Task CreateBeneficiaries(Models.Beneficiary.RequestCreate model);
        Task DeleteBeneficiaries(string socialHelpId, string UserId);
        //Task Update(string id, UpdateRequest model);
        Task Delete(string id);
    }
    public class SocialHelpService : ISocialHelpService
    {
        private readonly ISocialHelpRepository _socialHelpRepository;
        private readonly IBeneficiaryRepository _beneficiaryRepository;
        private readonly IMapper _mapper;


        public SocialHelpService(ISocialHelpRepository socialHelpRepository, IBeneficiaryRepository beneficiaryRepository, IMapper mapper)
        {
            _socialHelpRepository = socialHelpRepository;
            _beneficiaryRepository = beneficiaryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SocialHelp>> GetAll()
        {
            return await _socialHelpRepository.GetAll();
        }

        public async Task<SocialHelp> GetById(string id)
        {
            SocialHelp socialHelp = await _socialHelpRepository.GetOne(id) ?? throw new KeyNotFoundException("Social Help not found");
            if(socialHelp != null ) {
                IList<Beneficiary> beneficiary = (IList<Beneficiary>)await _beneficiaryRepository.GetAll(socialHelp.Id);
                socialHelp.Beneficiaries = beneficiary;
            }
            return socialHelp;
        }

        public async Task Create(Models.SocialHelp.RequestCreate model)
        {

            SocialHelp country = _mapper.Map<SocialHelp>(model);

            await _socialHelpRepository.Create(country);
        }

        public async Task CreateBeneficiaries(Models.Beneficiary.RequestCreate model)
        {
            SocialHelp socialHelp = await _socialHelpRepository.GetOne(model.SocialHelpId) ?? throw new KeyNotFoundException("Social Help not found");

            string yearActivation = DateTime.Parse(socialHelp.DateActivation.ToString()).Year.ToString();
            string yearExpiration = DateTime.Parse(socialHelp.DateExpiration.ToString()).Year.ToString();
        
            Beneficiary beneficiaryExist = await _beneficiaryRepository.ValidateBeneficiary(model.SocialHelpId, model.UserId, yearActivation, yearExpiration);
            if(beneficiaryExist != null ) throw new KeyNotFoundException("User have active current social help");

            //servicio para validar usuario que exista y la comuna
            Beneficiary beneficiary = _mapper.Map<Beneficiary>(model);

            await _beneficiaryRepository.Create(beneficiary);
        }

        public async Task DeleteBeneficiaries(string socialHelpId, string UserId)
        {
            SocialHelp socialHelp = await _socialHelpRepository.GetOne(socialHelpId) ?? throw new KeyNotFoundException("Social Help not found");

            await _beneficiaryRepository.Delete(socialHelp.Id, UserId);
        }
        //update

        public async Task Delete(string id)
        {
            await _socialHelpRepository.Delete(id);
            await _beneficiaryRepository.DeleteCascade(id);
        }
    }
}