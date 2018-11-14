using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPal.Entities
{
    public class Production : BaseEntity
    {
        public string ProductionNumber { get; set; }

        public DateTime ProductionDate { get; set; }

        public string Breakage { get; set; }

        public string NoOfMouldsCasted { get; set; }

        public string Remark { get; set; }

        public List<ProductionDetails> ProductionDetails { get; set; }
    }
}
