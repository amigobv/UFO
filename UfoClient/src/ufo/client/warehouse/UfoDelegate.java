package ufo.client.warehouse;

import java.time.LocalDate;
import java.util.List;

public interface UfoDelegate {
	public List<Artist> getAllArtists();
	public List<Venue> getAllVenues();
	public List<Performance> getAllPerformances();
	public List<Performance> getPerformanceByDay(LocalDate date);
	public boolean userExists(String username, String password);
}
