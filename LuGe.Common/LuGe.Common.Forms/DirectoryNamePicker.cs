/*
 * User: lgermain
 * Date: 10/09/2008 08:45
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LuGe.Common.Forms
{
	/// <summary>
	/// Text box and button to get a directory name.
	/// </summary>
	[ToolboxBitmap(typeof(DirectoryNamePicker), "Resources.TextboxWithLabel.bmp")]
	public partial class DirectoryNamePicker : UserControl
	{
		
		#region Fields

		private string _description; // the description displayed in the directory dialog.
		
		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public DirectoryNamePicker()
		{
			InitializeComponent();
		}
		
		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the label.
		/// </summary>
		[Category("Appearance"), 
		 Browsable(true), 
		 Description("The label that identify the control.")]
		public String LabelText
		{
			get { return textboxWithLabel1.LabelText; }
			set { textboxWithLabel1.LabelText = value; }
		}
		
		/// <summary>
		/// Gets or sets the directory name.
		/// </summary>
		/// <remarks>Same as the <see cref="DirectoryName">DirectoryName</see> property.</remarks>
		[Category("Appearance"), 
		 Browsable(true), 
		 Description("The text associated with the control.")]
		public override String Text
		{
			get { return DirectoryName; }
			set { DirectoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the description displayed in the directory dialog.
		/// </summary>
		/// <remarks>Equal to the DirectoryName property.</remarks>
		[Category("Appearance"), 
		 Browsable(true), 
		 Description("The description displayed in the directory dialog.")]
		public String Description
		{
			get { return _description; }
			set { _description = value; }
		}
		
		/// <summary>
		/// Gets or sets the directory name.
		/// </summary>
		/// <remarks>Equal to the Text property.</remarks>
		[Category("Data"), 
		 Browsable(true), 
		 Description("The directory first shown in the dialog box, or the last one selected by the user.")]
		public string DirectoryName {
			get { return textboxWithLabel1.Text; }
			set { textboxWithLabel1.Text = value; }
		}

		#endregion

		#region Methods
		
		/// <summary>
		/// Raised when the dir button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void ButtonDirClick(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			
			dialog.Description = this.Description;
			dialog.SelectedPath = this.DirectoryName;
			
			DialogResult result = dialog.ShowDialog();
			
			if (result != DialogResult.OK) return;
			
			this.DirectoryName = dialog.SelectedPath;
		}
		
		#endregion

	}
}
