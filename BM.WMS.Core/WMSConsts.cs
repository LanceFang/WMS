namespace BM.WMS
{
    public class WMSConsts
    {
        public const string LocalizationSourceName = "WMS";

        public const int MaxCodeLength = 8;

        public const string MaterielsCodeRegex = "^[A-Z0-9]{8}$";//大写字母与数字

        public const string TelNumber = @"^(\d{3,4}-)?\d{6,8}$";

        public const string PhoneNumber = @"^[1] +[3, 5] +\d{9}";



        public static class SchemaName
        {
            /// <summary>
            /// 基础设置
            /// </summary>
            public const string Basic = "Basic";

            /// <summary>
            /// 模块管理
            /// </summary>
            public const string Moudle = "Moudle";

            /// <summary>
            /// 网站设置
            /// </summary>
            public const string WebSetting = "WebSetting";

            /// <summary>
            /// 用于对多对表关系的结构
            /// </summary>
            public const string HasMany = "HasMany";

            /// <summary>
            /// 业务
            /// </summary>
            public const string Business = "Business";

        }
    }


}