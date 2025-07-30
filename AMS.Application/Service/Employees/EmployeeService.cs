using AMS.Application.Repository.Category;
using AMS.Application.Repository.Employees;
using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Service.Employees
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> AddAsync(Employee dto)
        {
            return await _employeeRepository.AddAsync(dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var asset = _employeeRepository.GetByIdAsync(id);
            if (asset == null)
                return false;


            await _employeeRepository.DeleteAsync(asset);
            return true;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public Employee? GetByIdAsync(int id)
        {
            return _employeeRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Employee dto)
        {
            var asset = _employeeRepository.GetByIdAsync(id);
            if (asset == null)
                return false;


            await _employeeRepository.UpdateAsync(id, asset);
            return true;
        }
    }
}
