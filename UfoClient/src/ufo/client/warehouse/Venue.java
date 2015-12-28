package ufo.client.warehouse;

public class Venue {
    private int id;
    private String name;
    private Location location;
    private int capacity;
    
	public Venue(int id, String name, Location location, int capacity) {
		this.id = id;
		this.name = name;
		this.location = location;
		this.capacity = capacity;
	}
	
	public String getId() {
		return String.format("%s%d", location.getId(), id);
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public Location getLocation() {
		return location;
	}
	
	public void setLocation(Location location) {
		this.location = location;
	}
	
	public int getCapacity() {
		return capacity;
	}
	
	public void setCapacity(int capacity) {
		this.capacity = capacity;
	}
    
    
}
