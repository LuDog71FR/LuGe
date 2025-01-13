/*
 * User: lgermain
 * Date: 08/08/2008 10:56
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LuGe.Common.Forms
{
	/// <summary>
	/// Text box and button to get a file name.
	/// </summary>
	[ToolboxBitmap(typeof(FileNamePicker), "Resources.TextboxWithLabel.bmp")]
	public partial class FileNamePicker : UserControl
	{
		
		#region Fields

		private string _filter; // the file filters.
		private EFileDialogKind _fileDialogKind; // the kind of file dialog to display.
		
		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public FileNamePicker()
		{
			InitializeComponent();
			
			_filter = "All files (*.*)|*.*";
			_fileDialogKind = EFileDialogKind.OpenDialog;
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
		/// Gets or sets the file name.
		/// </summary>
		/// <remarks>Same as the <see cref="FileName">FileName</see> property.</remarks>
		[Category("Appearance"),
		 Browsable(true),
		 Description("The text associated with the control.")]
		public override String Text
		{
			get { return FileName; }
			set { FileName = value; }
		}
		
		/// <summary>
		/// Gets or sets the file name.
		/// </summary>
		/// <remarks>Equal to the Text property.</remarks>
		[Category("Data"),
		 Browsable(true),
		 Description("The file first shown in the dialog box, or the last one selected by the user.")]
		public string FileName {
			get { return textboxWithLabel1.Text; }
			set { textboxWithLabel1.Text = value; }
		}

		/// <summary>
		/// Gets or sets the file filters.
		/// </summary>
		[Category("Behavior"),
		 Browsable(true),
		 Description("The file filters to display in the dialog box."),
		 DefaultValue("All files (*.*)|*.*")]
		public string Filter
		{
			get { return _filter; }
			set { _filter = value; }
		}

		/// <summary>
		/// Gets or sets the kind of file dialog to display.
		/// </summary>
		[Category("Behavior"),
		 Browsable(true),
		 Description("The kind of file dialog to display."),
		 DefaultValue(EFileDialogKind.OpenDialog)]
		public EFileDialogKind FileDialogKind
		{
			get { return _fileDialogKind; }
			set { _fileDialogKind = value; }
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
			FileDialog dialog;
			
			switch (FileDialogKind)
			{
				case EFileDialogKind.OpenDialog:
					dialog = new OpenFileDialog();
					dialog.Title = "Open file ...";
					break;
					
				case EFileDialogKind.SaveDialog:
					dialog = new SaveFileDialog();
					dialog.Title = "Save file ...";
					break;
					
				default:
					throw new InvalidOperationException("File dialog kind unknown.");
			}
			
			dialog.Filter = this.Filter;
			dialog.FileName = this.FileName;
			
			DialogResult result = dialog.ShowDialog();
			
			if (result != DialogResult.OK) return;
			
			this.FileName = dialog.FileName;
		}
		
		#endregion

	}
}
