/*
 * User: lgermain
 * Date: 26/06/2008 08:51
 */

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LuGe.Common.Data;

namespace LuGe.DatabaseQuery
{
	/// <summary>
	/// Form for executing a query.
	/// </summary>
	public partial class ExecQueryForm : Form
	{
		#region Fields

		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public ExecQueryForm()
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
		/// Read the parameter from the query entered by the user.
		/// </summary>
		/// <returns>The collection of parameters with
		/// values.</returns>
		private LIParameterCollection ReadParameters()
		{
			if (string.IsNullOrEmpty(TextBoxSqlQuery.Text)) return null;
			
			LIParameterCollection parameters = 
				LIParameterCollection.ExtractParameters(TextBoxSqlQuery.Text);
			
			foreach (LIParameter param in parameters)
			{
				ParameterForm form = new ParameterForm();
				form.LoadParameter(param.Name);
				DialogResult result = form.ShowDialog(this);
				
				if (result != DialogResult.OK) return null;
				
				param.Value = form.Value;
			}
			
			return parameters;
		}
		
        /// <summary>
        /// Raised when the execute button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> 
        /// instance containing the event data.</param>
		private void ButtonExecuteClick(object sender, EventArgs e)
		{
			LabelLinesNumber.Text = string.Empty;
			dataGridViewResult.DataSource = null;
			
			if (string.IsNullOrEmpty(TextBoxSqlQuery.Text)) return;
			
			LIParameterCollection parameters = ReadParameters();
			if (parameters == null) return;
			
			this.Cursor = Cursors.WaitCursor;
			
			DataTable table;
			
			try
			{
				table = ParentForm.Connection.Command.ExecuteDataTable(
					TextBoxSqlQuery.Text, 
					parameters);
			}
			catch (Exception ex)
			{
				this.Cursor = Cursors.Default;
				MessageBox.Show(this, ex.ToString(), "Query error");
				ParentForm.Message = "Query error !";
				return;
			}
			
			dataGridViewResult.DataSource = table;
			LabelLinesNumber.Text = table.Rows.Count.ToString();
			
			ParentForm.RefreshTables();
			ParentForm.Message = "Query execute (" + LabelLinesNumber.Text + ")";
			
			this.Cursor = Cursors.Default;
		}
		
        /// <summary>
        /// Raised when the load button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> 
        /// instance containing the event data.</param>
		private void ButtonLoadClick(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "SQL Files(*.sql)|*.sql|All files|*.*";
			DialogResult result = openFileDialog1.ShowDialog();
			
			if (result != DialogResult.OK) return;
			
			TextBoxSqlQuery.LoadFile(openFileDialog1.FileName,
			                         RichTextBoxStreamType.PlainText);
		}
		
        /// <summary>
        /// Raised when the save button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> 
        /// instance containing the event data.</param>
		private void ButtonSaveClick(object sender, EventArgs e)
		{
			saveFileDialog1.Filter = "SQL Files(*.sql)|*.sql|All files|*.*";
			DialogResult result = saveFileDialog1.ShowDialog();
			
			if (result != DialogResult.OK) return;
			
			TextBoxSqlQuery.SaveFile(saveFileDialog1.FileName,
			                         RichTextBoxStreamType.PlainText);
		}
		
		void ExecQueryFormFormClosed(object sender, FormClosedEventArgs e)
		{
			if (dataGridViewResult.DataSource != null) 
			{
				(dataGridViewResult.DataSource as DataTable).Dispose();
			}
		}
		
		#endregion
	}
}
