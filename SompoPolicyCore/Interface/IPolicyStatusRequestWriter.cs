using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SompoPolicyCore.Interface
{
    public interface IPolicyStatusRequestWriter
    {
        int SavePolicyStatus(BussinessObjects.SompoAPI.Request.PolicyInfo policystatus);
    }
}
