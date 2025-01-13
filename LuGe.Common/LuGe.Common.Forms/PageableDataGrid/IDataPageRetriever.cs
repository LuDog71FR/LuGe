using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace LuGe.Common.Forms
{
	public interface IDataPageRetriever
	{
		int RowCount { get; }		
		List<string> Columns { get; }
		
		DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
	}
}
