/*
 * User: lgermain
 * Date: 07/11/2008 13:19
 */

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace LuGe.Common.Forms
{
	/// <summary>
	/// Form that display the current version of the application and
	/// the last changes made to it.
	/// </summary>
	public partial class ChangeLogForm : Form
	{
		
		#region Fields
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Creates a new instance of the class.
		/// </summary>
		public ChangeLogForm()
		{
			InitializeComponent();
			
			LoadChangeLog();
		}
		
		#endregion

		#region Properties

		#endregion

		#region Methods
		
		/// <summary>
		/// Load the ChangeLog files and display the other informations
		/// about the application.
		/// </summary>
		private void LoadChangeLog()
		{
			this.UseWaitCursor = true;
			
			Version appVersion = new Version(Application.ProductVersion);
			versionTextBox.Text = appVersion.ToString(3);
			
			titleLabel.Text = SplashForm.AppTitle;
			
			Icon appIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			pictureBoxIcon.Image = appIcon.ToBitmap();			
			
			string fileName = Path.Combine(
				Path.GetDirectoryName(Application.ExecutablePath), 
				"ChangeLog.txt");
			
			if (File.Exists(fileName)) 
			{
				richTextBox1.LoadFile(fileName, RichTextBoxStreamType.PlainText);
			}
			else
			{
				richTextBox1.Text = "No informations available !";
			}			
			
			this.UseWaitCursor = false;
		}
		
		/// <summary>
		/// Raised when the close button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void CloseButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		#endregion
		
	}
}
