using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.PolicyStatus
{
    public class PolicyStatusRequest
    {
        public class PolicyStatus
        {
            public int ID { get; set; }
            public string ProductNo { get; set; }
            public string ProposalNo { get; set; }
            public string RenewalNo { get; set; }
            public string EndorsNo { get; set; }
            public string Response { get; set; }
        }
    }
}
