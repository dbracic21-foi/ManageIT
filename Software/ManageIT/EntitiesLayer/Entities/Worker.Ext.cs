using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public partial class Worker
    {
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
