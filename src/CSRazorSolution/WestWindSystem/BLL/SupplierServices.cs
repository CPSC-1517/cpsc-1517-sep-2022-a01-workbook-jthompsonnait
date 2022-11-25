using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class SupplierServices
    {
        #region Setup of the context connection
        private readonly WestWindContext _context;
        #endregion

        //  constructor to create an instance of the registered context class
        internal SupplierServices(WestWindContext regContext)
        {
            _context = regContext;
        }

        #region Query
        public List<Supplier> Supplier_List()
        {
            return _context.Suppliers
                .OrderBy(x => x.CompanyName)
                .ToList();
        }
        #endregion
    }
}
