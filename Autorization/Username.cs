using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization
{
    class Username
    {
        private static string _userName;
        private static int edit_access;
        public string userName
        {
            get
            {
                return _userName;
            }

            set
            {
                if (userName != "")
                {
                    _userName = userName;
                }
            }
        }

        public static Username user1;

        public int Edit_access
        {
            get => edit_access;
        }
        public Username() { }

        public Username(string user, int edit_access)
        {
            user1 = this;
            _userName = user;
        }
    }
}
