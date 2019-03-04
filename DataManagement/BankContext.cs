using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreContext
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options)
            : base(options) { }


        public class Address
        {
            [Key]
            public int IdAddress { get; set; }
            public string Zipcode { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string Number { get; set; }
        }

        public class BankClient
        {
            [Key]
            public int IdCustomer { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }

            public Address PrimaryAddress { get; set; }
            public List<Check> Checks { get; set; }
        }

        public class Check
        {
            [Key]
            public int IdCheck { get; set; }
            public int CheckNumber { get; set; }
            public int IdCustomer { get; set; }
            public string PayTo { get; set; }
            public decimal DollarAmount { get; set; }
            public string Memo { get; set; }
            public DateTime CheckDate { get; set; }
        }

        public DbSet<BankClient> BankingClients { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
