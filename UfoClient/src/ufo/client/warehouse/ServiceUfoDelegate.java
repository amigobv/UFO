package ufo.client.warehouse;

import java.util.List;
import java.util.logging.Logger;

/**
 * This delegate provides test data from the service.
 */
public class ServiceUfoDelegate implements UfoDelegate {
	private static Logger logger = Logger.getLogger(ServiceUfoDelegate.class.getName());
	
	@Override
	public List<Artist> getAllArtists() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Venue> getAllVenues() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Performance> getAllPerformances() {
		// TODO Auto-generated method stub
		return null;
	}
}
