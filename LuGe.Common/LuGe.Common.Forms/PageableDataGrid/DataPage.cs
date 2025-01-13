using System;
using System.Data;

namespace LuGe.Common.Forms
{
	public class DataPage
	{
		public const int RowsPerPage = 50;
		
		private DataTable _table;
		private int _lowestIndex;
		private int _highestIndex;
		
		public DataTable table { get { return _table; } }
		public int LowestIndex { get { return _lowestIndex; } }
		public int HighestIndex { get { return _highestIndex; } }
		
		public static int MapToLowerBoundary(int rowIndex)
		{
			return (rowIndex / RowsPerPage) * RowsPerPage;
		}
		
		private static int MapToUpperBoundary(int rowIndex)
		{
			return MapToLowerBoundary(rowIndex) + RowsPerPage - 1;
		}
		
		public DataPage(DataTable table, int rowIndex)
		{
			_table = table;
			_lowestIndex = MapToLowerBoundary(rowIndex);
			_highestIndex = MapToUpperBoundary(rowIndex);
		}
	}
}
