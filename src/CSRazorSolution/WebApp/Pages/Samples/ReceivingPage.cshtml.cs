
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WebApp.Pages.Samples
{
    public class ReceivingPageModel : PageModel
    {
        private readonly RegionServices _regionServices;
        public ReceivingPageModel(RegionServices regionServices)
        {
            _regionServices = regionServices;
        }

        [BindProperty(SupportsGet = true)]
        public int? TerritoryID { get; set; }
        [TempData]
        public string Feedback { get; set; }
        public void OnGet()
        {

            //  Since the internet is a stateless environment, you need to
            //      obtain any list data that is required by your controls or local
            //      logic on EVERY instance of the pae being processed
            if (TerritoryID > 0)
            {

            }
            else
            {
            }
        }
    }
}
