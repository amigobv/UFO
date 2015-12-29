package ufo.client.warehouse;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.Month;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import ufo.client.util.FacesUtil;

public class DummyUfoDelegate implements UfoDelegate {

	private List<Category> categories = new ArrayList<Category>();
	private List<Artist> artists = new ArrayList<Artist>();
	private List<Venue> venues = new ArrayList<Venue>();
	private List<Location> locations = new ArrayList<Location>();
	private List<Performance> performances = new ArrayList<Performance>();
	private List<User> users = new ArrayList<User>();
	
	public DummyUfoDelegate() {
		
		User admin = new User("admin", FacesUtil.encryptPassword("admin"));
		User swk5 = new User("swk5", FacesUtil.encryptPassword("swk5"));
		
		users.add(admin);
		users.add(swk5);
		
		Category acrobatic = new Category("A", "Akrobatik");
		Category comedy = new Category("K", "Komedy");
		Category music = new Category("M", "Musik");
		Category fire = new Category("F", "Feuershow");
		
		categories.add(acrobatic);
		categories.add(comedy);
		categories.add(music);
		categories.add(fire);
		
		Location hauptplatz = new Location("H", "Hauptplatz");
		Location landstrasse = new Location("L", "Landstraße");
		Location altstadt = new Location("A", "Alststadt");
		
		locations.add(hauptplatz);
		locations.add(landstrasse);
		locations.add(altstadt);
		
		Venue venue1 = new Venue(1, "Haltestelle", hauptplatz, 100);
		Venue venue2 = new Venue(2, "Altes Rathaus", hauptplatz, 100);
		Venue venue3 = new Venue(3, "Schlossmuseum", altstadt, 100);
		Venue venue4 = new Venue(4, "Ursulinenkirche", landstrasse, 100);
		Venue venue5 = new Venue(5, "Taubenmarkt", landstrasse, 100);
		
		venues.add(venue1);
		venues.add(venue2);
		venues.add(venue3);
		venues.add(venue4);
		venues.add(venue5);
		
		Artist artist1 = new Artist(1,
				"circoPitanga",
				"Schweiz",
				"circoPitanga@teleworm.us",
				"http://www.CircoPitaga.ch",
				"Description",
				"",
				"",
				comedy);
		
		Artist artist2 = new Artist(2,
				"Jean Philippe Kikolas",
				"Spanien",
				"JeanPhilippeKikolas@dayrep.com",
				"http://www.JeanPhilippeKikolas.es",
				"Description",
				"",
				"",
				music);
		
		Artist artist3 = new Artist(3,
				"Hint",
				"Schweden",
				"Hint@dayrep.com",
				"http://www.Hint.sw",
				"Description",
				"",
				"",
				acrobatic);
		
		Artist artist4 = new Artist(4,
				"Derek Derek",
				"USA",
				"DerekDerek@cuvox.de",
				"http://www.DerekDerek.ch",
				"Description",
				"",
				"",
				fire);
		
		Artist artist5 = new Artist(5,
				"Die Buschs",
				"Deutschland",
				"DieBuschs@cuvox.de",
				"http://www.CircoPitaga.ch",
				"Description",
				"",
				"",
				comedy);
		
		Performance performance1 = new Performance(1, LocalDateTime.of(2016, Month.JULY, 21, 16, 0), artist1, venue1);
		Performance performance2 = new Performance(2, LocalDateTime.of(2016, Month.JULY, 21, 17, 0), artist2, venue2);
		Performance performance3 = new Performance(3, LocalDateTime.of(2016, Month.JULY, 21, 18, 0), artist3, venue3);
		Performance performance4 = new Performance(4, LocalDateTime.of(2016, Month.JULY, 22, 19, 0), artist4, venue4);
		Performance performance5 = new Performance(5, LocalDateTime.of(2016, Month.JULY, 23, 20, 0), artist5, venue5);
						
		artists.add(artist1);
		artists.add(artist2);
		artists.add(artist3);
		artists.add(artist4);
		artists.add(artist5);
				
		performances.add(performance1);
		performances.add(performance2);
		performances.add(performance3);
		performances.add(performance4);
		performances.add(performance5);
	}
	
	@Override
	public List<Artist> getAllArtists() {
		return artists;
	}

	@Override
	public List<Venue> getAllVenues() {
		return venues;
	}

	@Override
	public List<Performance> getAllPerformances() {
		return performances;
	}
	
	@Override
	public List<Performance> getPerformanceByDay(LocalDate date) {
		List<Performance> list = new ArrayList<Performance>();

		for (Performance performance: performances) {
			String str = performance.getStart().substring(0, 10);
			LocalDate start = LocalDate.parse(str);
			if (start.equals(date)) {
				list.add(performance);
			}
		}
		return list;
	}
	
	@Override
	public boolean userExists(String username, String password) {
		for(User user : users) {
			if (user.getUsername().equals(username) &&
				user.getPassword().equals(password))
				return true;
		}
		
		return false;
	}
}
