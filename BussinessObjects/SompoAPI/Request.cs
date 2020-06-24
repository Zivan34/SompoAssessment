using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.SompoAPI
{
    public class Request
    {
        public class PolicyStatusRequest
        {
            public Authentication Authentication { get; set; }
            public PolicyInfo Object { get; set; }
        }
        public class PolicyInfo
        {
            public string ProposalNo { get; set; }
            public string RenewalNo { get; set; }
            public string EndorsNo { get; set; }
            public string ProductNo { get; set; }
        }
        public class Authentication
        {
            public string Source { get; set; }
            public string Key { get; set; }
            public Authentication()
            {
                this.Source = "SOMPO";
                this.Key = "77lTCSn41w";
            }
        }
    }
}
