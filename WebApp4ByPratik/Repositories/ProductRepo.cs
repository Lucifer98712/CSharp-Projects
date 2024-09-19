using EFCoreEg.Models;

namespace EFCoreEg.Repositories
{
    public class ProductRepo : IRepository<Product>
    {
        ProductDbContext _context = null;

        public ProductRepo(ProductDbContext context)
        {
            _context = context;
        }
        public void AddRecord(Product model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public Product DeleteRecord(Product model)
        {
            _context.Remove(model);
            return model;
        }

        public IEnumerable<Product> GetAllRecords()
        {

            List<Product> allProducts = _context.Products.ToList();
            return allProducts;
        }    
            
         

        public Product GetSingleRecord(int id)
        {
            Product p = _context.Products.Find(id);
            return p;
        }

        public Product UpdateRecord(Product model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
