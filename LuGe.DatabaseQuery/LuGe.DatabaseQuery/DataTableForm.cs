/*
 * User: lgermain
 * Date: 26/06/2008 10:48
 */

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Data.Common;
using System.Windows.Forms;
using LuGe.Common.Data.SqlObject;

namespace LuGe.DatabaseQuery
{
	/// <summary>
	/// Description of DataTableForm.
	/// </summary>
	public partial class DataTableForm : Form
	{
		#region Fields

		private string _tableName; // Name of the table.
		private DataTable _table; // Data table.
		private DbDataAdapter _adapter; // Data adapter to fill the table.
		private DbCommandBuilder _commandBuilder; // Command builder.
		private DataTable _tableSchema; // Table representing the schema.

		#endregion

		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public DataTableForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the parent form.
		/// </summary>
		private new MainForm ParentForm
		{
			get { return (MainForm)base.ParentForm; }
		}
		
		#endregion

		#region Methods

		/// <summary>
		/// Load and manage the table specified into the form.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		public bool LoadTable(string tableName)
		{
			if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException("tableName");
			
			_tableName = tableName;
			this.Text += " - " + _tableName;
			
			return Populate();
		}
		
		/// <summary>
		/// Refresh the status bar.
		/// </summary>
		private void RefreshStatus()
		{
			this.toolStripStatusLabel3.Text =
				Convert.ToString(this.DataGridViewData.Rows.Count - 1);
		}
		
		/// <summary>
		/// Populate the list of fields into the filter.
		/// </summary>
		private void PopulateFilter()
		{
			ToolStripComboBoxFilterFieldName.Text = string.Empty;
			ToolStripComboBoxFilterSign.Text = string.Empty;
			ToolStripTextBoxFilterValue.Text = string.Empty;

			ToolStripComboBoxFilterFieldName.Items.Clear();

			foreach (DataRow line in _tableSchema.Rows) {
				ToolStripComboBoxFilterFieldName.Items.Add(line["ColumnName"]);
			}
		}
		
		/// <summary>
		/// Populate the grid with all rows of the table.
		/// </summary>
		private bool Populate()
		{
			this.Cursor = Cursors.WaitCursor;

			string sqlSelect = "SELECT * FROM " + _tableName;
			
			_table = new DataTable(_tableName);
			_adapter = ParentForm.Connection.CreateDataAdapter();
			_adapter.SelectCommand = ParentForm.Connection.CreateCommand(sqlSelect);
			
			_commandBuilder = ParentForm.Connection.CreateCommandBuilder();
			_commandBuilder.DataAdapter = _adapter;
			_commandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
			
			try
			{
				_adapter.Fill(_table);
				_adapter.FillSchema(_table, SchemaType.Source);
			}
			catch (Exception ex)
			{
				DataTableFormFormClosed(this, null);
				MessageBox.Show("Unable to load the table : " + ex.Message, "Load table error");
				
				return false;
			}
			
			_tableSchema = _table.CreateDataReader().GetSchemaTable();
			_tableSchema.PrimaryKey = new DataColumn[] {_tableSchema.Columns[0]};

			this.DataGridViewData.DataSource = _table;
			this.DataGridViewSchema.DataSource = _tableSchema;

			this.PopulateFilter();
			this.RefreshStatus();

			this.Cursor = Cursors.Default;
			
			return true;
		}
		
		/// <summary>
		/// Raised when the form is closed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void DataTableFormFormClosed(object sender, FormClosedEventArgs e)
		{
			if (_table != null) _table.Dispose();
			if (_adapter != null) _adapter.Dispose();
			if (_commandBuilder != null) _commandBuilder.Dispose();
		}
		
		/// <summary>
		/// Raised when the user add a row to the data grid.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void DataGridViewDataUserAddedRow(object sender, DataGridViewRowEventArgs e)
		{
			RefreshStatus();
		}
		
		/// <summary>
		/// Raised when the user delete a row from the data grid.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void DataGridViewDataUserDeletedRow(object sender, DataGridViewRowEventArgs e)
		{
			RefreshStatus();
		}
		
		/// <summary>
		/// Raised when the save button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void ToolStripButtonSaveClick(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			_adapter.Update(_table);
			ParentForm.Message = "Saving data table done !";
			
			this.Cursor = Cursors.Default;
		}
		
		/// <summary>
		/// Raised when the load button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void ToolStripButtonLoadClick(object sender, EventArgs e)
		{
			Populate();
			ParentForm.Message = "Loading data table done !";
		}
		
		/// <summary>
		/// Raised when the filter button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void ToolStripButtonFilterClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(ToolStripComboBoxFilterFieldName.Text))
			{
				MessageBox.Show("You must select the field to filter !",
				                "Filter error");
				ToolStripComboBoxFilterFieldName.Focus();
				return;
			}

			if (string.IsNullOrEmpty(ToolStripComboBoxFilterSign.Text))
			{
				MessageBox.Show("You must select the sign to filter !",
				                "Filter error");
				ToolStripComboBoxFilterSign.Focus();
				return;
			}

			AdaptValue();

			StringBuilder filter = new StringBuilder();

			filter.Append(ToolStripComboBoxFilterFieldName.Text);
			filter.Append(" ");
			filter.Append(ToolStripComboBoxFilterSign.Text);
			filter.Append(" ");
			filter.Append(ToolStripTextBoxFilterValue.Text);

			try
			{
				_table.DefaultView.RowFilter = filter.ToString();
			}
			catch (System.Data.SyntaxErrorException)
			{
				MessageBox.Show("The filter value specified is invalid !",
				                "Filter error");
				return;
			}
			
			RefreshStatus();
			ParentForm.Message = "Filtering data table done !";
		}
		
		/// <summary>
		/// Adapt the value according to the type of the field.
		/// </summary>
		private void AdaptValue()
		{
			DataRow line = _tableSchema.Rows.Find(
				ToolStripComboBoxFilterFieldName.Text);

			switch (line["DataType"].ToString())
			{
				case "System.String":
					if ((string.IsNullOrEmpty(ToolStripTextBoxFilterValue.Text) == false)
					    && (ToolStripTextBoxFilterValue.Text[0] != '\''))
					{
						StringBuilder newValue = new StringBuilder();
						newValue.Append("'");
						newValue.Append(ToolStripTextBoxFilterValue.Text);
						newValue.Append("'");

						ToolStripTextBoxFilterValue.Text = newValue.ToString();
					}

					break;

				case "System.Single":
				case "System.Double":
					ToolStripTextBoxFilterValue.Text = ToolStripTextBoxFilterValue.Text.Replace(",", ".");
					break;
			}
		}
		
		/// <summary>
		/// Raised when the import button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void ToolStripButtonImportClick(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "CSV File(*.csv)|*.csv|All files|*.*";
			openFileDialog1.FileName = _tableName;

			DialogResult result = openFileDialog1.ShowDialog();
			if (result != DialogResult.OK) return;

			this.Cursor = Cursors.WaitCursor;
			
			LIImportExportData importExport = new LIImportExportData(_table);
			importExport.Import(openFileDialog1.FileName);
			
			RefreshStatus();
			ParentForm.Message = "Importing to data table done !";
			this.Cursor = Cursors.Default;
		}
		
		/// <summary>
		/// Raised when the export button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void ToolStripButtonExportClick(object sender, EventArgs e)
		{
			saveFileDialog1.Filter = "CSV File(*.csv)|*.csv|All files|*.*";
			saveFileDialog1.FileName = _tableName;

			DialogResult result = saveFileDialog1.ShowDialog();
			if (result != DialogResult.OK) return;

			this.Cursor = Cursors.WaitCursor;
			
			LIImportExportData importExport = new LIImportExportData(_table);
			importExport.Export(saveFileDialog1.FileName);
			
			RefreshStatus();
			ParentForm.Message = "Exporting from data table done !";
			this.Cursor = Cursors.Default;
		}
		
		#endregion
	}
}
