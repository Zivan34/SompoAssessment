using SompoPolicyCore.Interface;
using DataCore;

namespace SompoPolicyCore.Class
{
    public class PolicyStatusRequestWriter : IPolicyStatusRequestWriter
    {
        public int SavePolicyStatus(BussinessObjects.SompoAPI.Request.PolicyInfo policystatus)
        {
            using (SompoAssesmentEntities DbConn = new SompoAssesmentEntities())
            {
                PolicyStatusRequest policyStatusRequest = new PolicyStatusRequest()
                {
                    EndorsNo = policystatus.EndorsNo,
                    ProductNo = policystatus.ProductNo,
                    ProposalNo = policystatus.ProposalNo,
                    RenewalNo = policystatus.RenewalNo,
                    Response = null
                };

                DbConn.PolicyStatusRequests.Add(policyStatusRequest);
                DbConn.SaveChanges();

                return policyStatusRequest.ID;
            }
        }
    }
}
