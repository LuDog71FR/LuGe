/*
 * User: Ludovic Germain
 * Date: 19/07/2007
 * Time: 14:03
 */

using System;
using System.Reflection;
using System.Security.Permissions;
using System.Globalization;

namespace LuGe.Common
{
	/// <summary>
	/// This class makes it possible to gain access
	/// to non-public members of a class.
	/// </summary>
	/// <remarks>
	/// Use this class only for unit testing purpose !
	/// </remarks>
	public class LIObjectAccessor
	{
		#region Constants
		
		private const BindingFlags BINDING_FLAGS =
			BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.NonPublic | BindingFlags.Static;

		#endregion
		
		#region Fields
		
		private Type _type;
		private object _instance;
		private ReflectionPermission _perm;

		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="LIObjectAccessor">LIObjectTester</see> class.
		/// </summary>
		/// <param name="type">The type to managed.</param>
		/// <param name="args">An optional array of parameters to pass to
		/// the constructor.
		/// </param>
		/// <example>
		/// <code>
		/// LIObjectAccessor accessor = new LIObjectAccessor(
		/// 	typeof(MockLIObject),
		/// 	"c", 678);
		/// </code>
		/// </example>
		public LIObjectAccessor(Type type,
		                        params object[] args) {
			if (type == null) throw new ArgumentNullException("type");
			if (args == null) throw new ArgumentNullException("args");
			
			_perm = new ReflectionPermission(PermissionState.Unrestricted);
			_perm.Demand();
			
			_type = type;
			Type[] types = new Type[args.Length];

			for (int i=0; i < args.Length; i++) {
				types[i] = args[i].GetType();
			}

			ConstructorInfo constructor =
				_type.GetConstructor(BINDING_FLAGS, null, types, null);
			
			_instance =constructor.Invoke(args);			
		}
		
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="LIObjectAccessor">LIObjectTester</see> class.
		/// </summary>
		/// <param name="qualifiedTypeName">The qualified name of the type.
		/// </param>
		/// <param name="args">An optional array of parameters to pass to
		/// the constructor.
		/// </param>
		/// <example>
		/// <code>
		/// LIObjectAccessor accessor = new LIObjectAccessor(
		/// 	"LuGe.Common.Tests.MockLIObject, LuGe.Common.Tests",
		/// 	"c", 678);
		/// </code>
		/// </example>
		public LIObjectAccessor(string qualifiedTypeName,
		                        params object[] args) : this(Type.GetType(qualifiedTypeName), args) {
			if (String.IsNullOrEmpty(qualifiedTypeName)) throw new ArgumentNullException("qualifiedTypeName");
		}

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="LIObjectAccessor">LIObjectTester</see> class.
		/// </summary>
		/// <param name="instance">The instance of the managed object.</param>
		public LIObjectAccessor(object instance) {
			_perm = new ReflectionPermission(PermissionState.Unrestricted);
			_perm.Demand();
			
			_type = Type.GetTypeFromHandle(Type.GetTypeHandle(instance));
			
			this._instance = instance;
		}

		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the instance of the managed object.
		/// </summary>
		public object Instance {
			get { return _instance; }
		}
		
		/// <summary>
		/// Gets the instance type of the managed object.
		/// </summary>
		public Type InstanceType {
			get { return _type; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Gets the value of a non-public field of the
		/// managed type.
		/// </summary>
		/// <param name="name">The name of the non-public field to
		/// interrogate</param>
		/// <returns>A value whose type is specific to the field.</returns>
		public object GetField(string name) {
			FieldInfo fi = _type.GetField(name, BINDING_FLAGS);
			return fi.GetValue(_instance);
		}

		/// <summary>
		/// Gets the value of a non-public property of the managed type.
		/// </summary>
		/// <param name="name">The name of the non-public property to
		/// interrogate.</param>
		/// <returns>A value whose type is specific to the property.</returns>
		public object GetProperty(string name) {
			PropertyInfo pi = _type.GetProperty(name, BINDING_FLAGS);
			return pi.GetValue(_instance, null);
		}

		/// <summary>
		/// Invokes the non-public static method of the managed type.
		/// </summary>
		/// <param name="type">The type where the method is.</param>
		/// <param name="name">The name of the non-public
		/// method to invoke.</param>
		/// <param name="args">An array of typed parameters to pass
		/// to the method.
		/// </param>
		/// <returns>A value who type is specific to the invoked method.</returns>
		/// <remarks>
		/// If the method, you want to invoke, have parameter ref or out, you must use
		/// </remarks>
		public static object Invoke(Type type, string name, params object[] args)
		{
			if (type == null) throw new ArgumentNullException("type");
			if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
			if (args == null) throw new ArgumentNullException("args");
			
			return type.InvokeMember(name, 
			                         BindingFlags.InvokeMethod 
			                         | BindingFlags.NonPublic
			                         | BindingFlags.Static,
			                         null, null, 
			                         args,
			                         CultureInfo.InvariantCulture);
			
		}

		/// <summary>
		/// Invokes the non-public method of the managed type.
		/// </summary>
		/// <param name="name">The name of the non-public
		/// method to invoke.</param>
		/// <param name="args">An array of typed parameters to pass
		/// to the method.
		/// </param>
		/// <returns>A value who type is specific to the invoked method.</returns>
		/// <remarks>
		/// If the method, you want to invoke, have parameter ref or out, you must use
		/// </remarks>
		public object Invoke(string name, params object[] args)
		{
			if (args == null) throw new ArgumentNullException("args");

			Type[] types = new Type[args.Length];

			for (int i = 0; i < args.Length; i++)
			{
				types[i] = args[i].GetType();
			}

			return _type.GetMethod(name, BINDING_FLAGS, null, types, null)
				.Invoke(_instance, args);
		}

		/// <summary>
		/// Invokes the non-public method of the managed type.
		/// </summary>
		/// <param name="name">The name of the non-public
		/// method to invoke.</param>
		/// <param name="typeNames">An array that indicated the type of each argument
		/// passed to the method.
		/// </param>
		/// <param name="args">An array of typed parameters to pass
		/// to the method.
		/// </param>
		/// <returns>A value who type is specific to the invoked method.</returns>
		/// 
		/// <example>
		/// Below the method to invoke :
		/// <code>
		/// private bool GetAdressByRef(ref string adress)
		/// {
		/// 	adress = "New adress";
		/// 	return true;
		/// }
		/// </code>
		/// 
		/// Below the code that invoke this method by reflection :
		/// <code>
        ///	string[] types = new String[] { "System.String&amp;" };
        /// Object[] args = new Object[] { "My adress" };
		/// 
		/// bool returnObject =(bool)this._accessor.Invoke(
		/// 	"GetAdress",
		///     types,
		///     ref args);
		/// 
		/// Assert.IsTrue(returnObject);
		/// Assert.AreEqual("New adress", (string)args[0]);
		/// </code>
		/// </example>
		public object Invoke(string name,
		                     string[] typeNames,
		                     ref object[] args)
		{
			if (typeNames == null) throw new ArgumentNullException("typeNames");
			if (args == null) throw new ArgumentNullException("args");
			if (args.Length != typeNames.Length) throw new ArgumentException("types length and args length are different !");

			Type[] types = new Type[typeNames.Length];

			for (int i = 0; i < typeNames.Length; i++)
			{
				types[i] = Type.GetType(typeNames[i]);
				if (types[i] == null) throw new InvalidOperationException(
					"Unknown type (" + i.ToString(CultureInfo.CurrentCulture) + ") : " + typeNames[i]);
			}
			
			MethodInfo method = _type.GetMethod(name, BINDING_FLAGS, null, types, null);
			return method.Invoke(_instance, args);
		}

		/// <summary>
		/// Sets the value of a non-public field of the managed type.
		/// </summary>
		/// <param name="name">The name of the non-public field to modify.</param>
		/// <param name="fieldValue">A value whose type is
		/// specific to the field.</param>
		public void SetField(string name, object fieldValue) {
			_type.GetField(name,BINDING_FLAGS)
				.SetValue(_instance, fieldValue);
		}

		/// <summary>
		/// Sets the value of a non-public property of the managed type.
		/// </summary>
		/// <param name="name">The name of the non-public property to modify.</param>
		/// <param name="propertyValue">A value whose type is
		/// specific to the property.</param>
		public void SetProperty(string name, object propertyValue) {
			_type.GetProperty(name,BINDING_FLAGS)
				.SetValue(_instance, propertyValue, null);
		}

		#endregion
	}
}
