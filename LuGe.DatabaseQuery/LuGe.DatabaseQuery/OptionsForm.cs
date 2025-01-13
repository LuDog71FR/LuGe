/*
 * User: lgermain
 * Date: 04/09/2008 16:26
 */

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using LuGe.Common;

namespace LuGe.DatabaseQuery
{
	/// <summary>
	/// Form to manage the options of the application.
	/// </summary>
	public partial class OptionsForm : Form
	{
		
		#region Fields
		
		#endregion

		#region Constructors
		
		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public OptionsForm()
		{
			InitializeComponent();

			LoadSettings();
		}
		
		#endregion

		#region Properties

		#endregion

		#region Methods
		
		/// <summary>
		/// Load the settings from the configuration file of the application.
		/// </summary>
		private void LoadSettings()
		{
			AppSettings settings = LIConfiguration<AppSettings>.Load();
			checkBoxUseTransac.Checked = settings.UseTransaction;
			
			autoUpdateOptionsPanel1.LoadSettings();
		}
		
		/// <summary>
		/// Save the settings to the configuration file of the application.
		/// </summary>
		private void SaveSettings()
		{
			AppSettings settings = new AppSettings();
			settings.UseTransaction = checkBoxUseTransac.Checked;
			LIConfiguration<AppSettings>.Save(settings);
			
			autoUpdateOptionsPanel1.SaveSettings();
		}
		
		/// <summary>
		/// Raised when the "save" button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonSaveClick(object sender, EventArgs e)
		{
			SaveSettings();
			
			this.Close();
		}
		
		/// <summary>
		/// Raised when the "cancel" button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		/// <summary>
		/// Raised when the "reload" button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonReloadClick(object sender, EventArgs e)
		{
			LoadSettings();
		}
		
		/// <summary>
		/// Raised when the "reload" button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonReloadDefaultClick(object sender, EventArgs e)
		{
			Directory.Delete(Path.GetDirectoryName(Application.UserAppDataPath), true);
			
			if (MessageBox.Show(
				"The application must be restart.\r\n Do you want to continue ?",
				"Restart application",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.No) return;
			
			Application.Restart();
		}
		
		#endregion
		
	}
}
