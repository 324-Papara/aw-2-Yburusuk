using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Para.Base.Response;
using Para.Data.Domain;
using Para.Data.UnitOfWork;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            var entityList = await unitOfWork.CustomerRepository.GetAll();
            return entityList;
        }
        
        [HttpGet("withIncludeDetails")]
        public async Task<List<Customer>> GetWithIncludeDetails()
        {
            var entityList = await unitOfWork.CustomerRepository
                .Include(x => x.CustomerDetail, 
                    x => x.CustomerAddresses, 
                    x => x.CustomerPhones)
                .ToListAsync();
            return entityList;
        }


        [HttpGet("{customerId}")]
        public async Task<Customer> Get(long customerId)
        {
            var entity = await unitOfWork.CustomerRepository.GetById(customerId);
            return entity;
        }
        
        [HttpGet("withWhere/{customerId}")]
        public async Task<List<Customer>> GetWithWhere(long customerId)
        {
            var entity = await unitOfWork.CustomerRepository.Where(x => x.Id == customerId);
            return entity;
        }

        [HttpPost]
        public async Task Post([FromBody] Customer value)
        {
            await unitOfWork.CustomerRepository.Insert(value);
            await unitOfWork.CustomerRepository.Insert(value);
            await unitOfWork.CustomerRepository.Insert(value);
            await unitOfWork.Complete();
        }

        [HttpPut("{customerId}")]
        public async Task Put(long customerId, [FromBody] Customer value)
        {
            await unitOfWork.CustomerRepository.Update(value);
            await unitOfWork.Complete();
        }

        [HttpDelete("{customerId}")]
        public async Task Delete(long customerId)
        {
            await unitOfWork.CustomerRepository.Delete(customerId);
            await unitOfWork.Complete();
        }
    }
}