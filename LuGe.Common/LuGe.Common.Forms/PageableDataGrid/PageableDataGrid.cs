using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LuGe.Common.Forms
{
	public partial class PageableDataGrid : UserControl
	{
		public event DataGridViewCellEventHandler CellDoubleClicked;
		public event DataGridViewCellEventHandler RowEnter;
		
		private DataPageCache _memoryCache;
		
		public DataGridViewCell CurrentCell
		{
			get { return dataGridView1.CurrentCell; }
			set { dataGridView1.CurrentCell = value; }
		}
		
		public DataGridViewRowCollection Rows
		{
			get { return dataGridView1.Rows; }
		}
		
		public DataGridViewColumnCollection Columns
		{
			get { return dataGridView1.Columns; }
		}
		
		public PageableDataGrid()
		{
			InitializeComponent();
		}
		
		void DataGridView1CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			e.Value = _memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
		}
		
		public void LoadGrid(IDataPageRetriever dataPageRetriever)
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			
			_memoryCache = new DataPageCache(dataPageRetriever);
			
			foreach (string columnName in dataPageRetriever.Columns)
			{
				dataGridView1.Columns.Add(columnName, columnName);
			}
			
			this.dataGridView1.RowCount = dataPageRetriever.RowCount;
		}
		
		void DataGridView1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (CellDoubleClicked != null) CellDoubleClicked(sender, e);
		}
		
		void DataGridView1RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (RowEnter != null) RowEnter(sender, e);	
		}
		
		void DataGridView1RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			DataGridView grid = sender as DataGridView;
			string rowIdx = (e.RowIndex + 1).ToString();

			StringFormat centerFormat = new StringFormat();
			centerFormat.Alignment = StringAlignment.Center;
			centerFormat.LineAlignment = StringAlignment.Center;

			Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
			                                       grid.RowHeadersWidth, e.RowBounds.Height);
			e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
		}
	}
}
