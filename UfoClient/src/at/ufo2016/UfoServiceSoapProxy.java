package at.ufo2016;

public class UfoServiceSoapProxy implements at.ufo2016.UfoServiceSoap {
  private String _endpoint = null;
  private at.ufo2016.UfoServiceSoap ufoServiceSoap = null;
  
  public UfoServiceSoapProxy() {
    _initUfoServiceSoapProxy();
  }
  
  public UfoServiceSoapProxy(String endpoint) {
    _endpoint = endpoint;
    _initUfoServiceSoapProxy();
  }
  
  private void _initUfoServiceSoapProxy() {
    try {
      ufoServiceSoap = (new at.ufo2016.UfoServiceLocator()).getUfoServiceSoap();
      if (ufoServiceSoap != null) {
        if (_endpoint != null)
          ((javax.xml.rpc.Stub)ufoServiceSoap)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
        else
          _endpoint = (String)((javax.xml.rpc.Stub)ufoServiceSoap)._getProperty("javax.xml.rpc.service.endpoint.address");
      }
      
    }
    catch (javax.xml.rpc.ServiceException serviceException) {}
  }
  
  public String getEndpoint() {
    return _endpoint;
  }
  
  public void setEndpoint(String endpoint) {
    _endpoint = endpoint;
    if (ufoServiceSoap != null)
      ((javax.xml.rpc.Stub)ufoServiceSoap)._setProperty("javax.xml.rpc.service.endpoint.address", _endpoint);
    
  }
  
  public at.ufo2016.UfoServiceSoap getUfoServiceSoap() {
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap;
  }
  
  public at.ufo2016.Artist[] getAllArtists() throws java.rmi.RemoteException{
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap.getAllArtists();
  }
  
  public at.ufo2016.Artist[] getAllArtistsByCategory(at.ufo2016.Category category) throws java.rmi.RemoteException{
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap.getAllArtistsByCategory(category);
  }
  
  public at.ufo2016.Artist[] getAllArtistsByCountry(java.lang.String country) throws java.rmi.RemoteException{
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap.getAllArtistsByCountry(country);
  }
  
  public at.ufo2016.Category[] getAllCategories() throws java.rmi.RemoteException{
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap.getAllCategories();
  }
  
  public at.ufo2016.Performance[] getAllPerformances() throws java.rmi.RemoteException{
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap.getAllPerformances();
  }
  
  public at.ufo2016.Performance[] getPerformancesByDay(java.lang.String date) throws java.rmi.RemoteException{
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap.getPerformancesByDay(date);
  }
  
  public at.ufo2016.Venue[] getAllVenues() throws java.rmi.RemoteException{
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap.getAllVenues();
  }
  
  public at.ufo2016.Performance[] getPerformanceByArtist(at.ufo2016.Artist artist) throws java.rmi.RemoteException{
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap.getPerformanceByArtist(artist);
  }
  
  public at.ufo2016.Performance[] getPerformanceByVenue(at.ufo2016.Venue venue) throws java.rmi.RemoteException{
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap.getPerformanceByVenue(venue);
  }
  
  public at.ufo2016.Venue[] getVenuesByLocation(java.lang.String location) throws java.rmi.RemoteException{
    if (ufoServiceSoap == null)
      _initUfoServiceSoapProxy();
    return ufoServiceSoap.getVenuesByLocation(location);
  }
  
  
}