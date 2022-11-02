using Dapper;
using Shopping.Data;
using Shopping.DTO;
using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Repository
{
    public class Repository : IRepository
    {
        private readonly DapperContext _context;
        public Repository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            string sqlQuery = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(sqlQuery);
                return employees.ToList();
            }
        }

        public async Task SaveEmployee(Employee employee, Guid empId)
        {
            string sqlQuery = "INSERT into Employee (EmployeeId, Name, TypeId) values (@empId, @Name, @TypeId)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", employee.EmployeeName, DbType.String);
            parameters.Add("TypeId", employee.TypeId, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                var r = await connection.ExecuteAsync(sqlQuery, parameters);
                Console.Write(r);
            }
        }

        public async Task UpdateEmployeeShop(ShopDTO shop, Guid id)
        {
            string sqlQuery = "UPDATE Shop SET Name = @Name, Address = @Address, PhoneNumber = @PhoneNumber WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Name", shop.Name, DbType.String);
            parameters.Add("Address", shop.Address, DbType.String);
            parameters.Add("PhoneNumber", shop.PhoneNumber, DbType.String);
            parameters.Add("Id", id, DbType.Guid);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }
    }
}
