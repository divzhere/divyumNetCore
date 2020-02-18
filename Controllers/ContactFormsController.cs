using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfliodemo.Models;

namespace Portfliodemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormsController : ControllerBase
    {
        private readonly ContactFormContext _context;

        public ContactFormsController(ContactFormContext context)
        {
            _context = context;
        }

        // GET: api/ContactForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactForm>>> GetContactItems()
        {
            return await _context.ContactItems.ToListAsync();
        }

        // GET: api/ContactForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactForm>> GetContactForm(long id)
        {
            var contactForm = await _context.ContactItems.FindAsync(id);

            if (contactForm == null)
            {
                return NotFound();
            }

            return contactForm;
        }

        // PUT: api/ContactForms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactForm(long id, ContactForm contactForm)
        {
            if (id != contactForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactFormExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactForms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ContactForm>> PostContactForm(ContactForm contactForm)
        {
            _context.ContactItems.Add(contactForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContactForm), new { id = contactForm.Id }, contactForm);
        }

        // DELETE: api/ContactForms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactForm>> DeleteContactForm(long id)
        {
            var contactForm = await _context.ContactItems.FindAsync(id);
            if (contactForm == null)
            {
                return NotFound();
            }

            _context.ContactItems.Remove(contactForm);
            await _context.SaveChangesAsync();

            return contactForm;
        }

        private bool ContactFormExists(long id)
        {
            return _context.ContactItems.Any(e => e.Id == id);
        }
    }
}
