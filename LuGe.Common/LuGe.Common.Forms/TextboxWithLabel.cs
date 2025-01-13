/*
 * User: lgermain
 * Date: 08/08/2008 09:51
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LuGe.Common.Forms
{
	/// <summary>
	/// Textbox with a label.
	/// </summary>
	[ToolboxBitmap(typeof(TextboxWithLabel), "Resources.TextboxWithLabel.bmp")]
	public partial class TextboxWithLabel : UserControl
	{
		
		#region Events
		
		/// <summary>
		/// Event raised when the text changed.
		/// </summary>
		[Category("Property Changed"), 
		 Browsable(true), 
		 Description("Event raised when the text changed.")]
		public event EventHandler<EventArgs> EditTextChanged;
		
		#endregion
		
		#region Fields

		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public TextboxWithLabel()
		{
			InitializeComponent();
		}
		
		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the maximum number of characters that can be entered
		/// in the edit control.
		/// </summary>
		[Category("Appearance"), 
		 Browsable(true), 
		 Description("The maximum number of characters that can be entered in the edit control.")]
		public int MaxLength
		{
			get { return textBox1.MaxLength; }
			set { textBox1.MaxLength = value; }
		}

		/// <summary>
		/// Gets or sets the label for the end-user.
		/// </summary>
		[Category("Appearance"), 
		 Browsable(true), 
		 Description("The label for the end-user.")]
		public String LabelText
		{
			get { return label1.Text; }
			set { label1.Text = value; }
		}

		/// <summary>
		/// Gets or sets the text to edit.
		/// </summary>
		/// <remarks>Same as the <see cref="EditText">EditText</see> property.</remarks>
		[Category("Appearance"), 
		 Browsable(true), 
		 Description("The text to edit.")]
		public override String Text
		{
			get { return EditText; }
			set { EditText = value; }
		}

		/// <summary>
		/// Gets or sets the text to edit.
		/// </summary>
		[Category("Appearance"), 
		 Browsable(true), 
		 Description("The text to edit.")]
		public String EditText
		{
			get { return textBox1.Text; }
			set { textBox1.Text = value; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Raised when the text changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void TextBox1TextChanged(object sender, EventArgs e)
		{
			if (EditTextChanged != null) EditTextChanged(this,e);
		}
		
		#endregion
		
	}
}
