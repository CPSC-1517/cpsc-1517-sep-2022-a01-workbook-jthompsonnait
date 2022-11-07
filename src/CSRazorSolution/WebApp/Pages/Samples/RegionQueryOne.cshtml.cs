using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
#region Addional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion
#nullable disable


namespace WebApp.Pages.Samples
{
    public class RegionQueryOneModel : PageModel
    {
        private readonly RegionServices _regionServices;

        //  This is bond to the inout control via asp-for
        //  This is a two way binding of both out and in
        //  Data is move out and in FOR YOU AUTOMATICALLY
        //  SupportsGet = true will allow this property to be matched to 
        //      a routing parameter of the same name.
        [BindProperty(SupportsGet = true)]
        public int RegionID { get; set; }

        [TempData]
        public string FeedBackMessage { get; set; }

        public RegionQueryOneModel(RegionServices regionServices)
        {
            _regionServices = regionServices;
        }

        public void OnGet()
        {
            if (RegionID > 0)
            {
                Region RegionInfo = _regionServices.Region_GetByID(RegionID);
                if (RegionInfo == null)
                {
                    FeedBackMessage = "Region id is not valid.  No such region on file.";
                }
                else
                {
                    FeedBackMessage = $"ID: {RegionInfo.RegionId} Description: {RegionInfo.RegionDescription}";
                }
            }
        }

        //  generic failing post handler 
        public void OnPost()
        {
            FeedBackMessage = "WARNING!!!  No OnPost page handler set.  Execution default to the code OnPost()";
        }

        //  specific post method to use in conjunction with asp-page-handler="xxx"
        public IActionResult OnPostFetch()
        {
            if (RegionID < 1)
            {
                FeedBackMessage = "Required: Region id is a non-zero positive whole number";
            }
            //  The receiving "RegionID" ia the routing parameter
            //  The sending "RegionID" is a BindProperty field
            return RedirectToPage(new {RegionID = RegionID});
        }

        public IActionResult OnPostClear()
        {
            FeedBackMessage = "";
            //RegionID = 0;
            ModelState.Clear();
           return RedirectToPage(new {RegionID = (int?)null});
        }
    }
}
