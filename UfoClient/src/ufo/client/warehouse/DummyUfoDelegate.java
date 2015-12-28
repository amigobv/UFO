package ufo.client.warehouse;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.Month;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class DummyUfoDelegate implements UfoDelegate {

	private Map<String, Category> categories = new HashMap<String, Category>();
	private Map<Integer, Artist> artists = new HashMap<Integer, Artist>();
	private Map<String, Venue> venues = new HashMap<String, Venue>();
	private Map<String, Location> locations = new HashMap<String, Location>();
	private List<Performance> performances = new ArrayList<Performance>();
	
	public DummyUfoDelegate() {
		
		Category acrobatic = new Category("A", "Akrobatik");
		Category comedy = new Category("K", "Komedy");
		Category music = new Category("M", "Musik");
		Category fire = new Category("F", "Feuershow");
		
		categories.put(acrobatic.getId(), acrobatic);
		categories.put(comedy.getId(), comedy);
		categories.put(music.getId(), music);
		categories.put(fire.getId(), fire);
		
		Location hauptplatz = new Location("H", "Hauptplatz");
		Location landstrasse = new Location("L", "Landstraße");
		Location altstadt = new Location("A", "Alststadt");
		
		locations.put(hauptplatz.getId(), hauptplatz);
		locations.put(landstrasse.getId(), landstrasse);
		locations.put(altstadt.getId(), altstadt);
		
		Venue venue1 = new Venue(1, "Haltestelle", hauptplatz, 100);
		Venue venue2 = new Venue(2, "Altes Rathaus", hauptplatz, 100);
		Venue venue3 = new Venue(3, "Schlossmuseum", altstadt, 100);
		Venue venue4 = new Venue(4, "Ursulinenkirche", landstrasse, 100);
		Venue venue5 = new Venue(5, "Taubenmarkt", landstrasse, 100);
		
		venues.put(venue1.getId(), venue1);
		venues.put(venue2.getId(), venue2);
		venues.put(venue3.getId(), venue3);
		venues.put(venue4.getId(), venue4);
		venues.put(venue5.getId(), venue5);
		
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
				
		
		artists.put(artist1.getId(), artist1);
		artists.put(artist2.getId(), artist2);
		artists.put(artist3.getId(), artist3);
		artists.put(artist4.getId(), artist4);
		artists.put(artist5.getId(), artist5);
		
		
		performances.add(performance1);
		performances.add(performance2);
		performances.add(performance3);
		performances.add(performance4);
		performances.add(performance5);
	}
	
	@Override
	public List<Artist> getAllArtists() {
		List<Artist> list = new ArrayList<Artist>();
		list.addAll(artists.values());
		return list;
	}

	@Override
	public List<Venue> getAllVenues() {
		List<Venue> list = new ArrayList<Venue>();
		list.addAll(venues.values());
		return list;
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
}
