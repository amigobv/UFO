package ufo.client.util;

import java.io.PrintWriter;
import java.io.StringWriter;

import javax.faces.bean.ManagedBean;
import javax.faces.bean.RequestScoped;
import javax.servlet.ServletException;

/**
 * Simple class representing a failure view model.
 * 
 */
@ManagedBean(name="failureModel")
@RequestScoped
public class Failure {
	private Exception exception;
	private String message;
	
	public Exception getException() {
		return exception;
	}
	
	public void setException(Exception ex) {
		this.exception = ex;
	}
	
	public String getMessage() {
		return message;
	}
	
	public void setMessage(String msg) {
		this.message = msg;
	}
	
	public String getStackTrace() {
		StringWriter sw = new StringWriter();
		PrintWriter pw = new PrintWriter(sw);
		fillStackTrace(getException(), pw);
		return sw.toString();
	}
	
	private void fillStackTrace(Throwable t, PrintWriter w) {
		if (t == null)
			return;
		
		t.printStackTrace(w);
		
		if (t instanceof ServletException) {
			Throwable cause = ((ServletException) t).getRootCause();
			w.println("Root cause: ");
			fillStackTrace(cause, w);
		} else {
			Throwable cause = t.getCause();
			w.println("Cause: ");
			fillStackTrace(cause, w);
		}
	}
}
