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
    public class ProductsController: ControllerBase {

        private readonly AlacenaContext _context;

        public ProductsController(AlacenaContext context){
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts() {
            return await _context.ProductList
                .Include( t => t.Trademarks)
                .ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id){
            var producto = await _context.ProductList.FindAsync(id);

            if(producto == null){
                return NotFound();
            }

            return producto;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, Products producto){

            producto.idProducts = id;

            _context.Entry(producto).State = EntityState.Modified;

            try {

                await _context.SaveChangesAsync();

            } catch(DbUpdateConcurrencyException) {

                if( !ProductExists(id)){
                    return NotFound();
                } else {
                    throw;
                }

            }

            return NoContent();

        }


        [HttpPost]
        public async Task<ActionResult<Products>> PostProduct(Products producto){
            _context.ProductList.Add(producto);
            //añadir tambien category
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = producto.idProducts }, producto);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProduct(int id){

            var producto = await _context.ProductList.FindAsync(id);
            if( producto == null ){
                return NotFound();
            }

            _context.ProductList.Remove(producto);
            await _context.SaveChangesAsync();

            return producto;    

        }


        private bool ProductExists(int id){
            return _context.ProductList.Any(e => e.idProducts == id);
        }

        //crear funcion para checar categorías aqui

    }
}