/*
 * User: lgermain
 * Date: 27/06/2008 09:47
 */

using System;
using System.IO;
using System.Data;

namespace LuGe.Common.Data.SqlObject
{
	/// <summary>
	/// This class provid mechanisms for import and export data
	/// in a table from/to a csv file.
	/// </summary>
	public class LIImportExportData
	{
		#region Fields
		
		private DataTable _table;
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		/// <param name="table">The source table.</param>
		public LIImportExportData(DataTable table)
		{
			if (table == null) throw new ArgumentNullException("table");

			_table = table;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the source table.
		/// </summary>
		public DataTable Table {
			get { return _table; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Export all data from the data table to the file specified.
		/// </summary>
		/// <remarks>
		/// If the destination file exists then it will be erased.
		/// </remarks>
		/// <param name="fileName">Destination file name.</param>
		public void Export(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))	throw new ArgumentNullException("fileName");
			if (File.Exists(fileName)) File.Delete(fileName);

			using (StreamWriter sw = new StreamWriter(fileName))
			{
				foreach (DataRow line in Table.Rows)
				{
					ExportLine(sw, line);
				}
			}
		}

		/// <summary>
		/// Export the data row specified to the destination stream.
		/// </summary>
		/// <param name="sw">Destination stream.</param>
		/// <param name="line">Data row to export.</param>
		private static void ExportLine(StreamWriter sw, DataRow line)
		{
			bool valueExists = false;

			foreach (object value in line.ItemArray)
			{
				if (valueExists) sw.Write(";");

				sw.Write(value.ToString());
				valueExists = true;
			}

			sw.WriteLine();
		}

		/// <summary>
		/// Import all data from the source file to the data table.
		/// </summary>
		/// <remarks>
		/// Warning !
		/// The data are exported as such, 
		/// no verification on the constraints is made.
		/// </remarks>
		/// <param name="fileName">Source file name.</param>
		public void Import(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))	throw new ArgumentNullException("fileName");
			if (!File.Exists(fileName)) throw new FileNotFoundException(fileName);

			using (StreamReader sw = new StreamReader(fileName))
			{
				string data;

				do 
				{
					data = sw.ReadLine();
					ImportLine(data);
				}
				while (!(data == null));
			}
		}

		/// <summary>
		/// Import into the data table the data row specified.
		/// </summary>
		/// <param name="data">Data to import.</param>
		private void ImportLine(string data)
		{
			if (data == null) return;

			object[] values = data.Split(new char[] {';'});
			Table.Rows.Add(values);
		}

		#endregion
	}
}
