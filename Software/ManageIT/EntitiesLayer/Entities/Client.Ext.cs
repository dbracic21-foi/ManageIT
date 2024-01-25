using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public partial class Client
    {
        public override string ToString()
        {
            return ClientType?.Title ?? "No ClientType";
        }
    }
}
