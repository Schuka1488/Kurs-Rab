using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization
{
    class Username
    {
        private string _userName;
        private int role;
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

        public int Role
        {
            get => role;
        }
        public Username() { }

        public Username(string user, int role)
        {
            this.role = role;
            user1 = this;
            _userName = user;
        }
    }
}
