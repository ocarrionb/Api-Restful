namespace Sales.Repository.Queries.Customers
{
    public interface ICustomerUniqueQueriesRepository
    {
        bool IsUniqueCustomer(string name);
    }
}
