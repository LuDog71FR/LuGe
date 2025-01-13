/*
 * User: Ludovic Germain
 * Date: 11/07/2007
 * Time: 10:54
 */

using System;
using System.Resources;
using System.ComponentModel;

namespace LuGe.Common
{
	/// <summary>
	/// <para>Base class for representing business object.</para>
	/// </summary>
	public abstract class LIObject
	{
		#region Fields
		
		private ResourceManager _resources;
		private string _errorMsg;
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="LIObject">LIObject</see> class.
		/// </summary>
		protected LIObject() : base() {
			this._resources = new ComponentResourceManager(this.GetType());
			this._errorMsg = string.Empty;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the ressources associated with the Object.
		/// </summary>
		/// <remarks>
		/// The ressource file must be named with the class name and
		/// the extension must be "resx".
		/// <example>
		/// Example for the class named LIObject,
		/// the ressource file name must be :
		/// <code>LIObject.resx</code>
		/// </example>
		/// </remarks>
		protected ResourceManager Resources {
			get { return _resources; }
		}
		
		/// <summary>
		/// Gets the last error message for the Object.
		/// </summary>
		public string ErrorMsg {
			get { return _errorMsg; }
		}
		
		/// <summary>
		/// Gets a value indicating whether the object have an error.
		/// </summary>
		public bool IsError {
			get { return !(String.IsNullOrEmpty(_errorMsg)); }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Set error message for the Object.
		/// </summary>
		/// <param name="text">
		/// <para>A String that indicating the error message.</para>
		/// <para>Passing an empty string or a null value is equal to
		/// <c>MyObj.ClearError();</c>.</para>
		/// </param>
		protected void SetError(string text) {
			this._errorMsg = text;
		}
		
		/// <summary>
		/// Clear error message for the Object.
		/// </summary>
		/// <remarks>
		/// Call to this method is equal to <c>MyObj.SetError(String.Empty);</c>.
		/// </remarks>
		protected void ClearError() {
			this._errorMsg = string.Empty;
		}
		
		#endregion
	}
}
