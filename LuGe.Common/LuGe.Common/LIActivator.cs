/*
 * User: Ludovic Germain
 * Date: 13/07/2007
 * Time: 09:20
 */

using System;
using System.IO;
using System.Reflection;

namespace LuGe.Common
{
	/// <summary>
	/// Provides static methods to create instance
	/// of object by reflection.
	/// </summary>
	public sealed class LIActivator
	{
		#region Fields
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Private constructor for the LIReflection class,
		/// because the type only declares static members.
		/// </summary>
		private LIActivator() {}
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Creates an instance of the type whose name is specified,
		/// using the assembly specified.
		/// </summary>
		/// <param name="assembly">
		/// The assembly where the type named className is sought.</param>
		/// <param name="className">The name of the type to instantiate.</param>
		/// <param name="args">An array of arguments that match
		/// the parameters of the constructor to invoke.</param>
		/// <returns>A reference to the newly created object
		/// or null if the method cannot create an instance.</returns>
		public static object GetInstance(Assembly assembly,
		                                 string className,
		                                 object[] args) 
		{
			if (assembly == null) 
			{
				throw new ArgumentNullException("assembly");
			}

			if (string.IsNullOrEmpty(className)) 
			{
				throw new ArgumentNullException("className");
			}

			try 
			{
				object[] Attributes = {};
				return Activator.CreateInstance(assembly.GetType(className),
				                                args, Attributes);
			}

			catch (TypeLoadException) 
			{
				return null;
			}
		}
		
		/// <summary>
		/// Creates an instance of the type whose name is specified,
		/// using the assembly specified.
		/// </summary>
		/// <param name="assembly">
		/// The assembly where the type named className is sought.</param>
		/// <param name="className">The name of the type to instantiate.</param>
		/// <returns>A reference to the newly created object
		/// or null if the method cannot create an instance.</returns>
		public static object GetInstance(Assembly assembly,
		                                 string className) 
		{
			return GetInstance(assembly, className, null);
		}

		/// <summary>
		/// Creates an instance of the type whose name is specified,
		/// using the assembly whose file name is specified.
		/// </summary>
		/// <param name="assemblyFile">The name of the assembly where the
		/// type named typeName is sought.</param>
		/// <param name="className">The name of the type to instantiate.</param>
		/// <returns>A reference to the newly created object
		/// or null if the method cannot create an instance.</returns>
		public static object GetInstance(string assemblyFile,
		                                 string className) 
		{
			return GetInstance(assemblyFile, className, null);
		}

		/// <summary>
		/// Creates an instance of the type whose name is specified,
		/// using the assembly whose file name is specified.
		/// </summary>
		/// <param name="assemblyFile">The name of the assembly where the
		/// type named typeName is sought.</param>
		/// <param name="className">The name of the type to instantiate.</param>
		/// <param name="args">An array of arguments that match
		/// the parameters of the constructor to invoke.</param>
		/// <returns>A reference to the newly created object
		/// or null if the method cannot create an instance.</returns>
		public static object GetInstance(string assemblyFile,
		                                 string className,
		                                 object[] args) 
		{
			if (string.IsNullOrEmpty(assemblyFile)) 
			{
				throw new ArgumentNullException("assemblyFile");
			}

			if (!File.Exists(assemblyFile)) 
			{
				throw new FileNotFoundException(assemblyFile);
			}

			return GetInstance(Assembly.LoadFrom(assemblyFile), className, args);
		}

		/// <summary>
		/// Creates an instance of the type specified,
		/// using the assembly specified.
		/// </summary>
		/// <param name="assembly">
		/// The assembly where the type named className is sought.</param>
		/// <param name="type">The type of object to create.</param>
		/// <returns>A reference to the newly created object
		/// or null if the method cannot create an instance.</returns>
		public static object GetInstance(Assembly assembly,
		                                 Type type) 
		{
			return GetInstance(assembly, type, null);
		}

		/// <summary>
		/// Creates an instance of the type specified,
		/// using the assembly specified.
		/// </summary>
		/// <param name="assembly">
		/// The assembly where the type named className is sought.</param>
		/// <param name="type">The type of object to create.</param>
		/// <param name="args">An array of arguments that match
		/// the parameters of the constructor to invoke.</param>
		/// <returns>A reference to the newly created object
		/// or null if the method cannot create an instance.</returns>
		public static object GetInstance(Assembly assembly,
		                                 Type type,
		                                 object[] args) 
		{
			if (type == null) throw new ArgumentNullException("type");
			return GetInstance(assembly, type.FullName, args);
		}

		/// <summary>
		/// Gets the name of the real type.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>Returns the name of the real type.</returns>
		public static string GetRealTypeName(object value) 
		{
			if (value == null) return string.Empty;
			return Microsoft.VisualBasic.Information.TypeName(value);
		}
		
		/// <summary>
		/// Indicates if the specified object is a class of the type specified.
		/// </summary>
		/// <param name="value">Object to check.</param>
		/// <param name="baseType">Base type expected.</param>
		/// <returns>True if the specified object is a class of the type specified.</returns>
		public static bool IsBaseClassOf(object value, Type baseType) 
		{
			if (value == null) throw new ArgumentNullException("value");
			if (baseType == null) throw new ArgumentNullException("baseType");
			
			Type type = value.GetType();
			
			if (type.IsClass == false) return false;
			
			Type subType = type.BaseType;
			while(subType != null)
			{
				if (subType == baseType) return true;
				
				subType = subType.BaseType;
			}
			
			return false;
		}
		
		/// <summary>
		/// Indicates if the specified object implements the interface specified.
		/// </summary>
		/// <param name="value">Object to check.</param>
		/// <param name="interfaceName">Interface expected.</param>
		/// <returns>True if the specified object implements the interface specified.</returns>
		public static bool IsImplementing(object value, string interfaceName)
		{
			if (value == null) throw new ArgumentNullException("value");
			if (string.IsNullOrEmpty(interfaceName)) throw new ArgumentNullException("interfaceName");
			
			Type type = value.GetType();
			Type[] result = type.FindInterfaces(Module.FilterTypeName, interfaceName);
			
			return (result.Length > 0);
		}

		#endregion
	}
}
