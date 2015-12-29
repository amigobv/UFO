package ufo.client.util;

import java.util.Enumeration;
import java.util.logging.Logger;

import javax.el.ELContext;
import javax.el.ExpressionFactory;
import javax.el.ValueExpression;
import javax.faces.application.Application;
import javax.faces.context.FacesContext;
import javax.servlet.http.HttpServletRequest;

/**
 * Util class for common JSF methods.
 */
public class FacesUtil {

	/**
	 * Returns a JSF managed bean.
	 * 
	 * @param name
	 * @return managed bean
	 */
	public static Object getSessionVariable(String name) {
		FacesContext facesContext = FacesContext.getCurrentInstance();
		Application application = facesContext.getApplication();
		ExpressionFactory expressionFactory = application.getExpressionFactory();
		ELContext elContext = facesContext.getELContext();
		
		ValueExpression valueExpression = expressionFactory.createValueExpression(elContext,  "#{" + name + "}", Object.class);
		
		return valueExpression.getValue(elContext);
	}
	
	/**
	 * Creates a new {@link Failure} object.
	 * 
	 * @param ex
	 * @param logger
	 * @return FailureEvent
	 */
	public static String createFailure(Exception ex, Logger logger) {
		Failure f = (Failure) getSessionVariable("failureModel");
		
		f.setException(ex);
		f.setMessage(ex.getMessage());
		logger.severe(ex.getMessage());
		
		return "FailureEvent";
	}
	
	/**
	 * Returns the request parameter value defined by "name".
	 * 
	 * @param name
	 * @return value
	 */
	public static String getRequesteParameterValue(String name) {
		HttpServletRequest req = (HttpServletRequest) FacesContext.getCurrentInstance().getExternalContext().getRequest();
		
		String paramValue = null;
		Enumeration<?> enumeration = req.getParameterNames();
		while (enumeration.hasMoreElements()) {
			String paramName = (String) enumeration.nextElement();
			if (paramName.indexOf(name) > 0) {
				paramValue = req.getParameter(paramName);
			}
		}
		
		return paramValue;
	}
}
