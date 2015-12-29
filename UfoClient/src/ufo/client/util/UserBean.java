package ufo.client.util;

import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;
import javax.servlet.http.HttpSession;

import ufo.client.warehouse.DummyUfoDelegate;
import ufo.client.warehouse.UfoDelegate;

@ManagedBean
@SessionScoped
public class UserBean {
	private String username;
	private String password;
	private String msg;
	
	public String getUsername() {
		return username;
	}
	
	public void setUsername(String username) {
		this.username = username;
	}
	
	public String getPassword() {
		return password;
	}
	
	public void setPassword(String password) {
		this.password = FacesUtil.encryptPassword(password);
	}
	
	public String getMsg() {
        return msg;
    }
 
    public void setMsg(String msg) {
        this.msg = msg;
    }
	
	public String checkLogin() {
		UfoDelegate ufoWebService = new DummyUfoDelegate();
		
		if (ufoWebService.userExists(username, password)) {
			FacesContext.getCurrentInstance().getExternalContext().invalidateSession();
			return "success";
		} else {
			FacesContext.getCurrentInstance().addMessage(null, new FacesMessage(FacesMessage.SEVERITY_ERROR, 
																				"Incorrect Username or Password!", 
																				"Please enter correct username and Password!"));
			return "failed";
		}
	}
}
