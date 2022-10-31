using AutoMapper;
using CuttinGrassNCAPI.Model.DBCustomers;
using CuttinGrassNCAPI.Model.DBCustomers.Dtos;
using CuttinGrassNCAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuttinGrassNCAPI.Controllers
{
    [ApiController]
    [Route("api/Customer")]


    public class CustomerController : ControllerBase
    {
        private IClientRepository _clientRepo;
        private readonly IMapper _mapper;

        public CustomerController(IClientRepository clientRepo, IMapper mapper)
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
        }



        // GET: CustomerController
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var objList = _clientRepo.GetCustomers();
            var objDto = new List<CustomerDto>();
            foreach ( var obj in objList)
            {
                objDto.Add(_mapper.Map<CustomerDto>(obj));
            }
            return Ok(objDto);
        }

        // GET: CustomerController/Details/5
        [HttpGet("{customerId:int}", Name = "GetCustomerReturn")]
        public IActionResult CustomerDetails(int customerId)
        {
            var obj = _clientRepo.GetCustomer(customerId);
            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<CustomerDto>(obj);
            return Ok(objDto);
        }


        // GET: CustomerController/Create
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_clientRepo.CustomerExistsPost(customerDto.Name))
            {
                ModelState.AddModelError("", "Customer already exist!");
                return StatusCode(404, ModelState);
            }

            var clientObj = _mapper.Map<Customers>(customerDto);
            if (!_clientRepo.CreateCustomer(clientObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving client {clientObj.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetCustomerReturn", new {customerName = customerDto.Name}, clientObj);
        }

       
    }
}
