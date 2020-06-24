namespace SompoPolicyCore.Interface
{
    public interface IPolicyStatusRequestWriter
    {
        int SavePolicyStatus(BussinessObjects.SompoAPI.Request.PolicyInfo policystatus);
    }
}
