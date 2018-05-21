using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BM.WMS.Customerses.Dtos;
using BM.WMS.Dto;

namespace BM.WMS.Customerses
{
    /// <summary>
    /// 客户资料管理的数据导出功能 
    /// </summary>
    public interface ICustomersListExcelExporter
    {
        //## 可以将下面的这个实体类，作为filedto来进行接收 
        //public class FileDto
        //{
        //    [Required]
        //    public string FileName { get; set; }

        //    [Required]
        //    public string FileType { get; set; }

        //    [Required]
        //    public string FileToken { get; set; }

        //    public FileDto()
        //    {

        //    }

        //    public FileDto(string fileName, string fileType)
        //    {
        //        FileName = fileName;
        //        FileType = fileType;
        //        FileToken = Guid.NewGuid().ToString("N");
        //    }
        //}

        /// <summary>
        /// 导出客户资料管理到EXCEL文件
        /// <param name="customersListDtos">导出信息的DTO</param>
        /// </summary>
        FileDto ExportCustomersToFile(List<CustomersListDto> customersListDtos);



    }
}
