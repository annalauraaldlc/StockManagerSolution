namespace StockManager.Gateway.Infra
{
    public class TenantRepository : ITenantRepository
    {
        public object? GetByNameAsync(string tenantName)
        {
            switch (tenantName)
            {
                case "dealer-1":
                    return new { Name = "dealer-1", ConnStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Dealer1DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" };
                case "dealer-2":
                    return new { Name = "dealer-2", ConnStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Dealer2DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" };
                default:
                    return null;
            }
        }
    }
}
