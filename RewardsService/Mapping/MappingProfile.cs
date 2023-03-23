using AutoMapper;
using RewardsService.DTO.Forms;
using RewardsService.DTO.Read;
using RewardsService.DTO.Read.Forms;
using RewardsService.DTO.Write;
using RewardsService.DTO.Write.Forms;
using RewardsService.Models;
using RewardsService.Models.Forms;

namespace RewardsService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            TwoWay<CriteriaDTO, Criteria>();
            TwoWay<CriteriasCollectionDTO, CriteriasCollection>();
            TwoWay<SubfieldDTO, Subfield>();

            CreateMap<CreateForm, Form>();
            CreateMap<Form, ReadForm>();

            CreateMap<CreateFormField, FormField>();
            CreateMap<FormField, ReadFormField>();

            CreateMap<CreateReward, RewardModel>();
            CreateMap<RewardModel, ReadReward>().ForMember(x => x.Form, opt => opt.Ignore());

        }

        protected virtual void TwoWay<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
