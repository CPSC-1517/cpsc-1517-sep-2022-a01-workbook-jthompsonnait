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
        [BindProperty]
        public int RegionID { get; set; }

        [TempData]
        public string FeedBackMessage { get; set; }

        public RegionQueryOneModel(RegionServices regionServices)
        {
            _regionServices = regionServices;
        }

        public void OnGet()
        {
        }

        public void OnPost()
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
            else
            {
                FeedBackMessage = "Region id is a non-zero positive whole number";
            }
        }
    }
}
