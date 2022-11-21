#nullable disable
#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class TerritoryServices
    {
        #region Setup of the context connection
        private readonly WestWindContext _context;
        #endregion

        //  constructor to create an instance of the registered context class
        internal TerritoryServices(WestWindContext regContext)
        {
            _context = regContext;
        }
        #region Services: Query
        //  Query by string
        //  This partial search query has been alter to allow for paging of its results
        //  IF paging is NOT required the query should have a single string parameter: partialDescription
        public List<Territory> GetByPartialDescription(string partialDescription,
                                                        int pageNumber,
                                                        int pageSize,
                                                        out int totalCount)
        {
            IEnumerable<Territory> info = _context.Territories
                .Where(x => x.TerritoryDescription.Contains(partialDescription))
                .OrderBy(x => x.TerritoryDescription);

            //  Using the paging parameters to obtain only the necessary rows that
            //      will be shown by the Paginator

            //  Determine the total collection size of our query
            totalCount = info.Count();
            //  Determine the number of rows to skip
            //  THis skipped count reflects the rows of the previous pages
            //  Remember the pagenumber is a natural number (1,2,3,....)
            //  This needs to be treated as an index (natural number -1)  Zero base
            //  The number of rows to skip is index * pagesize
            int skipRows = (pageNumber - 1) * pageSize;
            //  Return only the required number of rows.
            //  This will be done using filters belonging to LINQ
            //  Use the filter .Skip(n) to skip over n rows from the beginning of a collection
            //  Use the filter .Take(n) to take the next n rows from a collection
            return info.Skip(skipRows).Take(pageSize).ToList();

            //  This is the return statement that would be used IF no paging is being implemented
            // return info.ToList();
        }

        //  Query by region ID (number)
        public List<Territory> GetByRegion(int regionID)
        {
            return _context.Territories
                .Where(x => x.RegionID == regionID)
                .OrderBy(x => x.TerritoryDescription).ToList();
        }
        #endregion
    }
}
