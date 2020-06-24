using SompoPolicyCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCore;

namespace SompoPolicyCore.Class
{
    public class PolicyStatusRequestUpdater : IPolicyStatusRequestUpdater
    {
        public void UpdateResponeByID(int id, string response)
        {
            using (SompoAssesmentEntities DbConn = new SompoAssesmentEntities())
            {
                PolicyStatusRequest policyStatusRequest = DbConn.PolicyStatusRequests.Find(id);
                policyStatusRequest.Response = response;
                DbConn.SaveChanges();
            }
        }
    }
}
