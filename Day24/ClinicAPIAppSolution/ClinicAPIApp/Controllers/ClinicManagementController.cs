using ClinicAPIApp.Exceptions;
using ClinicAPIApp.Interface;
using ClinicAPIApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPIApp.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ClinicManagementController : ControllerBase
    {
        private readonly IDoctorService _service;
        public ClinicManagementController(IDoctorService doctorService) {
            _service = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> GetAllDoctors()
        {
            try
            {
                var doctors = await _service.GetDoctors();
                return Ok(doctors.ToList());

            }
            catch(EmptyListException ele)
            {
                return NotFound(ele.Message);
            }

        }

        [Route("FilterWithSpeciality")]
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> FilterDoctorsWithSpeciality(string speciality)
        {

            try
            {
                var doctors = await _service.GetDoctorsBySpeciality(speciality);
                return Ok(doctors.ToList());

            }
            catch(EmptyListException ele)
            {
                return NotFound(ele.Message);
            }


        }


        //[HttpPost]
        //public async Task<ActionResult<Doctor>> UpdateDoctorSpeciality([FromBody] int docId, [FromBody] string speciality)
        //{
        //    try
        //    {
        //        Doctor doctor = await _service.UpdateDoctorSpeciality(docId, speciality);

        //        return doctor;

        //    }
        //    catch (ElementNotFoundException enfe)
        //    {
        //        return NotFound(enfe.Message);
        //    }


        //}

        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateDoctorSpeciality(int docId, string speciality)
        {
            try
            {
                Doctor doctor = await _service.UpdateDoctorSpeciality(docId, speciality);

                return doctor;

            }
            catch (ElementNotFoundException enfe)
            {
                return NotFound(enfe.Message);
            }


        }


    }
}
