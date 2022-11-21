#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Addional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
using WebApp.Helpers;
#endregion

namespace WebApp.Pages.Samples
{
    public class PartialFilterSearchModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly TerritoryServices _territoryServices;
        private readonly RegionServices _regionServices;
        /*
         *  Services that are registered using AddTransisent<>()
         *      can be accessed on the constructor of the web page class (PageMode)
         *  This is referred to as Dependency Injection
         *  Each register service that is inhected is listed on the constructor as a parameter
         *  ILogger is a service from Microsoft Logging extensions
         *  
         *  We need to add our requried service(s) to this page
         *  Our services will be know by the BLL class name
         *  
         *  When you add a service to the page, you will save the service
         *      reference in a private readonly field
         *  This variable will be available to all methods within this class.
        */
        public PartialFilterSearchModel(ILogger<IndexModel> logger,
                                            TerritoryServices territoryServices,
                                            RegionServices regionServices)
        {
            _logger = logger;
            _territoryServices = territoryServices;
            _regionServices = regionServices;
        }
        #endregion

        [TempData]
        public string Feedback { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RegionID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchArg { get; set; }

        public List<Territory> TerritoryInfo { get; set; }

        [BindProperty]
        public List<Region> RegionList { get; set; }

        #region Paginator
        //  Desired page size
        private const int PAGE_SIZE = 5;
        //  Hold an instance of the Paginator
        public Paginator Pager { get; set; }
        #endregion

        public void OnGet(int? currentPage)
        {
            //  Using the Paginator with your query

            //  OnGet will have a parameter (Request query string) that receives the
            //    current page number.  On the initial load of the page, this value
            //    will be null

            //  Obtain the data list for the Region dropdownlist (select tag)
            RegionList = _regionServices.Region_List();

            if (!string.IsNullOrWhiteSpace(SearchArg))
            {
                //  Setting up for using the Paginator only needs to be done if 
                //      a query is executing

                //  determine the current page number
                int pageNumber = currentPage.HasValue ? currentPage.Value : 1;

                //  Setup the current state of the pagomatpr (sizing)
                PageState current = new(pageNumber, PAGE_SIZE);

                //  Temporary local integer to hold the results of the query's total collection size
                //  This will be need by the Paginator during the paginator's execute
                int totalCount;

                TerritoryInfo = _territoryServices.GetByPartialDescription(SearchArg,
                                            pageNumber, PAGE_SIZE, out totalCount);
                Pager = new Paginator(totalCount, current);
            }
        }

        public IActionResult OnPostFetch()
        {
            if (string.IsNullOrWhiteSpace(SearchArg))
            {
                Feedback = "Required:  Search argument is empty";
            }
            return RedirectToPage(new { SearchArg = SearchArg });
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            //RegionID = 0;
            ModelState.Clear();
            return RedirectToPage(new { SearchArg = (string?)null });
        }
    }
}
