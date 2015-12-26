package ufo.client.warehouse;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class DummyUfoDelegate implements UfoDelegate {

	private Map<String, Category> categories = new HashMap<String, Category>();
	private Map<Integer, Artist> artists = new HashMap<Integer, Artist>();
	private Map<Integer, Venue> venues = new HashMap<Integer, Venue>();
	private Map<String, Location> locations = new HashMap<String, Location>();
	private Map<Integer, Performance> performances = new HashMap<Integer, Performance>();
	
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
				"www.JeanPhilippeKikolas.es",
				"Description",
				"",
				"",
				music);
		
		Artist artist3 = new Artist(3,
				"Hint",
				"Schweden",
				"Hint@dayrep.com",
				"www.Hint.sw",
				"Description",
				"",
				"",
				acrobatic);
		
		Artist artist4 = new Artist(4,
				"Derek Derek",
				"USA",
				"DerekDerek@cuvox.de",
				"www.DerekDerek.ch",
				"Description",
				"",
				"",
				fire);
		
		Artist artist5 = new Artist(5,
				"Die Buschs",
				"Deutschland",
				"DieBuschs@cuvox.de",
				"www.CircoPitaga.ch",
				"Description",
				"",
				"",
				comedy);
		
		artists.put(artist1.getId(), artist1);
		artists.put(artist2.getId(), artist2);
		artists.put(artist3.getId(), artist3);
		artists.put(artist4.getId(), artist4);
		artists.put(artist5.getId(), artist5);
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
		List<Performance> list = new ArrayList<Performance>();
		list.addAll(performances.values());
		return list;
	}
}
