/*
 * User: lgermain
 * Date: 07/07/2008 11:18
 */

using System;
using System.Diagnostics;
using System.Reflection;

namespace LuGe.Common
{
	/// <summary>
	/// This class provides a set of properties to easly
	/// read the version number of an assembly.
	/// </summary>
	public class LIVersion
	{
		#region Fields
		
		private Assembly _assembly; // Assembly to manage.
		
		private int _major; // Major version of the assembly.
		private int _minor; // Minor version of the assembly.
		private int _build; // Build version of the assembly.
		private int _revision; // Revision version of the assembly.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="LIVersion">LIVersion</see> class.
		/// </summary>
		public LIVersion(Assembly assembly)
		{
			if (assembly == null) throw new ArgumentNullException("assembly");
			
			_assembly = assembly;
			SplitVersionNumber();
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the assembly.
		/// </summary>
		public Assembly Assembly {
			get { return _assembly; }
		}
		
		/// <summary>
		/// Gets the full version of the assembly.
		/// </summary>
		public string FullVersion {
			get { return FileVersionInfo.GetVersionInfo(Assembly.Location).FileVersion; }
		}
		
		/// <summary>
		/// Gets the Major version of the assembly.
		/// </summary>
		public int Major {
			get { return _major; }
		}
		
		/// <summary>
		/// Gets the Minor version of the assembly.
		/// </summary>
		public int Minor {
			get { return _minor; }
		}
		
		/// <summary>
		/// Gets the Build version of the assembly.
		/// </summary>
		public int Build {
			get { return _build; }
		}
		
		/// <summary>
		/// Gets the Revision version of the assembly.
		/// </summary>
		public int Revision {
			get { return _revision; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Split the version number of the assembly to easly
		/// read each part of the version number.
		/// </summary>
		/// <remarks>
		/// The assembly version has following format : Major.Minor.Build.Revision
		/// </remarks>
		private void SplitVersionNumber()
		{
			Version version = new Version(FullVersion);
			
			_major = version.Major;
			_minor = version.Minor;
			_build = version.Build;
			_revision = version.Revision;
		}
		
		/// <summary>
		/// Returns a string representing the assembly with it major and minor version number.
		/// </summary>
		/// <returns>A string representing the assembly with it major and minor
		/// version number.</returns>
		/// <remarks>
		/// The return string has following format : Major.Minor
		/// </remarks>
		public override string ToString()
		{
			return Major.ToString() + "." + Minor.ToString();
		}
		
		#endregion
	}
}
