<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:output method="xml" media-type="text\xml" />
	
	<xsl:template match="/sourceTest">
		<xsl:element name="sourceTest_NEW">
			<xsl:element name="Nom">
				<xsl:value-of select="name" />
			</xsl:element>
			
			<xsl:element name="Telephone">
				<xsl:value-of select="phone" />
			</xsl:element>
		</xsl:element>
	</xsl:template>

</xsl:stylesheet>
