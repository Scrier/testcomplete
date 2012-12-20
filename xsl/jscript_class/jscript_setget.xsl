
<xsl:stylesheet
	version="2.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xs="http://www.w3.org/2001/XMLSchema"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	xmlns:util="utilities:date-functions:now"
	exclude-result-prefixes="util msxsl"
>

<xsl:template match="param" mode="setget">
	<xsl:param name="namespace" required="yes" />
	<xsl:param name="classname" required="yes" />
	<xsl:param name="objectname" required="yes" />
	
	<xsl:call-template name="objectset">
		<xsl:with-param name="object" select="." />
		<xsl:with-param name="type" select="@type" />
		<xsl:with-param name="namespace" select="$namespace" />
		<xsl:with-param name="classname" select="$classname" />
		<xsl:with-param name="objectname" select="$objectname" />
		<xsl:with-param name="isArray" select="@array" />
		<xsl:with-param name="validate" select="@validate" />
		<xsl:with-param name="validateType" select="@type" />
		<xsl:with-param name="comment" select="@comment" />
	</xsl:call-template>
	
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="objectget">
		<xsl:with-param name="object" select="." />
		<xsl:with-param name="type" select="@type" />
		<xsl:with-param name="namespace" select="$namespace" />
		<xsl:with-param name="classname" select="$classname" />
		<xsl:with-param name="objectname" select="$objectname" />
		<xsl:with-param name="isArray" select="@array" />
		<xsl:with-param name="comment" select="@comment" />
	</xsl:call-template>
	
	<xsl:call-template name="cr" />
	
</xsl:template>

<xsl:template name="objectset">
	<xsl:param name="object" required="yes" />
	<xsl:param name="type" required="yes" />
	<xsl:param name="namespace" required="yes" />
	<xsl:param name="classname" required="yes" />
	<xsl:param name="objectname" required="yes" />
	<xsl:param name="isArray" required="no" />
	<xsl:param name="validate" required="no" />
	<xsl:param name="validateType" required="no" />
	<xsl:param name="comment" required="no" />
	
	<xsl:text>/**</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * function </xsl:text>
	<xsl:call-template name="functionSet">
		<xsl:with-param name="name" select="$object" />
		<xsl:with-param name="extra" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>, value)</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:text> * @brief Method to set </xsl:text><xsl:value-of select="$objectname" />
	<xsl:text>.</xsl:text><xsl:value-of select="$object" /><xsl:text>.</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @code</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> *   var </xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text> = </xsl:text><xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.GetNew</xsl:text>
	<xsl:value-of select="$objectname" /><xsl:text>();</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> *   </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text>
	<xsl:call-template name="functionSet">
		<xsl:with-param name="name" select="$object" />
		<xsl:with-param name="extra" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>, value);</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @endcode</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @param [in] </xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text> </xsl:text><xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text><xsl:value-of select="$objectname" />
	<xsl:text> object.</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @param [in] value </xsl:text><xsl:value-of select="$type" />
	<xsl:if test="$comment"><xsl:text> </xsl:text><xsl:value-of select="$comment" /></xsl:if>
	<xsl:call-template name="cr" />
	
	<xsl:if test="$isArray = 'yes'">
		<xsl:text> * @param [in] index int Index to add the object to, optional, if not set added to last.</xsl:text>
		<xsl:call-template name="cr" />
	</xsl:if>
	
	<xsl:text> */</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>function </xsl:text>
	<xsl:call-template name="functionSet">
		<xsl:with-param name="name" select="$object" />
		<xsl:with-param name="extra" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>, value</xsl:text>
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>, index</xsl:text>
	</xsl:if>
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>//*void </xsl:text>
	<xsl:call-template name="functionSet">
		<xsl:with-param name="name" select="$object" />
		<xsl:with-param name="extra" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="$objectname" /><xsl:text> </xsl:text>
	<xsl:value-of select="lower-case($objectname)" /><xsl:text>, </xsl:text>
	<xsl:value-of select="$type" /><xsl:text> value</xsl:text>
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>, int index</xsl:text>
	</xsl:if>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>{</xsl:text><xsl:call-template name="cr" />
	
	<xsl:if test="$isArray = 'yes'">
		<xsl:call-template name="tab" /><xsl:text>if( undefined == index ) {</xsl:text><xsl:call-template name="cr" />
		<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>index = null;</xsl:text><xsl:call-template name="cr" />
		<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	</xsl:if>
	
	<xsl:call-template name="tab" /><xsl:text>if( true != </xsl:text>
	<xsl:call-template name="functionIs">
		<xsl:with-param name="name" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>) ) {</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:call-template name="tab" />
	<xsl:text>var exception = "</xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text>
	<xsl:call-template name="functionSet">
		<xsl:with-param name="name" select="$object" />
		<xsl:with-param name="extra" select="$objectname" />
	</xsl:call-template>
	<xsl:text> first param was not the expected object </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$objectname" /><xsl:text>.";</xsl:text>
	<xsl:call-template name="cr" />

	<xsl:call-template name="tab" /><xsl:call-template name="tab" />
	<xsl:text>throw _COMMON.Exceptions.InvalidObjectException(exception);</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:if test="$validate">
		<xsl:call-template name="tab" /><xsl:text>if( true != </xsl:text>
		<xsl:value-of select="$validate" />
		<xsl:text>(value) ) {</xsl:text><xsl:call-template name="cr" />
		
		<xsl:call-template name="tab" /><xsl:call-template name="tab" />
		<xsl:text>var exception = "</xsl:text>
		<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
		<xsl:value-of select="$classname" /><xsl:text>.</xsl:text>
		<xsl:call-template name="functionSet">
			<xsl:with-param name="name" select="$object" />
			<xsl:with-param name="extra" select="$objectname" />
		</xsl:call-template>
		<xsl:text> second param was not the expected object</xsl:text>
		<xsl:if test="$validateType">
			<xsl:text> </xsl:text><xsl:value-of select="$validateType" />
		</xsl:if>
		<xsl:text>.";</xsl:text>
		<xsl:call-template name="cr" />

		<xsl:call-template name="tab" /><xsl:call-template name="tab" />
		<xsl:text>throw _COMMON.Exceptions.InvalidObjectException(exception);</xsl:text>
		<xsl:call-template name="cr" />
		
		<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	</xsl:if>
	
	<xsl:call-template name="tab" /><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>.</xsl:text>
	<xsl:value-of select="$object" />
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>[index]</xsl:text>
	</xsl:if>
	<xsl:text> = value;</xsl:text><xsl:call-template name="cr" />
	<!--xsl:call-template name="functionSet">
		<xsl:with-param name="name" select="$object" />
	</xsl:call-template>
	<xsl:text>(value</xsl:text>
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>, index</xsl:text>
	</xsl:if>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" /-->
	
	<xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
</xsl:template>

<xsl:template name="objectget">
	<xsl:param name="object" required="yes" />
	<xsl:param name="type" required="yes" />
	<xsl:param name="namespace" required="yes" />
	<xsl:param name="classname" required="yes" />
	<xsl:param name="objectname" required="yes" />
	<xsl:param name="isArray" required="no" />
	<xsl:param name="comment" required="no" />
	
	<xsl:text>/**</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * function </xsl:text>
	<xsl:call-template name="functionGet">
		<xsl:with-param name="name" select="$object" />
		<xsl:with-param name="extra" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>)</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:text> * @brief Method to get </xsl:text><xsl:value-of select="$objectname" />
	<xsl:text>.</xsl:text><xsl:value-of select="$object" /><xsl:text>.</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @code</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> *   var </xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text> = </xsl:text><xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.GetNew</xsl:text>
	<xsl:value-of select="$objectname" /><xsl:text>();</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> *   var value = </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text>
	<xsl:call-template name="functionGet">
		<xsl:with-param name="name" select="$object" />
		<xsl:with-param name="extra" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @endcode</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @param [in] </xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text> </xsl:text><xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text><xsl:value-of select="$objectname" />
	<xsl:text> object.</xsl:text><xsl:call-template name="cr" />
	
	<xsl:if test="$isArray = 'yes'">
		<xsl:text> * @param [in] index int Index to get object from.</xsl:text>
		<xsl:call-template name="cr" />
	</xsl:if>
	
	<xsl:text> * @return </xsl:text><xsl:value-of select="$type" />
	<xsl:if test="$comment"><xsl:text> </xsl:text><xsl:value-of select="$comment" /></xsl:if>
	<xsl:call-template name="cr" />
	
	<xsl:text> */</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>function </xsl:text>
	<xsl:call-template name="functionGet">
		<xsl:with-param name="name" select="$object" />
		<xsl:with-param name="extra" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>, index</xsl:text>
	</xsl:if>
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>//*</xsl:text><xsl:value-of select="$type" />
	<xsl:text> </xsl:text>
	<xsl:call-template name="functionGet">
		<xsl:with-param name="name" select="$object" />
		<xsl:with-param name="extra" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="$objectname" /><xsl:text> </xsl:text>
	<xsl:value-of select="lower-case($objectname)" />
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>, int index</xsl:text>
	</xsl:if>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>{</xsl:text><xsl:call-template name="cr" />
	
	<xsl:if test="$isArray = 'yes'">
		<xsl:call-template name="tab" /><xsl:text>if( undefined == index || null == index ) {</xsl:text><xsl:call-template name="cr" />
		<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>index = 0;</xsl:text><xsl:call-template name="cr" />
		<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	</xsl:if>
	
	<xsl:call-template name="tab" /><xsl:text>if( true != </xsl:text>
	<xsl:call-template name="functionIs">
		<xsl:with-param name="name" select="$objectname" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="lower-case($objectname)" />
	<xsl:text>) ) {</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:call-template name="tab" />
	<xsl:text>var exception = "</xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text>
	<xsl:call-template name="functionGet">
		<xsl:with-param name="name" select="$object" />
		<xsl:with-param name="extra" select="$objectname" />
	</xsl:call-template>
	<xsl:text> first param was not the expected object </xsl:text>
	<xsl:value-of select="$namespace" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$classname" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$objectname" /><xsl:text>.";</xsl:text>
	<xsl:call-template name="cr" />

	<xsl:call-template name="tab" /><xsl:call-template name="tab" />
	<xsl:text>throw _COMMON.Exceptions.InvalidObjectException(exception);</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>return </xsl:text>
	<xsl:value-of select="lower-case($objectname)" /><xsl:text>.</xsl:text>
	<xsl:value-of select="$object" />
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>[index]</xsl:text>
	</xsl:if>
	<xsl:text>;</xsl:text><xsl:call-template name="cr" />
	<!--xsl:call-template name="functionGet">
		<xsl:with-param name="name" select="$object" />
	</xsl:call-template>
	<xsl:text>(</xsl:text>
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>index</xsl:text>
	</xsl:if>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" /-->
	
	<xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
</xsl:template>

</xsl:stylesheet>
