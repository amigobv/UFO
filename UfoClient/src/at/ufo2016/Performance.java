/**
 * Performance.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.4 Apr 22, 2006 (06:55:48 PDT) WSDL2Java emitter.
 */

package at.ufo2016;

public class Performance  implements java.io.Serializable {
    private int id;

    private java.util.Calendar start;

    private at.ufo2016.Artist artist;

    private at.ufo2016.Venue venue;

    public Performance() {
    }

    public Performance(
           int id,
           java.util.Calendar start,
           at.ufo2016.Artist artist,
           at.ufo2016.Venue venue) {
           this.id = id;
           this.start = start;
           this.artist = artist;
           this.venue = venue;
    }


    /**
     * Gets the id value for this Performance.
     * 
     * @return id
     */
    public int getId() {
        return id;
    }


    /**
     * Sets the id value for this Performance.
     * 
     * @param id
     */
    public void setId(int id) {
        this.id = id;
    }


    /**
     * Gets the start value for this Performance.
     * 
     * @return start
     */
    public java.util.Calendar getStart() {
        return start;
    }


    /**
     * Sets the start value for this Performance.
     * 
     * @param start
     */
    public void setStart(java.util.Calendar start) {
        this.start = start;
    }


    /**
     * Gets the artist value for this Performance.
     * 
     * @return artist
     */
    public at.ufo2016.Artist getArtist() {
        return artist;
    }


    /**
     * Sets the artist value for this Performance.
     * 
     * @param artist
     */
    public void setArtist(at.ufo2016.Artist artist) {
        this.artist = artist;
    }


    /**
     * Gets the venue value for this Performance.
     * 
     * @return venue
     */
    public at.ufo2016.Venue getVenue() {
        return venue;
    }


    /**
     * Sets the venue value for this Performance.
     * 
     * @param venue
     */
    public void setVenue(at.ufo2016.Venue venue) {
        this.venue = venue;
    }

    private java.lang.Object __equalsCalc = null;
    public synchronized boolean equals(java.lang.Object obj) {
        if (!(obj instanceof Performance)) return false;
        Performance other = (Performance) obj;
        if (obj == null) return false;
        if (this == obj) return true;
        if (__equalsCalc != null) {
            return (__equalsCalc == obj);
        }
        __equalsCalc = obj;
        boolean _equals;
        _equals = true && 
            this.id == other.getId() &&
            ((this.start==null && other.getStart()==null) || 
             (this.start!=null &&
              this.start.equals(other.getStart()))) &&
            ((this.artist==null && other.getArtist()==null) || 
             (this.artist!=null &&
              this.artist.equals(other.getArtist()))) &&
            ((this.venue==null && other.getVenue()==null) || 
             (this.venue!=null &&
              this.venue.equals(other.getVenue())));
        __equalsCalc = null;
        return _equals;
    }

    private boolean __hashCodeCalc = false;
    public synchronized int hashCode() {
        if (__hashCodeCalc) {
            return 0;
        }
        __hashCodeCalc = true;
        int _hashCode = 1;
        _hashCode += getId();
        if (getStart() != null) {
            _hashCode += getStart().hashCode();
        }
        if (getArtist() != null) {
            _hashCode += getArtist().hashCode();
        }
        if (getVenue() != null) {
            _hashCode += getVenue().hashCode();
        }
        __hashCodeCalc = false;
        return _hashCode;
    }

    // Type metadata
    private static org.apache.axis.description.TypeDesc typeDesc =
        new org.apache.axis.description.TypeDesc(Performance.class, true);

    static {
        typeDesc.setXmlType(new javax.xml.namespace.QName("http://ufo2016.at/", "Performance"));
        org.apache.axis.description.ElementDesc elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("id");
        elemField.setXmlName(new javax.xml.namespace.QName("http://ufo2016.at/", "Id"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "int"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("start");
        elemField.setXmlName(new javax.xml.namespace.QName("http://ufo2016.at/", "Start"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://www.w3.org/2001/XMLSchema", "dateTime"));
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("artist");
        elemField.setXmlName(new javax.xml.namespace.QName("http://ufo2016.at/", "Artist"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://ufo2016.at/", "Artist"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
        elemField = new org.apache.axis.description.ElementDesc();
        elemField.setFieldName("venue");
        elemField.setXmlName(new javax.xml.namespace.QName("http://ufo2016.at/", "Venue"));
        elemField.setXmlType(new javax.xml.namespace.QName("http://ufo2016.at/", "Venue"));
        elemField.setMinOccurs(0);
        elemField.setNillable(false);
        typeDesc.addFieldDesc(elemField);
    }

    /**
     * Return type metadata object
     */
    public static org.apache.axis.description.TypeDesc getTypeDesc() {
        return typeDesc;
    }

    /**
     * Get Custom Serializer
     */
    public static org.apache.axis.encoding.Serializer getSerializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new  org.apache.axis.encoding.ser.BeanSerializer(
            _javaType, _xmlType, typeDesc);
    }

    /**
     * Get Custom Deserializer
     */
    public static org.apache.axis.encoding.Deserializer getDeserializer(
           java.lang.String mechType, 
           java.lang.Class _javaType,  
           javax.xml.namespace.QName _xmlType) {
        return 
          new  org.apache.axis.encoding.ser.BeanDeserializer(
            _javaType, _xmlType, typeDesc);
    }

}
