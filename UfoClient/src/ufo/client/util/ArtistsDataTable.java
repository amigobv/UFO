package ufo.client.util;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.faces.model.DataModel;
import javax.faces.model.ListDataModel;

import ufo.client.warehouse.Artist;

public class ArtistsDataTable {
	private static Logger logger = Logger.getAnonymousLogger();
	private DataModel<List<Artist>> model = null;
	
	public ArtistsDataTable() {
		model = new ListDataModel(new ArrayList<Artist>());
		logger.log(Level.INFO, "Artists data model initialized");
	}
	
	public ArtistsDataTable(List<Artist> artists) {
		model = new ListDataModel(artists);
	}
	
	public DataModel<List<Artist>> getArtists() {
		logger.log(Level.INFO, "row count " + model.getRowCount());
		return model;
	}
	
	public void setArtists(List<Artist> artists) {
		model = new ListDataModel(artists);
	}
}
