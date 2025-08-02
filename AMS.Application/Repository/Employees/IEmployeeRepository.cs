using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Repository.Employees
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Employee? GetByIdAsync(int id);
        Task<bool> AddAsync(Employee dto);
        Task<bool> UpdateAsync(Employee dto);
        Task<bool> DeleteAsync(Employee asset);
    }
}
