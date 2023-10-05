using Sales.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Repository.Queries.Customers
{
    public interface ICustomerByIdQueriesRepository
    {
        Customer GetCustomerById(int clientId);
    }
}
