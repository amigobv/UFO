/**
 * UfoService.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package at.ufo2016;

public interface UfoService extends javax.xml.rpc.Service {
    public java.lang.String getUfoServiceSoapAddress();

    public at.ufo2016.UfoServiceSoap getUfoServiceSoap() throws javax.xml.rpc.ServiceException;

    public at.ufo2016.UfoServiceSoap getUfoServiceSoap(java.net.URL portAddress) throws javax.xml.rpc.ServiceException;
}
