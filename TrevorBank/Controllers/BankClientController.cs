using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreContext;
using Microsoft.AspNetCore.Mvc;
using static CoreContext.BankContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrevorBank.Controllers
{
    [Route("api/[controller]")]
    public class BankClientController : Controller
    {
        BankContext BankContext { get; set; }

        public BankClientController(BankContext bankContext)
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]BankClient client)
        {
            if (client == null) return; 
            BankContext.BankingClients.Add(client);
            BankContext.SaveChanges();
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
