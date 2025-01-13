/*
 * User: lgermain
 * Date: 16/09/2008 14:17
 */

using System;
using System.Configuration;
using System.Collections.Generic;
using LuGe.Common.Collection;

namespace LuGe.Common.Forms.Configuration
{
	/// <summary>
	/// Represents a collection of <see cref="PluginInfoElement">PluginInfoElement</see>.
	/// </summary>
	public class PluginInfoElementCollection : ConfigurationElementCollection
	{
		#region Fields
		
		#endregion
		
		#region Constructors
			
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the type of the ConfigurationElementCollection. 
		/// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        
        /// <summary>
        /// Gets the element name as defined in the configuration file.
        /// </summary>
        protected override string ElementName
        {
            get { return "pluginInfo"; }
        }

        /// <summary>
        /// Gets the collection of properties.
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get { return new ConfigurationPropertyCollection(); }
        }

        /// <summary>
        /// Gets or sets a property, attribute, or child element of
        ///  this configuration element.
        /// </summary>
        public PluginInfoElement this[int index]
        {
            get { return (PluginInfoElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                base.BaseAdd(index, value);
            }
        }

        /// <summary>
        /// Gets or sets a property, attribute, or child element of 
        /// this configuration element.
        /// </summary>
        public new PluginInfoElement this[string name]
        {
            get { return (PluginInfoElement)BaseGet(name); }
        }
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Find the specified plugin name in the list and returns it.
		/// </summary>
		/// <param name="name">Name of the plugin.</param>
		/// <returns>The plugin finds in the list. Null if not.</returns>
		public PluginInfoElement Find(string name)
		{
			foreach(PluginInfoElement element in this)
			{
				if (element.Name == name) return element;
			}
			
			return null;
		}
		
		/// <summary>
		/// Adds a <see cref="PluginInfoElement">PluginInfoElement</see> 
		/// to the collection.
		/// </summary>
		/// <param name="item">The element to add.</param>
        public void Add(PluginInfoElement item)
        {
            BaseAdd(item);
        }

		/// <summary>
		/// Removes a <see cref="PluginInfoElement">PluginInfoElement</see> 
		/// from the collection.
		/// </summary>
		/// <param name="item">The element to remove.</param>
        public void Remove(PluginInfoElement item)
        {
            BaseRemove(item);
        }

		/// <summary>
		/// Removes the <see cref="PluginInfoElement">PluginInfoElement</see> 
		/// at the specified index location.
		/// </summary>
        /// <param name="index">The index location of the element to remove.</param>
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        /// <summary>
        /// Removes all configuration element objects from the collection.
        /// </summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// Creates a new <see cref="PluginInfoElement">PluginInfoElement</see>.
        /// </summary>
        /// <returns>A new element.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new PluginInfoElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element.
        /// </summary>
        /// <param name="element">The element to return the key for.</param>
        /// <returns>An Object that acts as the key for the specified element.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element != null)
                return ((PluginInfoElement)element).Name;
            else
                return null;
        }
        
		#endregion
	}
}
