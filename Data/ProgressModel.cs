using Project.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class ProgressModel
    {
        public ProgressModel()
        {

        }
        public int? TextCount
        {
            get
            {
                return CurrentUser.InfoCurUser.TextCount;
            }
            set {; }
        }
        public int? RuleCount
        {
            get
            {
                return CurrentUser.InfoCurUser.RuleCount;
            }
            set {; }
        }
        public int? WordCount
        {
            get
            {
                return CurrentUser.InfoCurUser.WordCount;
            }
            set {; }
        }


    }
}
