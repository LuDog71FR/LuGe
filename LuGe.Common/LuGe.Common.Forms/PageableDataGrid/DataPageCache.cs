using System;
using System.Data;

namespace LuGe.Common.Forms
{
	public class DataPageCache
	{
		private DataPage[] cachePages;
		private IDataPageRetriever dataSupply;
		
		public DataPageCache(IDataPageRetriever dataSupplier)
		{
			dataSupply = dataSupplier;
			
			LoadFirstTwoPages();
		}
		
		private bool IfPageCached_ThenSetElement(int rowIndex, int columnIndex, ref object element)
		{
			if (IsRowCachedInPage(0, rowIndex))
			{
				element = cachePages[0].table.Rows[rowIndex % DataPage.RowsPerPage][columnIndex];
				return true;
			}
			else if (IsRowCachedInPage(1, rowIndex))
			{
				element = cachePages[1].table.Rows[rowIndex % DataPage.RowsPerPage][columnIndex];
				return true;
			}
			
			return false;
		}

		public object RetrieveElement(int rowIndex, int columnIndex)
		{
			object element = null;
			
			if (IfPageCached_ThenSetElement(rowIndex, columnIndex, ref element)) return element;
			else return RetrieveData_CacheIt_ThenReturnElement(rowIndex, columnIndex);
		}
		
		private void LoadFirstTwoPages()
		{
			cachePages = new DataPage[]
			{
				new DataPage(dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(0), DataPage.RowsPerPage), 0),
				new DataPage(dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(DataPage.RowsPerPage), DataPage.RowsPerPage), DataPage.RowsPerPage)
			};
		}

		private object RetrieveData_CacheIt_ThenReturnElement(int rowIndex, int columnIndex)
		{
			// Retrieve a page worth of data containing the requested value.
			DataTable table = dataSupply.SupplyPageOfData(
				DataPage.MapToLowerBoundary(rowIndex), DataPage.RowsPerPage);
			
			// Replace the cached page furthest from the requested cell
			// with a new page containing the newly retrieved data.
			cachePages[GetIndexToUnusedPage(rowIndex)] = new DataPage(table, rowIndex);
			
			return RetrieveElement(rowIndex, columnIndex);
		}
		
		// Returns the index of the cached page most distant from the given index
		// and therefore least likely to be reused.
		private int GetIndexToUnusedPage(int rowIndex)
		{
			if (rowIndex > cachePages[0].HighestIndex &&
			    rowIndex > cachePages[1].HighestIndex)
			{
				int offsetFromPage0 = rowIndex - cachePages[0].HighestIndex;
				int offsetFromPage1 = rowIndex - cachePages[1].HighestIndex;
				if (offsetFromPage0 < offsetFromPage1)
				{
					return 1;
				}
				return 0;
			}
			else
			{
				int offsetFromPage0 = cachePages[0].LowestIndex - rowIndex;
				int offsetFromPage1 = cachePages[1].LowestIndex - rowIndex;
				if (offsetFromPage0 < offsetFromPage1)
				{
					return 1;
				}
				return 0;
			}

		}

		// Returns a value indicating whether the given row index is contained
		// in the given DataPage.
		private bool IsRowCachedInPage(int pageNumber, int rowIndex)
		{
			return rowIndex <= cachePages[pageNumber].HighestIndex 
				&& rowIndex >= cachePages[pageNumber].LowestIndex;
		}
	}
}
