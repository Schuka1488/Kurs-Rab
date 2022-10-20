using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization
{
    class Username
    {
        
        private int role;
        public static Username user1;
        public int Role
        {
            get => role;
        }
        public Username(int role)
        {
            this.role = role;
            user1 = this; 
        }
    }
}
