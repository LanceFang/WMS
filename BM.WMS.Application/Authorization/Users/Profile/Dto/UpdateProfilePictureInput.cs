using Abp.Application.Services.Dto;

namespace BM.WMS.Authorization.Users.Profile.Dto
{
    public class UpdateProfilePictureInput 
    {
        public string FileName { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}