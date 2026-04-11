using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronolibris.Domain.SystemConstants
{
    public static class ShelfTypes
    {
        public const string FAVORITES = "FAVORITES";
        public const string READ = "READ";
        public const string CUSTOM = "CUSTOM";

        public const long FAVORITES_CODE = 1;
        public const long READ_CODE = 2;
        public const long CUSTOM_CODE = 3;
    }
}
