using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMaintenance.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get
            {
                return string.Format(
                "{0} {1}",
                LastName,
                FirstName); //ezzel a megoldással az itt felsorolt változók azonosítókkal behívhatók ({0}, {1})
            }               //      -> átláthatóbb lesz a formázás
        }

    }
}
