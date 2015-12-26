package ufo.client;

import javax.servlet.ServletContext;
import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;

public class InitializeContextListener implements ServletContextListener {

	@Override
	public void contextDestroyed(ServletContextEvent arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void contextInitialized(ServletContextEvent arg0) {
		ServletContext servletContext = arg0.getServletContext();
		
		String url = servletContext.getInitParameter("SERVICE_URL");
		String delegateClass = servletContext.getInitParameter("UFO_DELEGATE");
		
		ServiceLocator.getInstance().init(url, delegateClass);
	}
	
}
