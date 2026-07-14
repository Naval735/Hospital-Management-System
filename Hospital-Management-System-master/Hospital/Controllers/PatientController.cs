using Hospital.Interfaces;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Hospital.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/patient
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        // GET: api/patient/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        // POST: api/patient
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Patient patient)
        {
            await _patientService.CreateAsync(patient);
            return Ok("Patient Added Successfully");
        }

        // PUT: api/patient
        [HttpPut]
        public async Task<IActionResult> Update(Patient patient)
        {
            await _patientService.UpdateAsync(patient);
            return Ok("Patient Updated Successfully");
        }

        // DELETE: api/patient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientService.DeleteAsync(id);
            return Ok("Patient Deleted Successfully");
        }
    }
}