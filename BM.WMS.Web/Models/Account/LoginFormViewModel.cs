namespace BM.WMS.Web.Models.Account
{
    public class LoginFormViewModel
    {
        public string TenancyName { get; set; }


        public string ReturnUrl { get; set; }

        public bool IsMultiTenancyEnabled { get; set; }
    }
}