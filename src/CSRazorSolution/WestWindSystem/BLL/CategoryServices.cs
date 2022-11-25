using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class CategoryServices
    {
        #region Setup of the context connection
        private readonly WestWindContext _context;
        #endregion

        //  constructor to create an instance of the registered context class
        internal CategoryServices(WestWindContext regContext)
        {
            _context = regContext;
        }

        #region Query
        public List<Category> Category_List()
        {
            return _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
        }
        #endregion
    }
}
