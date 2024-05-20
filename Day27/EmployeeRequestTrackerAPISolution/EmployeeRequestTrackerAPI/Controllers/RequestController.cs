using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        [Route("RaiseRequest")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> RaiseRequest(RequestRaiseDTO requestDTO)
        {
            try
            {
                int requestNumber = await _requestService.RaiseRequest(requestDTO.employeeId, requestDTO.requestMessage);

                return Ok(requestNumber);
            }
            catch (Exception ex)
            {
                return  NotFound(new ErrorModel(401, ex.Message));
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [Route("/CloseRequest")]
        public async Task<ActionResult<Request>> CloseRequest(CloseRequestDTO requestDTO)
        {
            try
            {
                Request request = await _requestService.CloseRequest(requestDTO.EmployeeId, requestDTO.RequestId);

                return Ok(request);
            }
            catch (ElementNotFoundException enfe)
            {
                return NotFound(new ErrorModel(401, enfe.Message));
            }

        }

        [HttpGet]
        
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [Route("/ViewAllRequests")]
        public async Task<ActionResult<List<Request>>> GetAllRequests()
        {
            try
            {
                List<Request> requests = await _requestService.ViewAllRequest();

                return Ok(requests);
            }
            catch (EmptyListException ele)
            {
                return NotFound(new ErrorModel(401, ele.Message));
            }

        }


        [HttpGet]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [Route("/ViewMyRequests")]
        public async Task<ActionResult<List<Request>>> GetMyRequests(int employeeId)
        {
            try
            {
                List<Request> requests = await _requestService.ViewMyRequest(employeeId);

                return Ok(requests);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(401, ex.Message));
            }

        }


    }
}
