/*
 * User: lgermain
 * Date: 21/11/2008 13:41
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LuGe.Common
{
	/// <summary>
	/// Manage user configuration file.
	/// </summary>
	public sealed class LIConfiguration<T> where T : IConfigurationFile
	{
		
		#region Fields
		
		#endregion
		
		#region Constructors
		
		private LIConfiguration()
		{
		}
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Determines the file name of the configuration file
		/// from the name of the type.
		/// </summary>
		/// <returns>The file name of the configuration file.</returns>
		private static string DetermineFileName()
		{
			return DetermineFileName(null, null);
		}		
		
		/// <summary>
		/// Determines the file name of the configuration file
		/// from the name of the type.
		/// </summary>
		/// <returns>The file name of the configuration file.</returns>
		private static string DetermineFileName(String path, String configFileName)
		{
			string fileName = configFileName ?? typeof(T).Name + ".config";
			string sPath = path ?? Path.GetDirectoryName(Application.UserAppDataPath);
			
			fileName = Path.Combine(sPath, fileName);
			
			return fileName;
		}
		
		/// <summary>
		/// Load the settings.
		/// </summary>
		/// <returns>The settings.</returns>
		public static T Load()
		{
			return Load(null, null);
		}
		
		/// <summary>
		/// Load the settings.
		/// </summary>
		/// <returns>The settings.</returns>
		public static T Load(String path)
		{
			return Load(path, null);
		}
		
		/// <summary>
		/// Load the settings.
		/// </summary>
		/// <returns>The settings.</returns>
		public static T Load(String path, String configFileName)
		{
			T obj = (T)LIActivator.GetInstance(typeof(T).Assembly, typeof(T));
			
			string fileName = DetermineFileName(path, configFileName);
			
			if ( ! File.Exists(fileName)) 
			{
				Trace.TraceError("Configuration file "+fileName+ " not found.");
				Trace.TraceError("Load default configuration for " + obj.ToString());
				obj.LoadDefault();
				return obj;
			}
			
			LISerialization<T> serializer = new LISerialization<T>(obj);
			serializer.Deserialize(fileName);
			
			return serializer.Value;
		}
		
		/// <summary>
		/// Save the settings.
		/// </summary>
		/// <param name="value">Settings to save.</param>
		public static void Save(T value)
		{
			Save(value, null, null);
		}	
				
		/// <summary>
		/// Save the settings.
		/// </summary>
		/// <param name="value">Settings to save.</param>
		/// <param name = "path">Directory for the settings file</param>
		public static void Save(T value, String path)
		{
			Save(value, path, null);
		}	
		
		/// <summary>
		/// Save the settings.
		/// </summary>
		/// <param name="value">Settings to save.</param>
		/// <param name = "path">Directory for the settings file</param>
		/// <param name = "configFileName">Name of the config file</param>
		public static void Save(T value, String path, String configFileName)
		{
			LISerialization<T> serializer = new LISerialization<T>(value);
			serializer.Serialize(DetermineFileName(path, configFileName));
		}
		
		#endregion

	}
}
