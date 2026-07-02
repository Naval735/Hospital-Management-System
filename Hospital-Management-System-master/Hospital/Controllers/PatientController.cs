using Hospital.DTOs;
using Hospital.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPatientByName(string name)
        {
            var patients = await _patientService.GetPatientByNameAsync(name);

            return Ok(patients);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePatient(RegisterDto dto)
        {
            var patient = await _patientService.CreatePatientAsync(dto);

            return CreatedAtAction(
                nameof(GetPatientByName),
                new { name = patient.Name },
                patient);
        }
    }
}