package ufo.client.warehouse;

import java.time.LocalDateTime;

public class Performance {
    private int id;
    private LocalDateTime start;
    private Artist artist;
    private Venue venue;
    
	public Performance(int id, LocalDateTime start, Artist artist, Venue venue) {
		this.id = id;
		this.start = start;
		this.artist = artist;
		this.venue = venue;
	}

	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public LocalDateTime getStart() {
		return start;
	}
	
	public void setStart(LocalDateTime start) {
		this.start = start;
	}
	
	public Artist getArtist() {
		return artist;
	}
	
	public void setArtist(Artist artist) {
		this.artist = artist;
	}
	
	public Venue getVenue() {
		return venue;
	}
	
	public void setVenue(Venue venue) {
		this.venue = venue;
	}
    
    
}
