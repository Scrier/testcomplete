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
<!--
* Company / Project	: BAE Systems Bofors AB / ARCHER
* This document and it's contents is the property of BAE Systems Bofors AB
* and must not be reproduced, disclosed to any party 
* or used in any unauthorized manner without written consent. 
* Author: Andreas Joelsson
* Contact Information: andreas.joelsson@baesystems.se
-->

<xsl:output method="text" />
<xsl:output method="text" indent="yes" name="text" />

<!-- includes -->
<xsl:include href="jscript_template.xsl" />
<xsl:include href="jscript_methods.xsl" />
<xsl:include href="jscript_setget.xsl" />

<!-- global includes -->
<xsl:variable name="gTab" select="'&#x9;'" />

<!-- 
Top level template 
-->
<xsl:template match="/">
	
	<!-- Createion of Source, Header and TestFiles -->
	<xsl:apply-templates select="/classes/class" />
	
	</xsl:template>

<!-- Message level templates, creates source, include and test files -->
<xsl:template match="class">
	<xsl:variable name="namespace" select="@namespace" />
	<xsl:variable name="classname" select="@classname" />
	<xsl:variable name="objectname" select="objectname" />
	<xsl:variable name="filename" select="concat($namespace,'/',$classname,'/',lower-case($objectname),'.js')" />
	
	<!-- Create Script -->
	<xsl:result-document href="{$filename}" format="text">
			
	<!--xsl:text>////////////////////////////////////////////////////////////////////////////////////////////////////</xsl:text><xsl:call-template name="cr" />
		<xsl:text>////////////////////////////////////////////////////////////////////////////////////////////////////</xsl:text><xsl:call-template name="cr" />
		<xsl:text>// START OF </xsl:text><xsl:value-of select="$objectname" /><xsl:text> </xsl:text>
		<xsl:call-template name="fillComments"><xsl:with-param name="length" select="100 - 13 - string-length($objectname)" /></xsl:call-template>
		<xsl:call-template name="cr" />
		<xsl:text>////////////////////////////////////////////////////////////////////////////////////////////////////</xsl:text><xsl:call-template name="cr" />
	<xsl:text>////////////////////////////////////////////////////////////////////////////////////////////////////</xsl:text><xsl:call-template name="cr" /-->
	
		<xsl:if test="@id = 1">
			<xsl:text>/**</xsl:text><xsl:call-template name="cr" />
			<xsl:text> * @brief _GENERATED namespace from jscript_class.xml.</xsl:text><xsl:call-template name="cr" />
			<xsl:text> */</xsl:text><xsl:call-template name="cr" />
		</xsl:if>
	
		<xsl:text>//*namespace </xsl:text><xsl:value-of select="$namespace" /><xsl:text> {</xsl:text><xsl:call-template name="cr" />
	
		<xsl:text>/**</xsl:text><xsl:call-template name="cr" />
		<xsl:text> * @author xml</xsl:text><xsl:call-template name="cr" />
		<xsl:text> * @version 1.0</xsl:text><xsl:call-template name="cr" />
		<xsl:text> */</xsl:text><xsl:call-template name="cr" />
	
		<xsl:text>//*class </xsl:text><xsl:value-of select="$classname" /><xsl:text> {</xsl:text><xsl:call-template name="cr" />
	
		<xsl:text>//*public:</xsl:text><xsl:call-template name="cr" />
		
		<xsl:apply-templates select="." mode="newobject">
			<xsl:with-param name="namespace" select="$namespace" />
			<xsl:with-param name="classname" select="$classname" />
			<xsl:with-param name="objectname" select="$objectname" />		
		</xsl:apply-templates>
		
		<xsl:apply-templates select="." mode="copyobject">
			<xsl:with-param name="namespace" select="$namespace" />
			<xsl:with-param name="classname" select="$classname" />
			<xsl:with-param name="objectname" select="$objectname" />		
		</xsl:apply-templates>
		
		<xsl:apply-templates select="." mode="printobject">
			<xsl:with-param name="namespace" select="$namespace" />
			<xsl:with-param name="classname" select="$classname" />
			<xsl:with-param name="objectname" select="$objectname" />		
		</xsl:apply-templates>
	
		<xsl:apply-templates select="params/param" mode="setget">
			<xsl:with-param name="namespace" select="$namespace" />
			<xsl:with-param name="classname" select="$classname" />
			<xsl:with-param name="objectname" select="$objectname" />		
		</xsl:apply-templates>
		
		<xsl:apply-templates select="." mode="isobject">
			<xsl:with-param name="namespace" select="$namespace" />
			<xsl:with-param name="classname" select="$classname" />
			<xsl:with-param name="objectname" select="$objectname" />		
		</xsl:apply-templates>
	
		<xsl:apply-templates select="." mode="class">
			<xsl:with-param name="namespace" select="$namespace" />
			<xsl:with-param name="classname" select="$classname" />
			<xsl:with-param name="objectname" select="$objectname" />
		</xsl:apply-templates>
		
		<!--xsl:text>////////////////////////////////////////////////////////////////////////////////////////////////////</xsl:text><xsl:call-template name="cr" />
		<xsl:text>////////////////////////////////////////////////////////////////////////////////////////////////////</xsl:text><xsl:call-template name="cr" />
		<xsl:text>// END OF </xsl:text><xsl:value-of select="$objectname" /><xsl:text> </xsl:text>
		<xsl:call-template name="fillComments"><xsl:with-param name="length" select="100 - 11 - string-length($objectname)" /></xsl:call-template>
		<xsl:call-template name="cr" />
		<xsl:text>////////////////////////////////////////////////////////////////////////////////////////////////////</xsl:text><xsl:call-template name="cr" />
		<xsl:text>////////////////////////////////////////////////////////////////////////////////////////////////////</xsl:text><xsl:call-template name="cr" /-->
		
		<xsl:call-template name="cr" />
		
		<xsl:text>//*};</xsl:text><xsl:call-template name="cr" />
		
		<xsl:call-template name="cr" />
		
		<xsl:text>//*}</xsl:text><xsl:call-template name="cr" />
		
	</xsl:result-document>

</xsl:template>

<xsl:template name="tab">
	<xsl:value-of select="$gTab" />
</xsl:template>

<xsl:template name="cr">
	<xsl:text>
</xsl:text>
</xsl:template>

<xsl:template name="replaceunderlinewithdot">
	<xsl:param name="id" required="yes" />
	<xsl:param name="result" select="substring(replace($id,'_','.'),2)" />
	<xsl:value-of select="$result" />
</xsl:template>

<xsl:template name="replacerepwithstring">
	<xsl:param name="repetition" required="yes" />
	<xsl:param name="string" required="yes" />
	<xsl:param name="result" select="replace(replace(replace(replace(replace(replace($repetition,'REP01',$string),'REP02',$string),'REP03',$string),'REP04',$string),'REP05',$string),'REP06',$string)" />
	<xsl:value-of select="$result" />
</xsl:template>

<xsl:template name="replacerepblockwithcomma">
	<xsl:param name="repetition" required="yes" />
	<xsl:param name="result" select="replace(replace(replace($repetition,'\]\[',', '),'\[',''),'\]',', ')" />
	<xsl:value-of select="$result" />
</xsl:template>

<xsl:template name="fillComments">
	<xsl:param name="length" required="yes" />
	
	<xsl:for-each select="1 to $length">
		<xsl:text>/</xsl:text>
	</xsl:for-each>
</xsl:template>

</xsl:stylesheet>