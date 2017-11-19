﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrleansDemo.API.Models;

namespace OrleansDemo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/ReadingType")]
    public class ReadingTypeController : Controller
    {
        private readonly ConfigurationContext _context;

        public ReadingTypeController(ConfigurationContext context)
        {
            _context = context;
        }

        // GET: api/ReadingType
        [HttpGet]
        public IEnumerable<ReadingType> GetReadingTypes()
        {
            return _context.ReadingTypes;
        }

        // GET: api/ReadingType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReadingType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var readingType = await _context.ReadingTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (readingType == null)
            {
                return NotFound();
            }

            return Ok(readingType);
        }

        // PUT: api/ReadingType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReadingType([FromRoute] int id, [FromBody] ReadingType readingType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != readingType.Id)
            {
                return BadRequest();
            }

            _context.Entry(readingType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReadingTypeExists(id))
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

        // POST: api/ReadingType
        [HttpPost]
        public async Task<IActionResult> PostReadingType([FromBody] ReadingType readingType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ReadingTypes.Add(readingType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReadingType", new { id = readingType.Id }, readingType);
        }

        // DELETE: api/ReadingType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReadingType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var readingType = await _context.ReadingTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (readingType == null)
            {
                return NotFound();
            }

            _context.ReadingTypes.Remove(readingType);
            await _context.SaveChangesAsync();

            return Ok(readingType);
        }

        private bool ReadingTypeExists(int id)
        {
            return _context.ReadingTypes.Any(e => e.Id == id);
        }
    }
}