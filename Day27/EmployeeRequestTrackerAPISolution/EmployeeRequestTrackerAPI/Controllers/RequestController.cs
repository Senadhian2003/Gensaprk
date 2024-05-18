using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService) {
         _requestService = requestService;
        }


        [HttpPost]
        public async Task<ActionResult<int>> RaiseRequest(RequestRaiseDTO requestDTO)
        {
            try
            {
                int requestNumber = await _requestService.RaiseRequest(requestDTO.employeeId, requestDTO.requestMessage);

                return Ok(requestNumber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
