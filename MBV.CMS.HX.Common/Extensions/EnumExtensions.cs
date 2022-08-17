using System.ComponentModel;

namespace MBV.CMS.HX.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            try
            {
                var enumType = value.GetType();
                var enumValue = Enum.GetName(enumType, value);
                var member = enumType.GetMember(enumValue)[0];
                var attrs = member.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
