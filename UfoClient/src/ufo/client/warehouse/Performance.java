package ufo.client.warehouse;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class Performance {
    private int id;
    private LocalDateTime start;
    private String time;
    private String date;
    private Artist artist;
    private Venue venue;
    
	public Performance(int id, LocalDateTime start, Artist artist, Venue venue) {
		this.id = id;
		this.start = start;
		this.artist = artist;
		this.venue = venue;
		this.date = String.format("%02d:%02d", start.getHour(), start.getMinute());
	}

	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public String getStart() {
		return start.format( DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm"));
	}
	
	public void setStart(String start) {
		this.start = LocalDateTime.parse(start, DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm"));
	}
	
	public String getStartTime() {
		time = String.format("%02d:%02d", start.getHour(), start.getMinute());
		return time;
	}
	
	public void setStartTime(String time) {
		String dateTime = "";
		
		this.time = time;
		dateTime = String.format("%04d-%02d-%02d %s", start.getYear(), start.getMonth(), start.getDayOfMonth(), time);
		this.start = LocalDateTime.parse(dateTime, DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm"));
	}
	
	public String getDate() {
		date = String.format("%04d-%02d-%02d", start.getYear(), start.getMonth(), start.getDayOfMonth());
		return date;
	}
	
	public void setDate(String date) {
		String dateTime = ""; 
		
		this.date = date;
		dateTime = String.format("%s %02d:%02d", date, start.getHour(), start.getMinute());
		this.start = LocalDateTime.parse(dateTime, DateTimeFormatter.ofPattern("yyyy-MMydd HH:mm"));
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
