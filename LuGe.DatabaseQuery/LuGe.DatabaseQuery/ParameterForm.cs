/*
 * User: lgermain
 * Date: 26/06/2008 10:13
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LuGe.DatabaseQuery
{
	/// <summary>
	/// Form for asking user to enter value
	/// for the given parameter.
	/// </summary>
	public partial class ParameterForm : Form
	{
		#region Fields

		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public ParameterForm()
		{
			InitializeComponent();
		}
		
		#endregion

		#region Properties
		
		/// <summary>
		/// Gets the parameter name.
		/// </summary>
		public string ParameterName
		{
			get { return TextBoxName.Text; }
		}

		/// <summary>
		/// Gets the parameter value entered by the user.
		/// </summary>
		public object Value
		{
			get
			{
				switch (ComboBoxType.Text)
				{
					case "String":
						return TextBoxValue.Text;
						
					case "Double":
						return Convert.ToDouble(TextBoxValue.Text);

					case "Integer":
						return Convert.ToInt32(TextBoxValue.Text);

					default:
						return TextBoxValue.Text;
				}
			}
		}

		#endregion

		#region Methods
		
		/// <summary>
		/// Load the parameter.
		/// </summary>
		/// <param name="parameterName">Parameter name.</param>
		public void LoadParameter(string parameterName)
		{
			if (string.IsNullOrEmpty(parameterName)) throw new ArgumentNullException("parameterName");

			TextBoxName.Text = parameterName;
		}
		
        /// <summary>
        /// Raised when the ok button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> 
        /// instance containing the event data.</param>
		private void ButtonOkClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		#endregion
	}
}
