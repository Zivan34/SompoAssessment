using SompoPolicyCore.Interface;
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
