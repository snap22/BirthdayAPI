using AutoMapper;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Domain.Entities;
using Profile = BirthdayAPI.Core.Domain.Entities.Profile;

namespace BirthdayAPI.Core.Service.Profiles
{
    public class PasswordConverter : AutoMapper.IValueConverter<string, string>
    {
        public string Convert(string sourceMember, ResolutionContext context)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(sourceMember);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }
    }

    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>()
                .ForMember(x => x.Password, opt => opt.ConvertUsing<PasswordConverter, string>())
                .ForMember(x => x.DateCreated, 
                            opt => opt.MapFrom(src => (src.DateCreated.ToShortDateString())));

            CreateMap<AccountDto, Account>()
                .ForMember(x => x.AccountId, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForSourceMember(s => s.DateCreated, opt => opt.DoNotValidate());

            CreateMap<Profile, ProfileDto>();
            CreateMap<ProfileDto, Profile>().ForMember(x => x.ProfileId, opt => opt.Ignore());

            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>().ForMember(x => x.ContactId, opt => opt.Ignore());

            CreateMap<Gift, GiftDto>();
            CreateMap<GiftDto, Gift>().ForMember(x => x.GiftId, opt => opt.Ignore());

            CreateMap<Note, NoteDto>();
            CreateMap<NoteDto, Note>().ForMember(x => x.NoteId, opt => opt.Ignore());
        }
    }
}
