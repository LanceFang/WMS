using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BM.WMS.Dto;
using BM.WMS.Localization.Dto;

namespace BM.WMS.Localization
{
    public interface ILanguageAppService : IApplicationService
    {
        Task<PagedResultOutput<ApplicationLanguageListDto>> GetLanguages();

        Task<string> GetDefaultLanguage();

        Task<GetLanguageForEditOutput> GetLanguageForEdit(NullableIdDto input);

        Task CreateOrUpdateLanguage(CreateOrUpdateLanguageInput input);

        Task DeleteLanguage(EntityDto input);

        Task SetDefaultLanguage(SetDefaultLanguageInput input);

        Task<PagedResultOutput<LanguageTextListDto>> GetLanguageTexts(GetLanguageTextsInput input);

        Task UpdateLanguageText(UpdateLanguageTextInput input);
    }
}
