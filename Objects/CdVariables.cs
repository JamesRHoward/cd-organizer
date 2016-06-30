using System.Collections.Generic;

namespace CdOrganizer.Objects
{
  public class CD
  {
    private string _artist;
    private string _album;
    private int _id;
    private static List<CD> _instances = new List<CD> {};

  // Cd Object Constructor
  public CD(string artist, string album)
  {
    _artist = artist;
    _album = album;
    _instances.Add(this);
    _id = _instances.Count;
  }
  // CD Object Getters
  public string GetArtist()
  {
    return _artist;
  }
  public string GetAlbum()
  {
    return _album;
  }
  public static List<CD> GetAll()
  {
    return _instances;
  }
  public int GetId()
  {
    return _id;
  }
    public static CD Find(int searchId)
    {
      return _instances[searchId -1];
    }
  }
}
