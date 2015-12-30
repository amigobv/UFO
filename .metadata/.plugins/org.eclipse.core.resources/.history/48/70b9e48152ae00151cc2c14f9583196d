package ufo.client.util;

import org.primefaces.model.map.DefaultMapModel;
import org.primefaces.model.map.LatLng;
import org.primefaces.model.map.MapModel;
import org.primefaces.model.map.Marker;

public class MapBean {
	private MapModel model = new DefaultMapModel();
	
	public MapBean() {
		model.addOverlay(new Marker(new LatLng(48.306368, 14.286277), "Pflasterspektakel 2016, LINZ"));
	}
	
	public MapModel getModel() { return model; }
}
