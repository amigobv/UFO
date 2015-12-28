package ufo.client;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.List;
import java.util.Map;
import java.util.logging.Logger;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;

import ufo.client.util.ArtistsDataTable;
import ufo.client.util.FacesUtil;
import ufo.client.util.PerformancesDataTable;
import ufo.client.util.VenuesDataTable;
import ufo.client.warehouse.Artist;
import ufo.client.warehouse.Performance;
import ufo.client.warehouse.UfoDelegate;
import ufo.client.warehouse.Venue;

@ManagedBean
@SessionScoped
public class Service {
	private static Logger logger = Logger.getLogger("Service");
	
	public String getAllArtists() {
		try {
			ArtistsDataTable artistsDataTable = (ArtistsDataTable)FacesUtil.getSessionVariable("allArtistsDataTable");
			
			if (artistsDataTable.getArtists().getRowCount() == 0) {
				UfoDelegate ufo = ServiceLocator.getInstance().getUfoDelegate();
				List<Artist> artists = ufo.getAllArtists();
				artistsDataTable.setArtists(artists);
			}
			
			return "BrowseAllArtistsEvent";
		} catch (Exception ex) {
			return FacesUtil.createFailure(ex, logger);
		}
	}
	
	public String getAllVenues() {
		try {
			VenuesDataTable venuesDataTable = (VenuesDataTable)FacesUtil.getSessionVariable("allVenuesDataTable");
			
			if (venuesDataTable.getVenues().getRowCount() == 0) {
				UfoDelegate ufo = ServiceLocator.getInstance().getUfoDelegate();
				List<Venue> venues = ufo.getAllVenues();
				venuesDataTable.setArtists(venues);
			}
			
			return "BrowseAllVenuesEvent";
		} catch (Exception ex) {
			return FacesUtil.createFailure(ex, logger);
		}
	}
	
	public String getAllPerformances() {
		try {
			PerformancesDataTable performancesDataTable = (PerformancesDataTable)FacesUtil.getSessionVariable("allPerformancesDataTable");
			
			if (performancesDataTable.getPerformances().getRowCount() == 0) {
				UfoDelegate ufo = ServiceLocator.getInstance().getUfoDelegate();
				List<Performance> performances = ufo.getAllPerformances();
				performancesDataTable.setPerformances(performances);
			}
			
			return "BrowseAllPerformancesEvent";
		} catch (Exception ex) {
			return FacesUtil.createFailure(ex, logger);
		}
	}
	
	public String getPerformancesByDay() {
		try {
			FacesContext context = FacesContext.getCurrentInstance();
			Map<String, String> params = context.getExternalContext().getRequestParameterMap();
			String day = params.get("day");
			
			PerformancesDataTable performancesDataTable = (PerformancesDataTable)FacesUtil.getSessionVariable("performancesByDayDataTable");
			
			//if (performancesDataTable.getPerformances().getRowCount() == 0) {
				UfoDelegate ufo = ServiceLocator.getInstance().getUfoDelegate();
				LocalDate date= LocalDate.parse(day);
				List<Performance> performances = ufo.getPerformanceByDay(date);
				performancesDataTable.setPerformances(performances);
			//}
			
			return "BrowsePerformancesByDayEvent";
		} catch (Exception ex) {
			return FacesUtil.createFailure(ex, logger);
		}
	}
}
