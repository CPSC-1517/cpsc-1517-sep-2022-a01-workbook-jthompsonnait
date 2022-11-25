#nullable disable
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
    #region Setup of the context connection
    private readonly WestWindContext _context;
    #endregion

    //  constructor to create an instance of the registered context class
    internal ProductServices(WestWindContext regContext)
    {
        _context = regContext;
    }
        #region Services: Query
        //  FIlter search returning all products of the requested category
        public List<Product> Product_CategoryProducts(int categoryID)
        {
            IEnumerable<Product> info = _context.Products
                .Where(x => x.CategoryID == categoryID)
                .OrderBy(x => x.ProductName);
            return info.ToList();
        }

        //  For the CRUD you are maintaining a SINGLE row on the database
        //  This row will be obtained byt the PKEY value of the row
        public Product Product_GetByID(int productID)
        {
            //  Where is matching on the primary key
            //  Linq by default is expecting to return 0, 1 or more rows
            //  WHEN your receive variable (product) expects ONLY a SINGLE
            //      instance of the class (Product), you will "tell" Linq
            //      to return the "first" instance found OR a "default" value
            //      of the variable data type (is a class thus it will be null
            //      for the object instance)
            Product product = _context.Products
                .Where(x => x.ProductID == productID)
                .SingleOrDefault();
            return product;

        }

        #endregion

        #region Add, Update, Delete

        

        #endregion
    }
}
