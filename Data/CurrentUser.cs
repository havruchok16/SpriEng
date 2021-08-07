using Project.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public static class CurrentUser
    {
        public static User CurUser { get; set; }
        public static Info InfoCurUser { get; set; }
    }
}
