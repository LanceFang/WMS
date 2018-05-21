using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.AutoMapper;
using BM.WMS.Localization.Dto;

namespace BM.WMS.Web.Areas.SystemInfo.Models.Languages
{
    [AutoMapFrom(typeof(GetLanguageForEditOutput))]
    public class CreateOrEditLanguageModalViewModel : GetLanguageForEditOutput
    {
        public bool IsEditMode
        {
            get { return Language.Id.HasValue; }
        }

        public CreateOrEditLanguageModalViewModel(GetLanguageForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}