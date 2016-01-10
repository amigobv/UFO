/**
 * UfoServiceSoap.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package at.ufo2016;

public interface UfoServiceSoap extends java.rmi.Remote {
    public at.ufo2016.Artist[] getAllArtists() throws java.rmi.RemoteException;
    public at.ufo2016.Artist[] getAllArtistsByCategory(at.ufo2016.Category category) throws java.rmi.RemoteException;
    public at.ufo2016.Artist[] getAllArtistsByCountry(java.lang.String country) throws java.rmi.RemoteException;
    public at.ufo2016.Category[] getAllCategories() throws java.rmi.RemoteException;
    public at.ufo2016.Performance[] getAllPerformances() throws java.rmi.RemoteException;
    public at.ufo2016.Performance[] getPerformancesByDay(java.lang.String date) throws java.rmi.RemoteException;
    public at.ufo2016.Venue[] getAllVenues() throws java.rmi.RemoteException;
    public at.ufo2016.Performance[] getPerformanceByArtist(at.ufo2016.Artist artist) throws java.rmi.RemoteException;
    public at.ufo2016.Performance[] getPerformanceByVenue(at.ufo2016.Venue venue) throws java.rmi.RemoteException;
    public at.ufo2016.Venue[] getVenuesByLocation(java.lang.String location) throws java.rmi.RemoteException;
}
