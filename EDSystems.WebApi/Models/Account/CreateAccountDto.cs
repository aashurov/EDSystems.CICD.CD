using AutoMapper;
using EDSystems.Application.Common.Mappings;
using EDSystems.Application.EDSystems.Commands.Accounts.CreateAccount;

namespace EDSystems.WebApi.Models.Account
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAccountDto : IMapWith<CreateAccountCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BranchId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAccountDto, CreateAccountCommand>()
                .ForMember(createAccountCommand => createAccountCommand.Name,
                    options => options.MapFrom(createAccountDto => createAccountDto.Name))
                .ForMember(createAccountCommand => createAccountCommand.Number,
                    options => options.MapFrom(createAccountDto => createAccountDto.Number))
                .ForMember(createAccountCommand => createAccountCommand.Balance,
                    options => options.MapFrom(createAccountDto => createAccountDto.Balance))
                .ForMember(createAccountCommand => createAccountCommand.BranchId,
                    options => options.MapFrom(createAccountDto => createAccountDto.BranchId))
            .ForMember(createAccountCommand => createAccountCommand.CurrencyId,
                    options => options.MapFrom(createAccountDto => createAccountDto.CurrencyId));
        }
    }
}