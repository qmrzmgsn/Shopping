using Shopping.DTO;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployees();
        public Task SaveEmployee(Employee employee, Guid empId);
        public Task UpdateEmployeeShop(ShopDTO shop, Guid id);
    }
}
