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
    public class CategoriesController: ControllerBase {

        private readonly AlacenaContext _context;

        public CategoriesController(AlacenaContext context){
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories() {
            return await _context.CategoryList.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetCategory(int id){
            var category = await _context.CategoryList.FindAsync(id);

            if(category == null){
                return NotFound();
            }

            return category;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, Categories category){

            category.idCategory = id;

            _context.Entry(category).State = EntityState.Modified;

            try {

                await _context.SaveChangesAsync();

            } catch(DbUpdateConcurrencyException) {

                if( !CategoryExists(id)){
                    return NotFound();
                } else {
                    throw;
                }

            }

            return NoContent();

        }


        [HttpPost]
        public async Task<ActionResult<Categories>> PostCategory(Categories category){

            //CategoriesXProduct categoryXProduct = new CategoriesXProduct();
            //_context.CategoriesXProductList.Add(categoryXProduct);

            //category.idCategoriesXProduct = categoryXProduct.idCategoriesXProduct;
            //categoryXProduct.Categories_idCategory.Add(category);
            //category.CategoriesXProduct = categoryXProduct;

            _context.CategoryList.Add(category);
            await _context.SaveChangesAsync();

            

            return CreatedAtAction("GetCategory", new { id = category.idCategory }, category);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Categories>> DeleteCategory(int id){

            var category = await _context.CategoryList.FindAsync(id);
            if( category == null ){
                return NotFound();
            }

            _context.CategoryList.Remove(category);
            await _context.SaveChangesAsync();

            return category;    

        }


        private bool CategoryExists(int id){
            return _context.CategoryList.Any(e => e.idCategory == id);
        }

    }
}