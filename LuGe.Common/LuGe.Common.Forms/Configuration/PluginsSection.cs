/*
 * User: lgermain
 * Date: 16/09/2008 14:13
 */

using System;
using System.Configuration;

namespace LuGe.Common.Forms.Configuration
{
	/// <summary>
	/// Represents a specific section within a configuration file that
	/// holds informations about plugins.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The configuration file of the application must contains the declaration
	/// of this custom section as in the example below :
	/// <example>
	/// &lt;configSections&gt;
	/// 	&lt;section name="plugins" type="LuGe.Common.Forms.Configuration.PluginsSection, LuGe.Common.Forms.Configuration" /&gt;
	/// &lt;/configSections&gt;
	/// </example>
	/// </para>
	/// 
	/// <para>
	/// The example below shows how to declare the elements of the section :
	/// <example>
	/// &lt;tools&gt;
	///		&lt;pluginInfo
	/// 		name="XML Document"
	///			pluginType="ChildForm"
	///			assembly="Itron.Quality.ERHToolbox.exe" 
	///			type="Itron.Quality.ERHToolbox.childForms.XmlDocumentForm"
	///  	/&gt;
	/// &lt;/tools&gt;
	/// </example>
	/// </para>
	/// </remarks>
	public class PluginsSection : ConfigurationSection
	{
		#region Fields
		
		private static readonly ConfigurationPropertyCollection _properties;
		private static readonly ConfigurationProperty _list;
		
		#endregion
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the class. 
		/// </summary>
		static PluginsSection()
		{
			_list = new ConfigurationProperty(
				"",
				typeof(PluginInfoElementCollection),
				null,
				ConfigurationPropertyOptions.IsRequired
				| ConfigurationPropertyOptions.IsDefaultCollection);
			
			_properties = new ConfigurationPropertyCollection();
			_properties.Add(_list);
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the section name as defined in the configuration file.
		/// </summary>
		public static string SectionName
		{
			get { return "plugins"; }
		}
		
		/// <summary>
		/// Gets the collection of <see cref="PluginInfoElement">PluginInfoElement</see> 
		/// in this section.
		/// </summary>
		public PluginInfoElementCollection List
		{
			get { return (PluginInfoElementCollection)base[_list]; }
		}

        /// <summary>
        /// Gets or sets a property, attribute, or child element of 
        /// this configuration element.
        /// </summary>
		public new PluginInfoElement this[string name]
		{
			get { return List[name]; }
		}

		/// <summary>
		/// Gets the collection of properties.
		/// </summary>
		protected override ConfigurationPropertyCollection Properties
		{
			get { return _properties; }
		}
		
		#endregion
		
		#region Methods
		
		#endregion
	}
}
