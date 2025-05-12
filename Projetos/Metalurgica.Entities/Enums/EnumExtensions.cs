using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalurgica.Entities.Enums
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum valor)
        {
            var fi = valor.GetType().GetField(valor.ToString());
            var attr = (DescriptionAttribute?)
                       Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            return attr?.Description ?? valor.ToString();
        }
    }
}
