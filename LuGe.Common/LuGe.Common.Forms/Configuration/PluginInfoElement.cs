/*
 * User: lgermain
 * Date: 16/09/2008 14:19
 */

using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using LuGe.Common;
using LuGe.Common.Collection;

namespace LuGe.Common.Forms.Configuration
{
	/// <summary>
	/// Class that hold the necessary data to manage a plugin.
	/// </summary>
	public sealed class PluginInfoElement : ConfigurationElement
	{
		#region Fields
		
		private static readonly ConfigurationPropertyCollection _properties; // The collection (property bag) that contains the section properties.
		
		private static readonly ConfigurationProperty _name;  // Name of the plugin for the end-user.
		private static readonly ConfigurationProperty _description;  // Description of the plugin for the end-user.
		private static readonly ConfigurationProperty _category; // Category of plugin.
		private static readonly ConfigurationProperty _kind; // Kind of plugin ( document, toolbar ...).
		private static readonly ConfigurationProperty _assembly; // Assembly that hold the type to instanciate.
		private static readonly ConfigurationProperty _type; // Concrete type to instanciate.
		private static readonly ConfigurationProperty _image; // Image to represent the plugin to the end-user.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		static PluginInfoElement()
		{
			_name = new ConfigurationProperty(
				"name", typeof(string), "",
				ConfigurationPropertyOptions.IsKey);
			_description = new ConfigurationProperty(
				"description", typeof(string), "",
				ConfigurationPropertyOptions.IsRequired);
			_category = new ConfigurationProperty(
				"category", typeof(string), "",
				ConfigurationPropertyOptions.IsRequired);
			_kind = new ConfigurationProperty(
				"kind", typeof(string), "",
				ConfigurationPropertyOptions.IsRequired);
			_assembly = new ConfigurationProperty(
				"assembly", typeof(string), "",
				ConfigurationPropertyOptions.IsRequired);
			_type = new ConfigurationProperty(
				"type", typeof(string), "",
				ConfigurationPropertyOptions.IsRequired);
			_image = new ConfigurationProperty(
				"image", typeof(string), "",
				ConfigurationPropertyOptions.IsRequired);

			// Property initialization
			_properties = new ConfigurationPropertyCollection();

			_properties.Add(_name);
			_properties.Add(_description);
			_properties.Add(_category);
			_properties.Add(_kind);
			_properties.Add(_assembly);
			_properties.Add(_type);
			_properties.Add(_image);
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the initialized property bag.
		/// </summary>
		protected override ConfigurationPropertyCollection Properties
		{
			get { return _properties; }
		}

		/// <summary>
		/// Gets or sets the name of the plugin for the end-user.
		/// </summary>
		[StringValidator(InvalidCharacters = "",
		                 MinLength = 1, MaxLength = 60)]
		public string Name {
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}
		
		/// <summary>
		/// Gets or sets the description of the plugin for the end-user.
		/// </summary>
		[RegexStringValidator ("Document|Tool")]
		public string Description {
			get { return (string)this["description"]; }
			set { this["description"] = value; }
		}
		
		/// <summary>
		/// Gets or sets the category of plugin.
		/// </summary>
		[StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|",
		                 MinLength = 1, MaxLength = 60)]
		public string Category {
			get { return (string)this["category"]; }
			set	{ this["category"] = value; }
		}
		
		/// <summary>
		/// Gets or sets the kind of plugin ( document, toolbar ...).
		/// </summary>
		[StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|",
		                 MinLength = 1, MaxLength = 60)]
		public string Kind {
			get { return (string)this["kind"]; }
			set	{ this["kind"] = value; }
		}
		
		/// <summary>
		/// Gets or sets the assembly that hold the type to instanciate.
		/// </summary>
		[StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|",
		                 MinLength = 1, MaxLength = 255)]
		public string Assembly {
			get { return (string)this["assembly"]; }
			set { this["assembly"] = value; }
		}
		
		/// <summary>
		/// Gets or sets the concrete type to instanciate.
		/// </summary>
		[StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|",
		                 MinLength = 1, MaxLength = 255)]
		public string Type {
			get { return (string)this["type"]; }
			set { this["type"] = value; }
		}
		
		/// <summary>
		/// Gets or sets the image to represent the plugin to the end-user.
		/// </summary>
		[StringValidator(InvalidCharacters = "",
		                 MinLength = 1, MaxLength = 255)]
		public string Image {
			get { return (string)this["image"]; }
			set { this["image"] = value; }
		}
		
		#endregion
		
		#region Methods

		/// <summary>
		/// Return the name of the plugin for the end-user.
		/// </summary>
		/// <returns>The name of the plugin for the end-user.</returns>
		public override string ToString()
		{
			return this.Name;
		}
		
		#endregion
		
	}
}
