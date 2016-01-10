package ufo.client.util;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.faces.model.DataModel;
import javax.faces.model.ListDataModel;

import ufo.client.warehouse.Venue;

public class VenuesDataTable {
	private static Logger logger = Logger.getAnonymousLogger();
	private DataModel<List<Venue>> model = null;
	
	@SuppressWarnings({ "rawtypes", "unchecked" })
	public VenuesDataTable() {
		model = new ListDataModel(new ArrayList<Venue>());
		logger.log(Level.INFO, "Venues data model initialized");
	}
	
	@SuppressWarnings({ "rawtypes", "unchecked" })
	public VenuesDataTable(List<Venue> venues) {
		model = new ListDataModel(venues);
	}
	
	public DataModel<List<Venue>> getVenues() {
		logger.log(Level.INFO, "row count " + model.getRowCount());
		return model;
	}
	
	@SuppressWarnings({ "rawtypes", "unchecked" })
	public void setArtists(List<Venue> venues) {
		model = new ListDataModel(venues);
	}
}
