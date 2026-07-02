using Hospital.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllAsync();

        Task<Patient> GetByIdAsync(int id);

        Task CreateAsync(Patient patient);

        Task UpdateAsync(Patient patient);

        Task DeleteAsync(int id);
    }
}