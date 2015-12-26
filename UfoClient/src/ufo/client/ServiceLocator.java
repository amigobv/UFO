package ufo.client;

import java.lang.reflect.Constructor;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.servlet.ServletException;

import ufo.client.warehouse.UfoDelegate;

public class ServiceLocator {
	private static Logger logger = Logger.getLogger(ServiceLocator.class.getName());
	private static ServiceLocator instance;
	
	private String serviceUrl;
	private String delegateClass;
	
	private ServiceLocator() {
		//nothing to do
	}
	
	public static synchronized ServiceLocator getInstance() {
		if (instance == null) {
			instance = new ServiceLocator();
		}
		
		return instance;
	}
	
	public void init(String url, String delegateClass) {
		this.serviceUrl = url;
		this.delegateClass = delegateClass;
	}
	
	@SuppressWarnings("unchecked")
	public UfoDelegate getUfoDelegate() throws ServletException {
		Class<UfoDelegate> cls;
		try {
			cls = (Class<UfoDelegate>) Class.forName(this.delegateClass);
			Constructor<UfoDelegate>[] c = (Constructor<UfoDelegate>[]) cls.getConstructors();
			Object[] arguments = {};
			UfoDelegate delegate = (UfoDelegate) c[0].newInstance(arguments);
			return delegate;
		} catch (Exception e) {
			logger.log(Level.SEVERE, "ServiceLocator: " + e);
		}
		
		return null;
	}
	
}
