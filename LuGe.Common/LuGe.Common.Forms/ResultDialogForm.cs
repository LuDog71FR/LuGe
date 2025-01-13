/*
 * User: lgermain
 * Date: 17/10/2008 10:24
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LuGe.Common.Forms
{
	/// <summary>
	/// Dialog form that displayed result or report.
	/// </summary>
	public partial class ResultDialogForm : Form
	{
		
		#region Fields
		
		#endregion

		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public ResultDialogForm()
		{
			InitializeComponent();
		}
		
		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the text of the report.
		/// </summary>
		public string ReportText
		{
			get { return richTextBox1.Text; }
			set { richTextBox1.Text = value; }
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Display an XML validation report after the validation of an xml file.
		/// </summary>
		/// <param name="parentForm">The parent form of the result dialog.</param>
		public static void DisplayXmlValidationReport(Form parentForm)
		{
			ResultDialogForm form = new ResultDialogForm();
			
			foreach(string error in LIXmlHelper.Errors)
			{
				form.ReportText += error;
				form.ReportText += "\r\n\r\n";
			}
			
			form.ReportText += "- - - - - - - - - - - - - - - -";
			form.ReportText += "\r\n\r\n";
			
			if (LIXmlHelper.Errors.Count == 0) form.ReportText += "Validation OK !";
			else form.ReportText += "Validation : " + LIXmlHelper.Errors.Count + " Error(s)";
			
			form.ReportText += "\r\n";
			
			form.ShowDialog(parentForm);
		}
		
		#endregion

	}
}
