package ufo.client.warehouse;

public class Artist {
    private int id; 
    private String name;
    private String country;
    private String email;
    private String homepage;
    private String description;
    private String picture;
    private String video;
    private Category category;
    
	public Artist(int id, String name, String country, String email, String homepage, String description,
			String picture, String video, Category category) {
		this.id = id;
		this.name = name;
		this.country = country;
		this.email = email;
		this.homepage = homepage;
		this.description = description;
		this.picture = picture;
		this.video = video;
		this.category = category;
	}
    
    
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getCountry() {
		return country;
	}

	public void setCountry(String country) {
		this.country = country;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getHomepage() {
		return homepage;
	}

	public void setHomepage(String homepage) {
		this.homepage = homepage;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getPicture() {
		return picture;
	}

	public void setPicture(String picture) {
		this.picture = picture;
	}

	public String getVideo() {
		return video;
	}

	public void setVideo(String video) {
		this.video = video;
	}

	public Category getCategory() {
		return category;
	}

	public void setCategory(Category category) {
		this.category = category;
	}    
}
