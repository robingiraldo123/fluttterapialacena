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
    public class CategoriesXProductController: ControllerBase {

        private readonly AlacenaContext _context;

        public CategoriesXProductController(AlacenaContext context){
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriesXProduct>>> GetCategoriesXProduct() {
            return await _context.CategoriesXProductList
                //.Include( p => p.Products_idProducts )
                //.Include( c => c.Categories_idCategory)
                .ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriesXProduct>> GetCategoriesXProduct(int id){
            var category = await _context.CategoriesXProductList.FindAsync(id);

            if(category == null){
                return NotFound();
            }

            return category;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, CategoriesXProduct category){

            category.idCategoriesXProduct = id;

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
        public async Task<ActionResult<CategoriesXProduct>> PostCategory(CategoriesXProduct categoryXProduct){

            categoryXProduct = new CategoriesXProduct();

            Categories category1 = new Categories();
            category1.category = "Verduras";
            await _context.CategoryList.AddAsync (category1);


            Products product1 = new Products();
            product1.nameProduct = "Manzana";
            product1.expirationDate = new System.DateTime().AddMonths(1);
            product1.barCode = 1312313;
            await _context.ProductList.AddAsync(product1);


            Trademarks trademark1 = new Trademarks();
            trademark1.mark = "erales";
            trademark1.Products_idProducts = new List<Products>{product1};
            await _context.TrademarkList.AddAsync(trademark1);
            

            categoryXProduct.Categories_idCategory = new List<Categories> {category1};
            categoryXProduct.Products_idProducts = new List<Products> {product1};
            await _context.CategoriesXProductList.AddAsync(categoryXProduct);

            await _context.SaveChangesAsync();


            return CreatedAtAction("GetCategoriesXProduct", new { id = categoryXProduct.idCategoriesXProduct }, categoryXProduct);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriesXProduct>> DeleteCategory(int id){

            var category = await _context.CategoriesXProductList.FindAsync(id);
            if( category == null ){
                return NotFound();
            }

            _context.CategoriesXProductList.Remove(category);
            await _context.SaveChangesAsync();

            return category;    

        }


        private bool CategoryExists(int id){
            return _context.CategoriesXProductList.Any(e => e.idCategoriesXProduct == id);
        }


    }
}