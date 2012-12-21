
<xsl:stylesheet
	version="2.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:xs="http://www.w3.org/2001/XMLSchema"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	xmlns:util="utilities:date-functions:now"
	exclude-result-prefixes="util msxsl"
>

<xsl:template match="class" mode="class">
	<xsl:param name="namespace" required="yes" />
	<xsl:param name="classname" required="yes" />
	<xsl:param name="objectname" required="yes" />
	
	<xsl:text>//*protected:</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>/**</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * function </xsl:text><xsl:value-of select="$objectname" /><xsl:text>(</xsl:text>
	<xsl:for-each select="constructor/param">
		<xsl:if test="position() != 1"><xsl:text>, </xsl:text></xsl:if>
		<xsl:value-of select="." />
	</xsl:for-each>
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> * @brief Class that holds information about </xsl:text><xsl:value-of select="$objectname" /><xsl:text>.</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text> */</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>//*class </xsl:text><xsl:value-of select="$objectname" /><xsl:text> {</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>//*public:</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>function </xsl:text><xsl:value-of select="$objectname" /><xsl:text>(</xsl:text>
	<xsl:for-each select="constructor/param">
		<xsl:if test="position() != 1"><xsl:text>, </xsl:text></xsl:if>
		<xsl:value-of select="." />
	</xsl:for-each>
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>{</xsl:text><xsl:call-template name="cr" />
	
	<xsl:apply-templates select="params/param" mode="class" />
	
	<xsl:call-template name="cr" />
	
	<xsl:if test="init">
		<xsl:apply-templates select="init" mode="classinit">
			<xsl:with-param name="objectname" select="$objectname" />
		</xsl:apply-templates>
		<xsl:call-template name="cr" />
	</xsl:if>
	
	<!--xsl:apply-templates select="params/param" mode="classsetget">
		<xsl:with-param name="objectname" select="$objectname" />
	</xsl:apply-templates-->
	
	<xsl:text>}</xsl:text><xsl:call-template name="cr" />
	
	<xsl:text>//*};</xsl:text><xsl:call-template name="cr" />
	
</xsl:template>

<xsl:template match="init" mode="classinit">
	<xsl:param name="objectname" required="yes" />
	
	<xsl:call-template name="tab" /><xsl:text>/**</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text> * function init()</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text> * @brief Method to init a </xsl:text><xsl:value-of select="$objectname" /><xsl:text> type.</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text> * @code</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text> *   var object = new </xsl:text><xsl:value-of select="$objectname" /><xsl:text>();</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text> *   object.init();</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text> *   return object;</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text> * @endcode</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text> */</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text>this.init = function(</xsl:text>
	<xsl:if test="params/param">
		<xsl:for-each select="params/param">
			<xsl:if test="position() != 1"><xsl:text>, </xsl:text></xsl:if>
			<xsl:value-of select="." />
		</xsl:for-each>
	</xsl:if>
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	<xsl:call-template name="tab" /><xsl:text>{</xsl:text><xsl:call-template name="cr" />
	<xsl:apply-templates select="method" mode="classinit">
		<xsl:with-param name="indent" select="concat($gTab,$gTab)" />
	</xsl:apply-templates>
	<xsl:call-template name="tab" /><xsl:text>};</xsl:text><xsl:call-template name="cr" />
</xsl:template>

<xsl:template match="method" mode="classinit">
	<xsl:param name="indent" required="no" />
	<xsl:variable name="method" select="@name" />
	<xsl:variable name="assignTo" select="@assignTo" />
	
	<xsl:if test="$indent"><xsl:value-of select="$indent" /></xsl:if>
	<xsl:if test="$assignTo"><xsl:value-of select="$assignTo" /> <xsl:text> = </xsl:text></xsl:if>
	<xsl:value-of select="$method" /><xsl:text>(</xsl:text>
	<xsl:for-each select="param">
		<xsl:if test="position() != 1">, </xsl:if>
		<xsl:value-of select="." />
	</xsl:for-each>
	<xsl:text>);</xsl:text>
	<xsl:call-template name="cr" />
</xsl:template>

<xsl:template match="param" mode="class">
	<xsl:variable name="type" select="@type" />
	<xsl:variable name="init" select="@init" />
	<xsl:variable name="comment" select="@comment" />
	<xsl:variable name="isArray" select="@array" />
	
	<xsl:call-template name="tab" /><xsl:text>//*</xsl:text><xsl:value-of select="$type" /><xsl:text> </xsl:text><xsl:value-of select="." /><xsl:text>;</xsl:text>
	<xsl:call-template name="tab" />
	<xsl:text>///&lt; </xsl:text>
	<xsl:choose>
		<xsl:when test="$comment">
			<xsl:value-of select="$comment" />
		</xsl:when>
		<xsl:otherwise>
			<xsl:text>[</xsl:text><xsl:value-of select="$type" /><xsl:text>]</xsl:text>
		</xsl:otherwise>
	</xsl:choose>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>this.</xsl:text><xsl:value-of select="." />
	<xsl:text> = </xsl:text>
	<xsl:choose>
		<xsl:when test="$init and $init=../../constructor/param">
			<xsl:text>( undefined == </xsl:text><xsl:value-of select="$init" />
			<xsl:text> ) ? null : </xsl:text><xsl:value-of select="$init" />
		</xsl:when>
		<xsl:when test="$init">
			<xsl:value-of select="$init" />
		</xsl:when>
		<xsl:when test="$isArray = 'yes'">
			<xsl:text>new Array()</xsl:text>
		</xsl:when>
		<xsl:otherwise>
			<xsl:text>null</xsl:text>
		</xsl:otherwise>
	</xsl:choose>
	<xsl:text>;</xsl:text>
	<xsl:call-template name="cr" />
</xsl:template>

<xsl:template match="param" mode="classsetget">
	<xsl:param name="objectname" required="yes" />
	
	<xsl:call-template name="classset">
		<xsl:with-param name="objectname" select="$objectname" />
		<xsl:with-param name="name" select="." />
		<xsl:with-param name="type" select="@type" />
		<xsl:with-param name="init" select="@init" />
		<xsl:with-param name="comment" select="@comment" />
		<xsl:with-param name="isArray" select="@array" />
	</xsl:call-template>
	
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="classget">
		<xsl:with-param name="objectname" select="$objectname" />
		<xsl:with-param name="name" select="." />
		<xsl:with-param name="type" select="@type" />
		<xsl:with-param name="init" select="@init" />
		<xsl:with-param name="comment" select="@comment" />
		<xsl:with-param name="isArray" select="@array" />
	</xsl:call-template>
	
	<xsl:call-template name="cr" />
	
</xsl:template>

<xsl:template name="classset">
	<xsl:param name="objectname" required="yes" />
	<xsl:param name="name" required="yes" />
	<xsl:param name="type" required="yes" />
	<xsl:param name="init" required="no" />
	<xsl:param name="comment" required="no" />
	<xsl:param name="isArray" required="no" />
	
	<xsl:call-template name="tab" /><xsl:text>/**</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> * function </xsl:text>
	<xsl:call-template name="functionSet">
		<xsl:with-param name="name" select="$name" />
	</xsl:call-template>
	<xsl:text>(_</xsl:text><xsl:value-of select="$name" /><xsl:text>)</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> * @brief Method to set </xsl:text><xsl:value-of select="$name" /><xsl:text>.</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> * @code</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> *   var object = new </xsl:text><xsl:value-of select="$objectname" /><xsl:text>();</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> *   object.</xsl:text>
	<xsl:call-template name="functionSet">
		<xsl:with-param name="name" select="$name" />
	</xsl:call-template>
	<xsl:text>(</xsl:text>
	<xsl:choose>
		<xsl:when test="$type='string'"><xsl:text>"test"</xsl:text></xsl:when>
		<xsl:when test="$type='float'"><xsl:text>1234,5678</xsl:text></xsl:when>
		<xsl:when test="$type='int'"><xsl:text>1234</xsl:text></xsl:when>
		<xsl:otherwise><xsl:value-of select="$name" /></xsl:otherwise>
	</xsl:choose>
	<xsl:if test="$isArray='yes'">
		<xsl:text>, index</xsl:text>
	</xsl:if>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> * @endcode</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> * @param [in] _</xsl:text><xsl:value-of select="$name" /><xsl:text> </xsl:text>
	<xsl:value-of select="$type" /><xsl:if test="$comment"><xsl:text> </xsl:text><xsl:value-of select="$comment" /></xsl:if>
	<xsl:call-template name="cr"/>
	
	<xsl:if test="$isArray = 'yes'">
		<xsl:call-template name="tab" /><xsl:text> * @param [in] index int Index to set object to.</xsl:text>
		<xsl:call-template name="cr" />
	</xsl:if>
	
	<xsl:call-template name="tab" /><xsl:text> */</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>this.</xsl:text>
	<xsl:call-template name="functionSet">
		<xsl:with-param name="name" select="$name" />
	</xsl:call-template>
	<xsl:text> = function(_</xsl:text><xsl:value-of select="$name" />
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>, index</xsl:text>
	</xsl:if>
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>//*void </xsl:text>
	<xsl:call-template name="functionSet">
		<xsl:with-param name="name" select="$name" />
	</xsl:call-template>
	<xsl:text>(</xsl:text><xsl:value-of select="$type" /><xsl:text> _</xsl:text><xsl:value-of select="$name" /><xsl:text>);</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>{</xsl:text><xsl:call-template name="cr" />
	
	<xsl:if test="$isArray = 'yes'">
		<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>if( null == index ) {</xsl:text><xsl:call-template name="cr" />
		<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:call-template name="tab" />
		<xsl:text>index = this.</xsl:text><xsl:value-of select="$name" /><xsl:text>.length;</xsl:text><xsl:call-template name="cr" />
		<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>}</xsl:text><xsl:call-template name="cr" />
	</xsl:if>
	
	<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>this.</xsl:text><xsl:value-of select="$name" />
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>[index]</xsl:text>
	</xsl:if>
	<xsl:text> = _</xsl:text><xsl:value-of select="$name" /><xsl:text>;</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>};</xsl:text><xsl:call-template name="cr" />
	
</xsl:template>

<xsl:template name="classget">
	<xsl:param name="objectname" required="yes" />
	<xsl:param name="name" required="yes" />
	<xsl:param name="type" required="yes" />
	<xsl:param name="init" required="no" />
	<xsl:param name="comment" required="no" />
	<xsl:param name="isArray" required="no" />
	
	<xsl:call-template name="tab" /><xsl:text>/**</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> * function </xsl:text>
	<xsl:call-template name="functionGet">
		<xsl:with-param name="name" select="$name" />
	</xsl:call-template>
	<xsl:text>()</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> * @brief Method to get </xsl:text><xsl:value-of select="$name" /><xsl:text>.</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> * @code</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> *   var object = new </xsl:text><xsl:value-of select="$objectname" /><xsl:text>();</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> *   var value = object.</xsl:text>
	<xsl:call-template name="functionGet">
		<xsl:with-param name="name" select="$name" />
	</xsl:call-template>
	<xsl:text>(</xsl:text>
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>index</xsl:text>
	</xsl:if>
	<xsl:text>);</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> * @endcode</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text> * @return </xsl:text><xsl:value-of select="$type" /><xsl:if test="$comment"><xsl:text> </xsl:text>
	<xsl:value-of select="$comment" /></xsl:if><xsl:call-template name="cr"/>
	
	<xsl:if test="$isArray = 'yes'">
		<xsl:call-template name="tab" /><xsl:text> * @param [in] index int Index to get object from.</xsl:text>
		<xsl:call-template name="cr" />
	</xsl:if>
	
	<xsl:call-template name="tab" /><xsl:text> */</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>this.</xsl:text>
	<xsl:call-template name="functionGet">
		<xsl:with-param name="name" select="$name" />
	</xsl:call-template>
	<xsl:text> = function(</xsl:text>
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>index</xsl:text>
	</xsl:if>
	<xsl:text>)</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>//*</xsl:text><xsl:value-of select="$type" /><xsl:text> </xsl:text>
	<xsl:call-template name="functionGet">
		<xsl:with-param name="name" select="$name" />
	</xsl:call-template>
	<xsl:text>();</xsl:text>
	<xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>{</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:call-template name="tab" /><xsl:text>return this.</xsl:text><xsl:value-of select="$name" />
	<xsl:if test="$isArray = 'yes'">
		<xsl:text>[index]</xsl:text>
	</xsl:if>
	<xsl:text>;</xsl:text><xsl:call-template name="cr" />
	
	<xsl:call-template name="tab" /><xsl:text>};</xsl:text><xsl:call-template name="cr" />
	
</xsl:template>

</xsl:stylesheet>
