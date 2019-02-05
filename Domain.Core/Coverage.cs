using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public class Coverage
    {
        public string months_insured { get; set; }
        public string has_coverage { get; set; }
        public string type { get; set; }
        public int bodilyinjury_person { get; set; }
        public int bodilyinjury_accident { get; set; }
        public int deductible { get; set; }
        public int propertydamage { get; set; }
        public string expiration_date { get; set; }
        public int expiration_days_remaining { get; set; }
        public string dtgExpirationDate { get; set; }
        public string former_insurer { get; set; }
    }
}
