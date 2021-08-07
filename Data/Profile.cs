using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class Profile
    {
        public Profile()
        {

        }
        public string Username
        {
            get
            {
                return CurrentUser.CurUser.UserName;
            }
            set {; }
        }

        public string Login
        {
            get
            {
                return CurrentUser.CurUser.Login;
            }
            set {; }
        }

        public string LangLevel
        {
            get
            {
                return CurrentUser.InfoCurUser.Langlevel;
            }
            set {; }
        }

        public int ProgressId
        {
            get
            {
                return CurrentUser.InfoCurUser.ProgressId;
            }
            set {; }
        }

        public int? TextCount
        {
            get
            {
                return CurrentUser.InfoCurUser.TextCount;
            }

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
