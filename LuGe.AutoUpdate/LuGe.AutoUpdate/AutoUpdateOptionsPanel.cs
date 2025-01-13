/*
 * User: lgermain
 * Date: 14/10/2008 08:54
 */

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using LuGe.Common;

namespace LuGe.AutoUpdate
{
	/// <summary>
	/// User control to manage settings for auto update.
	/// </summary>
	public partial class AutoUpdateOptionsPanel : UserControl
	{
		/// <summary>
		/// Creates a new instance of the class.
		/// </summary>
		public AutoUpdateOptionsPanel()
		{
			InitializeComponent();
			
			checkBoxProduct.Text = Application.ProductName;
		}
		
		/// <summary>
		/// Load the settings from the configuration file of the application.
		/// </summary>
		public void LoadSettings()
		{
			UpdateSettings settings = LIConfiguration<UpdateSettings>.Load();
			
			checkBoxProduct.Checked = settings.Enable;
			radioButtonAsk.Checked = settings.AskBefore;
			textBoxUrl.Text = settings.Url;
			checkBoxDisplayChanges.Checked = settings.DisplayChangeLog;
		}
		
		/// <summary>
		/// Save the settings to the configuration file of the application.
		/// </summary>
		public void SaveSettings()
		{
			UpdateSettings settings = new UpdateSettings();
			
			settings.Enable = checkBoxProduct.Checked;
			settings.AskBefore = radioButtonAsk.Checked;
			settings.Url = textBoxUrl.Text;
			settings.DisplayChangeLog = checkBoxDisplayChanges.Checked;
			
			LIConfiguration<UpdateSettings>.Save(settings);
		}
		
		/// <summary>
		/// Raised when the Checked value changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void CheckBoxProductCheckedChanged(object sender, EventArgs e)
		{
			radioButtonAsk.Enabled = checkBoxProduct.Checked;
			radioButtonDownload.Enabled = checkBoxProduct.Checked;
			textBoxUrl.Enabled = checkBoxProduct.Checked;
			checkBoxDisplayChanges.Enabled = checkBoxProduct.Checked;
		}
	}
}
