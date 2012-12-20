<!--
* Company / Project	: BAE Systems Bofors AB / ARCHER
* This document and it's contents is the property of BAE Systems Bofors AB
* and must not be reproduced, disclosed to any party 
* or used in any unauthorized manner without written consent. 
* Author: Andreas Joelsson
* Contact Information: andreas.joelsson@baesystems.se
-->

<xsl:stylesheet
	version="2.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xs="http://www.w3.org/2001/XMLSchema"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	xmlns:util="utilities:date-functions:now"
	exclude-result-prefixes="util msxsl"
>

<!-- functionSet -->
<xsl:template name="functionSet">
	<xsl:param name="name" required="yes" />
	<xsl:param name="extra" required="no" />
	
	<xsl:text>Set</xsl:text><xsl:if test="$extra"><xsl:value-of select="$extra" /></xsl:if>
	<xsl:value-of select="concat(upper-case(substring($name, 1, 1)),substring($name, 2))" />
</xsl:template>

<!-- functionGet -->
<xsl:template name="functionGet">
	<xsl:param name="name" required="yes" />
	<xsl:param name="extra" required="no" />
	
	<xsl:text>Get</xsl:text><xsl:if test="$extra"><xsl:value-of select="$extra" /></xsl:if>
	<xsl:value-of select="concat(upper-case(substring($name, 1, 1)),substring($name, 2))" />
</xsl:template>

<!-- functionIs -->
<xsl:template name="functionIs">
	<xsl:param name="name" required="yes" />
	
	<xsl:text>Is</xsl:text><xsl:value-of select="$name" />
	<xsl:text>Object</xsl:text>
</xsl:template>

<!-- isobject -->
<xsl:template match="class" mode="isobject">
	<xsl:param name="namespace" required="yes" />
	<xsl:param name="classname" required="yes" />
	<xsl:param name="objectname" required="yes" />
	<xsl:variable name="objectkey" select="params/param[@classkey='yes']" />
	<xsl:variable name="objectkeyvalue">
		<xsl:for-each select="params/param">
			<xsl:if test="@classkey='yes'">
				<xsl:value-of select="@init" />
			</xsl:if>
		</xsl:for-each>
	</xsl:variable>
	
	<xsl:text>/**</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * function </xsl:text>
	<xsl:call-template name="functionIs">
		<xsl:with-param name="name" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @brief Method to check if the object is a </xsl:text><xsl:value-of select="$objectname" /><xsl:text> object.</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:text> * @code</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> *   var </xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text> = </xsl:text><xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.GetNew</xsl:text>
	<xsl:value-of select="$objectname" /><xsl:text>();</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> *   if( true == </xsl:text><xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text>
	<xsl:call-template name="functionIs">
		<xsl:with-param name="name" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" /><xsl:text>) ) // true</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> *   {</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> *     // do something</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> *   }</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @endcode</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @param [in] </xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text> </xsl:text><xsl:value-of select="$objectname" />
	<xsl:text> object to evaluate.</xsl:text>	
	<xsl:call-template name="cr" />
	
	<xsl:text> * @return bool</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @retval true Returned if the object is of type </xsl:text>
	<xsl:value-of select="$objectname" /><xsl:text>.</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @retval false Returned if the object isn't of type </xsl:text>
	<xsl:value-of select="$objectname" /><xsl:text>.</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> */</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>function </xsl:text>
	<xsl:call-template name="functionIs">
		<xsl:with-param name="name" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>//*bool </xsl:text>
	<xsl:call-template name="functionIs">
		<xsl:with-param name="name" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="$objectname" />
	<xsl:text> </xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>{</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>var retValue = ( undefined != </xsl:text>
	<xsl:value-of select="lower-case($objectname)" /><xsl:text>.</xsl:text><xsl:value-of select="$objectkey" /><xsl:text> );</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>retValue = ( true == retValue ) ? ( null != </xsl:text>
	<xsl:value-of select="lower-case($objectname)" /><xsl:text>.</xsl:text><xsl:value-of select="$objectkey" /><xsl:text> ) : false;</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>retValue = ( true == retValue ) ? ( </xsl:text>
	<xsl:value-of select="$objectkeyvalue" /><xsl:text> == </xsl:text>
	<xsl:value-of select="lower-case($objectname)" /><xsl:text>.</xsl:text><xsl:value-of select="$objectkey" /><xsl:text> ) : false;</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>return retValue;</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="cr" />
	
</xsl:template>

<!-- newobject -->
<xsl:template match="class" mode="newobject">
	<xsl:param name="namespace" required="yes" />
	<xsl:param name="classname" required="yes" />
	<xsl:param name="objectname" required="yes" />
	
	<xsl:text>/**</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * function GetNew</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(</xsl:text>
	<xsl:for-each select="constructor/param">
		<xsl:if test="not(position()=1)"><xsl:text>, </xsl:text></xsl:if>
		<xsl:value-of select="." />
	</xsl:for-each>
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @brief Method to create a </xsl:text><xsl:value-of select="$objectname" /><xsl:text> object.</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @code</xsl:text><xsl:call-template name="cr" />
	<xsl:text> *   var object = </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text><xsl:value-of select="$classname" />
	<xsl:text>.GetNew</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(</xsl:text>
	<xsl:for-each select="constructor/param">
		<xsl:if test="not(position()=1)"><xsl:text>, </xsl:text></xsl:if>
		<xsl:choose>
			<xsl:when test="@type='string'"><xsl:text>&quot;kalle&quot;</xsl:text></xsl:when>
			<xsl:when test="@type='float'"><xsl:text>123.456</xsl:text></xsl:when>
			<xsl:when test="@type='int'"><xsl:text>123456</xsl:text></xsl:when>
			<xsl:otherwise><xsl:text>object</xsl:text></xsl:otherwise>
		</xsl:choose>
	</xsl:for-each>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @endcode</xsl:text><xsl:call-template name="cr" />
	<xsl:if test="constructor/param">
		<xsl:for-each select="constructor/param">
			<xsl:text> * @param [in] </xsl:text><xsl:value-of select="." />
			<xsl:text> </xsl:text><xsl:value-of select="@type" />
			<xsl:if test="@comment"><xsl:text> </xsl:text><xsl:value-of select="@comment" /></xsl:if>
			<xsl:call-template name="cr" />
		</xsl:for-each>
	</xsl:if>
	<xsl:text> * @return </xsl:text><xsl:value-of select="$objectname" /><xsl:text> object.</xsl:text><xsl:call-template name="cr" />
	<xsl:text> */</xsl:text><xsl:call-template name="cr" />
	<xsl:text>function GetNew</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(</xsl:text>
	<xsl:for-each select="constructor/param">
		<xsl:if test="not(position()=1)"><xsl:text>, </xsl:text></xsl:if>
		<xsl:value-of select="." />
	</xsl:for-each>
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	<xsl:text>//*</xsl:text><xsl:value-of select="$objectname" /><xsl:text> GetNew</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(</xsl:text>
	<xsl:for-each select="constructor/param">
		<xsl:if test="not(position()=1)"><xsl:text>, </xsl:text></xsl:if>
		<xsl:value-of select="@type" /><xsl:text> </xsl:text><xsl:value-of select="." />
	</xsl:for-each>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	<xsl:text>{</xsl:text><xsl:call-template name="cr" />
	<xsl:value-of select="$gTab" /><xsl:text>return new </xsl:text><xsl:value-of select="$objectname" /><xsl:text>(</xsl:text>
	<xsl:for-each select="constructor/param">
		<xsl:if test="not(position()=1)"><xsl:text>, </xsl:text></xsl:if>
		<xsl:value-of select="." />
	</xsl:for-each>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	<xsl:text>}</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="cr" />
</xsl:template>


<xsl:template name="CallMethod">
	<xsl:param name="class" required="yes" />
	<xsl:param name="method" required="yes" />
		<xsl:value-of select="$class/@namespace" /><xsl:text>.</xsl:text><xsl:value-of select="$class/@classname" />	
		<xsl:text>.</xsl:text><xsl:value-of select="$method" /><xsl:value-of select="$class/objectname" />
</xsl:template>

<!-- copyobject -->
<xsl:template match="class" mode="copyobject">
	<xsl:param name="namespace" required="yes" />
	<xsl:param name="classname" required="yes" />
	<xsl:param name="objectname" required="yes" />
	
	<xsl:text>/**</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * function GetCopyOf</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(</xsl:text>
	<xsl:for-each select="constructor/param">
		<xsl:if test="not(position()=1)"><xsl:text>, </xsl:text></xsl:if>
		<xsl:value-of select="." />
	</xsl:for-each>
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @brief Method to create a copy of </xsl:text><xsl:value-of select="$objectname" /><xsl:text> object.</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @code</xsl:text><xsl:call-template name="cr" />
	<xsl:text> *   var object = </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text><xsl:value-of select="$classname" />
	<xsl:text>.GetNew</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(</xsl:text>
	<xsl:for-each select="constructor/param">
		<xsl:if test="not(position()=1)"><xsl:text>, </xsl:text></xsl:if>
		<xsl:choose>
			<xsl:when test="@type='string'"><xsl:text>&quot;kalle&quot;</xsl:text></xsl:when>
			<xsl:when test="@type='float'"><xsl:text>123.456</xsl:text></xsl:when>
			<xsl:when test="@type='int'"><xsl:text>123456</xsl:text></xsl:when>
			<xsl:otherwise><xsl:text>object</xsl:text></xsl:otherwise>
		</xsl:choose>
	</xsl:for-each>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	<xsl:text> *   var objectCopy = </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text><xsl:value-of select="$classname" />
	<xsl:text>.GetCopyOf</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(object);</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @endcode</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @param [in] object </xsl:text><xsl:value-of select="$objectname" /><xsl:text> object.</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @return </xsl:text><xsl:value-of select="$objectname" /><xsl:text> object.</xsl:text><xsl:call-template name="cr" />
	<xsl:text> */</xsl:text><xsl:call-template name="cr" />
	<xsl:text>function GetCopyOf</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(obj2copy)</xsl:text><xsl:call-template name="cr" />
	<xsl:text>//*</xsl:text><xsl:value-of select="$objectname" /><xsl:text> GetCopyOf</xsl:text><xsl:value-of select="$objectname" />
	<xsl:text>(</xsl:text><xsl:value-of select="$objectname" /><xsl:text> obj2copy);</xsl:text><xsl:call-template name="cr" />
	<xsl:text>{</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>if( true != </xsl:text>
	<xsl:call-template name="functionIs">
		<xsl:with-param name="name" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(obj2copy) ) {</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:call-template name="tab" />
	<xsl:text>var exception = "</xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.GetCopyOf</xsl:text>
	<xsl:value-of select="$objectname" />	
	<xsl:text> first param was not the expected object </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$objectname" /><xsl:text>.";</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:call-template name="tab" />
	<xsl:text>throw _COMMON.Exceptions.InvalidObjectException(exception);</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:value-of select="$gTab" /><xsl:text>var retValue = new </xsl:text><xsl:value-of select="$objectname" /><xsl:text>();</xsl:text><xsl:call-template name="cr" />
	
	<xsl:for-each select="params/param">
		
	<xsl:variable name="id" select="@id" />
		<xsl:if test="not(@classkey='yes')">
			<xsl:value-of select="$gTab" /><xsl:text>retValue.</xsl:text><xsl:value-of select="." />
			<xsl:text> = </xsl:text>
			
			<xsl:choose>
				<xsl:when test="@array='yes'">
				<xsl:text>Array();</xsl:text>
				
		<xsl:value-of select="$gTab" /><xsl:call-template name="cr" />
		<xsl:value-of select="$gTab" />
		<xsl:text>for( var _</xsl:text><xsl:value-of select="." /><xsl:text> = 0; _</xsl:text>
		<xsl:value-of select="." /><xsl:text> &lt; </xsl:text><xsl:text>obj2copy.</xsl:text><xsl:value-of select="." />
		<xsl:text>.length; ++_</xsl:text><xsl:value-of select="." /><xsl:text>) {</xsl:text><xsl:call-template name="cr" />
		<xsl:value-of select="$gTab" /><xsl:value-of select="$gTab" /><xsl:text>retValue.</xsl:text><xsl:value-of select="." /><xsl:text>[_</xsl:text><xsl:value-of select="." /><xsl:text>]</xsl:text>
			<xsl:text> = </xsl:text>				
				<xsl:call-template name="CallMethod">				
					<xsl:with-param name="class" select="/classes/class[@id=$id]" />
					<xsl:with-param name="method" select='"GetCopyOf"' />
				</xsl:call-template>	
				<xsl:text>(</xsl:text><xsl:text>obj2copy.</xsl:text><xsl:value-of select="." /><xsl:text>[_</xsl:text><xsl:value-of select="." /><xsl:text>]</xsl:text><xsl:text>);</xsl:text>
				<xsl:call-template name="cr" />
		<xsl:value-of select="$gTab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
				
				
				</xsl:when>
				<xsl:otherwise>				
				<xsl:text>obj2copy.</xsl:text><xsl:value-of select="." /><xsl:text>;</xsl:text>
				</xsl:otherwise>			
			</xsl:choose>			
			<xsl:call-template name="cr" />
		</xsl:if>
	</xsl:for-each>
	
	<xsl:value-of select="$gTab" /><xsl:text>return retValue;</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>}</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="cr" />
</xsl:template>

<!-- printobject -->
<xsl:template match="class" mode="printobject">
	<xsl:param name="namespace" required="yes" />
	<xsl:param name="classname" required="yes" />
	<xsl:param name="objectname" required="yes" />
	
	<xsl:text>/**</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * function Print</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(object, prefix, indent, index)</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @brief Method to print information about </xsl:text><xsl:value-of select="$objectname" /><xsl:text> object.</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @code</xsl:text><xsl:call-template name="cr" />
	<xsl:text> *   var object = </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text><xsl:value-of select="$classname" />
	<xsl:text>.GetNew</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(</xsl:text>
	<xsl:for-each select="constructor/param">
		<xsl:if test="not(position()=1)"><xsl:text>, </xsl:text></xsl:if>
		<xsl:choose>
			<xsl:when test="@type='string'"><xsl:text>&quot;kalle&quot;</xsl:text></xsl:when>
			<xsl:when test="@type='float'"><xsl:text>123.456</xsl:text></xsl:when>
			<xsl:when test="@type='int'"><xsl:text>123456</xsl:text></xsl:when>
			<xsl:otherwise><xsl:text>object</xsl:text></xsl:otherwise>
		</xsl:choose>
	</xsl:for-each>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	<xsl:text> *   </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text><xsl:value-of select="$classname" />
	<xsl:text>.Print</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(object, "", 1);</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @endcode</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @param [in] object </xsl:text><xsl:value-of select="$objectname" /><xsl:text> object.</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @param [in] prefix string with any text to add to the printout.</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @param [in] indent int with number of indents to add.</xsl:text><xsl:call-template name="cr" />
	<xsl:text> * @param [in] index int with the index to add.</xsl:text><xsl:call-template name="cr" />
	<xsl:text> */</xsl:text><xsl:call-template name="cr" />
	<xsl:text>function Print</xsl:text><xsl:value-of select="$objectname" /><xsl:text>(object, prefix, indent, index)</xsl:text><xsl:call-template name="cr" />
	<xsl:text>//*void Print</xsl:text><xsl:value-of select="$objectname" />
	<xsl:text>(</xsl:text><xsl:value-of select="$objectname" /><xsl:text> object, string prefix, int indent, int index);</xsl:text><xsl:call-template name="cr" />
	<xsl:text>{</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>if( undefined == object || null == object ) {</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>ARCHER.Log.Warning("</xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text><xsl:value-of select="$classname" />
	<xsl:text>.Print</xsl:text><xsl:value-of select="$objectname" /><xsl:text> object param is null on print!!!!");</xsl:text>
	<xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>return;</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>if( true != </xsl:text>
	<xsl:call-template name="functionIs">
		<xsl:with-param name="name" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(object) ) {</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:call-template name="tab" />
	<xsl:text>var exception = "</xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.Print</xsl:text>
	<xsl:value-of select="$objectname" />	
	<xsl:text> first param was not the expected object </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$objectname" /><xsl:text>.";</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:call-template name="tab" />
	<xsl:text>throw _COMMON.Exceptions.InvalidObjectException(exception);</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>if( undefined == prefix || null == prefix ) {</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>prefix = "";</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>if( undefined == indent || null == indent ) {</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>indent = 0;</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>if( undefined == index ) {</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>index = null;</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>var indexStr = "";</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text>if( null != index ) {</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>indexStr = "[" + index + "]";</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>var tabs = "";</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text>for ( var tbdtabs = 0; tbdtabs &lt; indent; tbdtabs++ ) {</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>tabs += "    ";</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>ARCHER.Log.Debug(tabs + prefix + "</xsl:text>
	<xsl:value-of select="$objectname" />
	<xsl:text>" + indexStr + " contains:");</xsl:text><xsl:call-template name="cr" />
	<xsl:for-each select="params/param">
		<xsl:apply-templates select="." mode="print">
			<xsl:with-param name="objectname" select="$objectname" />
			<xsl:with-param name="prefix" select="'prefix'" />
		</xsl:apply-templates>
	</xsl:for-each>
	
	<xsl:text>}</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="cr" />
</xsl:template>

<xsl:template match="param" mode="print">
	<xsl:param name="objectname" required="yes" />
	<xsl:param name="prefix" required="yes" />

	<xsl:if test="@array='yes'">
		<xsl:value-of select="$gTab" /><xsl:text>for( var _</xsl:text><xsl:value-of select="." /><xsl:text> = 0; _</xsl:text>
		<xsl:value-of select="." /><xsl:text> &lt; </xsl:text><xsl:text>object.</xsl:text><xsl:value-of select="." />
		<xsl:text>.length; _</xsl:text><xsl:value-of select="." /><xsl:text>++) {</xsl:text><xsl:call-template name="cr" />
	</xsl:if>
	
	<xsl:call-template name="print">
		<xsl:with-param name="objectname" select="$objectname" />
		<xsl:with-param name="object" select="." />
		<xsl:with-param name="prefix" select="'prefix'" />
		<xsl:with-param name="indent">
			<xsl:if test="@array='yes'">
				<xsl:value-of select="$gTab" />
			</xsl:if>
		</xsl:with-param>
	</xsl:call-template>
	
	<xsl:if test="@array='yes'">
		<xsl:value-of select="$gTab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	</xsl:if>	
</xsl:template>

<xsl:template match="param[@id]" mode="print">
	<xsl:param name="objectname" required="yes" />
	<xsl:param name="prefix" required="yes" />
	<xsl:variable name="id" select="@id" />

	<xsl:if test="@array='yes'">
		<xsl:value-of select="$gTab" /><xsl:text>for( var _</xsl:text><xsl:value-of select="." /><xsl:text> = 0; _</xsl:text>
		<xsl:value-of select="." /><xsl:text> &lt; </xsl:text><xsl:text>object.</xsl:text><xsl:value-of select="." />
		<xsl:text>.length; _</xsl:text><xsl:value-of select="." /><xsl:text>++) {</xsl:text><xsl:call-template name="cr" />
	</xsl:if>
	
	<xsl:if test="@array='yes'"><xsl:value-of select="$gTab" /></xsl:if>
	<xsl:value-of select="$gTab" />
	<xsl:for-each select="../../..">
		<xsl:apply-templates select="class" mode="callprint">
			<xsl:with-param name="id" select="$id" />
		</xsl:apply-templates>
	</xsl:for-each>
	<xsl:text>(object</xsl:text>
	<xsl:text>.</xsl:text><xsl:value-of select="." /><xsl:if test="@array"><xsl:text>[_</xsl:text><xsl:value-of select="." />
	<xsl:text>]</xsl:text></xsl:if>
	<xsl:text>, prefix + "</xsl:text><xsl:value-of select="$objectname" />
	<xsl:text>" + indexStr + "."</xsl:text>
	<xsl:text>, indent + 1</xsl:text>
	<xsl:if test="@array='yes'">
			<xsl:text>, _</xsl:text><xsl:value-of select="." />
	</xsl:if>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	
	<xsl:if test="@array='yes'">
		<xsl:value-of select="$gTab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	</xsl:if>
</xsl:template>

<xsl:template name="print">
	<xsl:param name="objectname" required="yes" />
	<xsl:param name="object" required="yes" />
	<xsl:param name="prefix" required="yes" />
	<xsl:param name="index" required="no" />
	<xsl:param name="indent" required="no" />
	
	<xsl:if test="$indent"><xsl:value-of select="$indent" /></xsl:if>
	<xsl:value-of select="$gTab" /><xsl:text>ARCHER.Log.Debug(tabs + "    " + </xsl:text>
	<xsl:value-of select="$prefix" /><xsl:text> + "</xsl:text>
	<xsl:value-of select="$objectname" />
	<xsl:text>" + indexStr + ".</xsl:text><xsl:value-of select="$object" />
	<xsl:text> = " + object</xsl:text><xsl:if test="$index"><xsl:text>[</xsl:text><xsl:value-of select="$index" />
	<xsl:text>]</xsl:text></xsl:if>
	<xsl:text>.</xsl:text><xsl:value-of select="$object" /><xsl:text>);</xsl:text><xsl:call-template name="cr" />
</xsl:template>

<xsl:template match="class" mode="callprint">
	<xsl:param name="id" required="yes" />
	
	<xsl:if test="@id = $id">
		<xsl:value-of select="@namespace" /><xsl:text>.</xsl:text><xsl:value-of select="@classname" />
		<xsl:text>.Print</xsl:text><xsl:value-of select="objectname" />
	</xsl:if>
	
</xsl:template>



</xsl:stylesheet>