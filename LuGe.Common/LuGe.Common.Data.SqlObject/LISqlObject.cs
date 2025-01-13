/*
 * User: Ludovic Germain
 * Date: 24/07/2007
 * Time: 14:22
 */

using System;
using System.ComponentModel;
using LuGe.Common;
using LuGe.Common.Collection;

namespace LuGe.Common.Data.SqlObject
{
	/// <summary>
	/// Base class to manage data object.
	/// </summary>
	public abstract class LISqlObject : LIObject, INotifyPropertyChanged
	{
        #region Events

        /// <summary>
        /// Implements the property change event of the INotifyPropertyChanged 
        /// interface.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

		#region Fields
		
		private SqlGenerator _generator;
		private LIConnection _connection;
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the 
		/// <see cref="LISqlObject">LISqlObject</see> class.
		/// </summary>
		/// <param name="connection">Connection to used to connect to the database.</param>
		protected LISqlObject(LIConnection connection) : base() 
		{
			if (connection == null) throw new ArgumentNullException("connection");
			
			this._connection = connection;
			this._generator = new SqlGenerator(this, connection);
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the connection used to access the database.
		/// </summary>
		/// <value>The connection used to access the database.</value>
        protected LIConnection Connection
        {
            get { return this._connection; }
        }
        
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Returns all rows filtered with the filter expression specified.
		/// </summary>
		/// <param name="filter">
		/// <para>Expression used to filter 
		/// which rows are listed.</para><para>
		/// This expression must be write
		/// like the where clause of a sql instruction
		/// without the where word.</para>
		/// </param>
		/// <remarks>
		/// Passing string.Empty for the filter expression is
		/// equivalent to call <see cref="List()">List()</see> function.
		/// </remarks>
		/// <returns>All rows filtered with the 
		/// filter expression specified.</returns>
		public object[] List(string filter) 
		{
			return this._generator.List(filter);
		}
		
		/// <summary>
		/// Returns all rows.
		/// </summary>
		/// <returns>All rows.</returns>
		public object[] List() 
		{
			return List(String.Empty);
		}
		
		/// <summary>
		/// Returns a value indicates if a row exists with the
		/// primary key specified,in the current fields.
		/// </summary>
		/// <returns>A value indicates if a row exists with the
		/// primary key specified in the current fields.</returns>
		public virtual bool Exist() 
		{
			return this._generator.Exist();
		}

		/// <summary>
		/// Load the row with the primary key specified in the current fields.
		/// </summary>
		/// <returns>A value indicates if the row is load correctly.</returns>
		public virtual bool Load() 
		{
			return this._generator.Load();
		}

		/// <summary>
		/// Save the current row.
		/// </summary>
		/// <returns>A value indicates if the row is save correctly.</returns>
		public virtual bool Save() 
		{
			return this._generator.Save();
		}

		/// <summary>
		/// Delete the current row.
		/// </summary>
		/// <returns>A value indicates if the row is delete correctly.</returns>
		public virtual bool Delete() 
		{
			return this._generator.Delete();
		}
		
		/// <summary>
		/// Raise the <see cref="PropertyChanged" /> event.
		/// </summary>
		/// <param name="info">The property name.</param>
        protected void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
        
		#endregion
	}
}
