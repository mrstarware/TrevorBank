using CoreContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static CoreContext.BankContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrevorBank.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        private readonly BankContext _bankContext;

        public CheckController(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public List<Check> Get()
        {
            return new List<Check>();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Check Get(int id)
        {
           return _bankContext.Checks.SingleOrDefault(x => x.IdCheck == id);
        }

        // GET api/<controller>/5
        
        [HttpGet("GetAllSentBy/{id}")]
        public List<int> GetAllSentBy(int id)
        {
            return _bankContext.Checks.Where(x => x.IdCustomer == id).Select(x => x.IdCheck).ToList();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Check sentCheck)
        {
            // Implement a sense of a balance later
            if (sentCheck == null) return;

            _bankContext.Checks.Add(sentCheck);
            _bankContext.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
