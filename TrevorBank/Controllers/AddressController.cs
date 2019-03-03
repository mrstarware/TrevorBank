using CoreContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static CoreContext.BankContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrevorBank.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private BankContext BankContext { get; set; }

        public AddressController(BankContext bankContext)
        {
            BankContext = bankContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Address Get(int id)
        {
            return BankContext.Addresses.SingleOrDefault(x => x.IdAddress == id);
        }

        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]Address address)
        {
            if (address == null) return -1;

            BankContext.Addresses.Add(address);
            BankContext.SaveChanges();
            BankContext.Entry(address).Reload();
            return address.IdAddress;
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
