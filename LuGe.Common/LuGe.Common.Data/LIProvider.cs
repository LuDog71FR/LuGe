/*
 * User: lgermain
 * Date: 03/07/2008 10:08
 */

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace LuGe.Common.Data
{
	/// <summary>
	/// <para>
	/// This class provides methods and properties that
	/// manage database providers.
	/// </para><para>
	/// This class cannot be inherited.
	/// </para>
	/// </summary>
	public sealed class LIProvider
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Private constructor for the LIProvider class,
		/// because the type only declares static members.
		/// </summary>
		private LIProvider()
		{
		}
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// List all providers installed on the system.
		/// </summary>
		/// <returns>
		/// An IEnumerable of string. One element represents
		/// the invariant name of a provider.
		/// </returns>
		public static IEnumerable<string> List()
		{
			DataTable table = DbProviderFactories.GetFactoryClasses();
			
			foreach (DataRow row in table.Rows)
			{
				yield return row["InvariantName"].ToString();
			}
		}
		
		/// <summary>
		/// Returns a value indicating if the specified provider is
		/// installed on the system.
		/// </summary>
		/// <param name="invariantName">Invariant name of the provider.</param>
		/// <returns>
		/// True if the provider is installed on the system; 
		/// otherwise False.
		/// </returns>
		public static bool Exists(string invariantName)
		{
			DataTable table = DbProviderFactories.GetFactoryClasses();
			
			if (table.Select("InvariantName='" + invariantName + "'").Length == 0)
			{
				return false;
			}
			
			return true;
		}
		
		#endregion
	}
}
