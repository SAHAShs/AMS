using AMS.Application.Repository.Employees;
using AMS.Domain.Entities;
using AMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AMSDbContext _context;

        public EmployeeRepository(AMSDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Employee dto)
        {
            try
            {

                await _context.employees.AddAsync(dto);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception e)
            {
            
            }
            return true;
        }

        public async Task<bool> DeleteAsync(Employee emp)
        {
            _context.employees.Remove(emp); //imp to note:- Remove is synchronous, you cant make it await
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.employees.AsNoTracking().Include(c => c.AssignedAssets).AsNoTracking().ToListAsync();
        }

        public Employee? GetByIdAsync(int id)
        {
            return _context.employees.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync( Employee updatedEmployee)
        {
            _context.employees.Update(updatedEmployee);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
