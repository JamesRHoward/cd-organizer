using Nancy;
using System.Collections.Generic;
using CdOrganizer.Objects;

namespace CdOrganizer
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/add_cd"] = _ => {
        return View["add_cd.cshtml"];
      };
      Post["/view_cds"] = _ => {
        var newCD = new CD(Request.Form["artist"], Request.Form["album"]);
        var allCDs = CD.GetAll();
        allCDs.Sort((cd1, cd2) => cd1.GetArtist().CompareTo(cd2.GetArtist()));
        return View["view_cds.cshtml", allCDs];
      };
      Get["/view_cds"] = _ => {
        var allCDs = CD.GetAll();
        return View["/view_cds.cshtml", allCDs];
      };
      Get["/search"] = _ => {
        return View["search_by_artist.cshtml"];
      };
      Post["/result"] = _ => {
        List<string> result = new List<string>{};
        var newSearch = Request.Form["searchName"];
        var allCDs = CD.GetAll();
        foreach(CD cd in allCDs) {
          if (newSearch == cd.GetArtist())
          {
            result.Add("Artist: " + cd.GetArtist());
            result.Add("Album: " + cd.GetAlbum());
          }
        }
        return View["search_result.cshtml", result];
      };
    }
  }
}
