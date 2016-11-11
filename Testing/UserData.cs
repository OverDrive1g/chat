using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [Serializable]
    class UserData
    {
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }
    }
}
