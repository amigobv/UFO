package ufo.client.warehouse;

import java.rmi.RemoteException;
import java.time.LocalDate;
import java.util.List;
import java.util.logging.Logger;

import at.ufo2016.Artist;
import at.ufo2016.Category;
import at.ufo2016.Performance;
import at.ufo2016.UfoServiceSoap;
import at.ufo2016.UfoServiceSoapProxy;
import at.ufo2016.Venue;

/**
 * This delegate provides test data from the service.
 */
public class ServiceUfoDelegate implements UfoServiceSoap {
	private static Logger logger = Logger.getLogger(ServiceUfoDelegate.class.getName());

	@Override
	public Artist[] getAllArtists() throws RemoteException {
		UfoServiceSoapProxy proxy = new UfoServiceSoapProxy();	
		return proxy.getAllArtists();
	}

	@Override
	public Artist[] getAllArtistsByCategory(Category category) throws RemoteException {
		UfoServiceSoapProxy proxy = new UfoServiceSoapProxy();	
		return proxy.getAllArtistsByCategory(category);
	}

	@Override
	public Artist[] getAllArtistsByCountry(String country) throws RemoteException {
		UfoServiceSoapProxy proxy = new UfoServiceSoapProxy();	
		return proxy.getAllArtistsByCountry(country);
	}

	@Override
	public Category[] getAllCategories() throws RemoteException {
		UfoServiceSoapProxy proxy = new UfoServiceSoapProxy();	
		return proxy.getAllCategories();
	}

	@Override
	public Performance[] getAllPerformances() throws RemoteException {
		UfoServiceSoapProxy proxy = new UfoServiceSoapProxy();	
		return proxy.getAllPerformances();
	}

	@Override
	public Performance[] getPerformancesByDay(String date) throws RemoteException {
		UfoServiceSoapProxy proxy = new UfoServiceSoapProxy();	
		return proxy.getPerformancesByDay(date);
	}

	@Override
	public Venue[] getAllVenues() throws RemoteException {
		UfoServiceSoapProxy proxy = new UfoServiceSoapProxy();	
		return proxy.getAllVenues();
	}

	@Override
	public Performance[] getPerformanceByArtist(Artist artist) throws RemoteException {
		UfoServiceSoapProxy proxy = new UfoServiceSoapProxy();	
		return proxy.getPerformanceByArtist(artist);
	}

	@Override
	public Performance[] getPerformanceByVenue(Venue venue) throws RemoteException {
		UfoServiceSoapProxy proxy = new UfoServiceSoapProxy();	
		return proxy.getPerformanceByVenue(venue);
	}

	@Override
	public Venue[] getVenuesByLocation(String location) throws RemoteException {
		UfoServiceSoapProxy proxy = new UfoServiceSoapProxy();	
		return proxy.getVenuesByLocation(location);
	}
	

}
