using CoreContext;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static CoreContext.BankContext;
using Microsoft.EntityFrameworkCore;

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
        public BankClient Get(int id)
        {
            var bankingClient = BankContext.BankingClients.Include(a => a.PrimaryAddress)
                .Include(c => c.Checks)
                .SingleOrDefault(x => x.IdCustomer == id);

            bankingClient.Checks = bankingClient.Checks ?? new List<Check>();
            return bankingClient;
        }

        //// GET api/<controller>/John CommonName Doe
        //[HttpGet("{fullName}")]
        //public BankClient Get(string fullName)
        //{
        //    var names = fullName.Split(' ');
            
        //    return BankContext.BankingClients.SingleOrDefault(x => x.FirstName == names[0] && x.MiddleName == names[1] && x.LastName == names[2]);
        //}

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]BankClient client)
        {
            if (client == null) return; 

            if (client.PrimaryAddress != null) // Need to see if there's a better way to do this.
            {
                client.PrimaryAddress = BankContext.Addresses.SingleOrDefault(x => x.IdAddress == client.PrimaryAddress.IdAddress);
            }
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
