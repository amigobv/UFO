package ufo.client.util;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.faces.model.DataModel;
import javax.faces.model.ListDataModel;

import ufo.client.warehouse.Performance;

public class PerformancesDataTable {
	private static Logger logger = Logger.getAnonymousLogger();
	private DataModel<List<Performance>> model = null;
	
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public PerformancesDataTable() {
		model = new ListDataModel(new ArrayList<Performance>());
		logger.log(Level.INFO, "Performance data model initialized");
	}
	
	@SuppressWarnings({"unchecked", "rawtypes"})
	public PerformancesDataTable(List<Performance> performances) {
		model = new ListDataModel(performances);
	}
	
	@SuppressWarnings({"unchecked", "rawtypes"})
	public void setPerformances(List<Performance> performances) {
		model = new ListDataModel(performances);
	}
	
	public DataModel<List<Performance>> getPerformances() {
		logger.log(Level.INFO, "row count " + model.getRowCount());
		return model;
	}
}
