using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Portfliodemo.Models
{
    public class ContactFormContext : DbContext
    {
        public ContactFormContext(DbContextOptions<ContactFormContext> options)
            : base(options)
        { 
        }
        public DbSet<ContactForm> ContactItems { get; set; }
    }
}
