using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocketBank.User.Business.Common.Models;
using PocketBank.User.Business.Interfaces;
using PocketBank.User.WebApi.Common.Models.Request;

namespace PocketBank.User.WebApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClientService _clientService;

        public ClientController(IMapper mapper, IClientService clientService) 
        {
            _mapper = mapper;
            _clientService = clientService;
        }

        /// <summary>
        /// Get client's info: FIO and email
        /// </summary>
        /// <response code="200"> Returns FIO and email </response>
        /// <response code="400"> Validation failed </response>
        /// <response code="500"> Internal server error </response>
        [HttpGet]
        [Route("info")]
        public async Task<IActionResult> GetUserInfoAsync([FromQuery] ClientIdRequest clientIdRequest)
        {
            var clientInfo = await _clientService.GetClientInfoAsync(clientIdRequest.Id);

            if (clientInfo is null)
            {
                return NotFound();
            }

            return Ok(clientInfo);
        }

        /// <summary>
        /// Register a new client
        /// </summary>
        /// <response code="200"> Registration succeed </response>
        /// <response code="400"> Validation failed </response>
        /// <response code="500"> Internal server error </response>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterNewUserAsync(ClientRegisterRequest clientInfo)
        {
            var client = _mapper.Map<ClientBusiness>(clientInfo);
            await _clientService.AddNewClientAsync(client);

            return Ok();
        }

        /// <summary>
        /// Log in an existing client by email and password
        /// </summary>
        /// <response code="200"> Log in succeed </response>
        /// <response code="400"> Validation failed </response>
        /// <response code="500"> Internal server error </response>
        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> LoginAsync(ClientLoginRequest loginRequest)
        {
            var authResult = await _clientService.LoginAsync(loginRequest.Email, loginRequest.Password);
            if (!authResult.IsSucceed) return BadRequest();

            return Ok(authResult.Id);
        }
    }
}
