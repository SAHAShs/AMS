using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Service.Employees
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();
        Employee? GetByIdAsync(int id);
        Task<bool> AddAsync(Employee dto);
        Task<bool> UpdateAsync(int id, Employee dto);
        Task<bool> DeleteAsync(int id);
    }
}
