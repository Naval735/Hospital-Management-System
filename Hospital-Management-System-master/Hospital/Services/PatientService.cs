using Hospital.Interfaces;
using Hospital.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
        }

        public async Task UpdateAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
        }

        public async Task DeleteAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }
    }
}