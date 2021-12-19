using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using dotnet_api.Models;

namespace dotnet_api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TrademarksController: ControllerBase {

        private readonly AlacenaContext _context;

        public TrademarksController(AlacenaContext context){
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trademarks>>> GetTrademarks() {
            return await _context.TrademarkList.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Trademarks>> GetTrademark(int id){
            var trademark = await _context.TrademarkList.FindAsync(id);

            if(trademark == null){
                return NotFound();
            }

            return trademark;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutTrademark(int id, Trademarks trademark){

            trademark.idTrademarks = id;

            _context.Entry(trademark).State = EntityState.Modified;

            try {

                await _context.SaveChangesAsync();

            } catch(DbUpdateConcurrencyException) {

                if( !TrademarkExists(id)){
                    return NotFound();
                } else {
                    throw;
                }

            }

            return NoContent();

        }


        [HttpPost]
        public async Task<ActionResult<Trademarks>> PostTrdemark(Trademarks trademark){
            _context.TrademarkList.Add(trademark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrademark", new { id = trademark.idTrademarks }, trademark);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Trademarks>> DeleteTrademark(int id){

            var trademark = await _context.TrademarkList.FindAsync(id);
            if( trademark == null ){
                return NotFound();
            }

            _context.TrademarkList.Remove(trademark);
            await _context.SaveChangesAsync();

            return trademark;    

        }


        private bool TrademarkExists(int id){
            return _context.TrademarkList.Any(e => e.idTrademarks == id);
        }

        

    }
}