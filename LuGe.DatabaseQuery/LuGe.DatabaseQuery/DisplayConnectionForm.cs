/*
 * User: lgermain
 * Date: 04/07/2008 13:50
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using LuGe.Common;

namespace LuGe.DatabaseQuery
{
	/// <summary>
	/// Form for displaying informations about a connection.
	/// </summary>
	/// <remarks>
	/// The connection is stored on the config file of the application.
	/// </remarks>
	public partial class DisplayConnectionForm : Form
	{
		#region Fields
		
		private ConnectionInfoSettings _settings; // connection settings.
		
		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public DisplayConnectionForm()
		{
			InitializeComponent();
			
			_settings = LIConfiguration<ConnectionInfoSettings>.Load();
		}
		
		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the connection name.
		/// </summary>
		public string ConnectionName
		{
			get { return textBoxName.Text; }
			set { textBoxName.Text = value; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Raised when the form is loaded.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void ViewConnectionFormLoad(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(ConnectionName)) return;
			
			ConnectionInfo setting = _settings.Connections[ConnectionName];
			
			textBoxProvider.Text = setting.ProviderName;
			textBoxConnectionString.Text = setting.ConnectionString;
		}
		
		#endregion
	}
}
