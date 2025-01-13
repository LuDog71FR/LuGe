/*
 * User: lgermain
 * Date: 25/11/2008 11:12
 */

using System;

namespace LuGe.Common
{
	/// <summary>
	/// Interface for configuration file.
	/// </summary>
	/// <remarks>To use with the <c>LIConfiguration</c> class.</remarks>
	public interface IConfigurationFile
	{
		/// <summary>
		/// Load default values of the settings.
		/// </summary>
		void LoadDefault();		
	}
}
