package ufo.client;

import java.util.List;
import java.util.logging.Logger;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import ufo.client.util.ArtistsDataTable;
import ufo.client.util.FacesUtil;
import ufo.client.warehouse.Artist;
import ufo.client.warehouse.UfoDelegate;

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
	
	
}
