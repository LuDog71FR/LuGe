/*
 * User: lgermain
 * Date: 25/06/2008 11:01
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using LuGe.Common.Data;
using LuGe.Common;

namespace LuGe.DatabaseQuery
{
	/// <summary>
	/// Form for creating new connection.
	/// </summary>
	/// <remarks>
	/// The connection is stored on the config file of the application.
	/// </remarks>
	public partial class CreateConnectionForm : Form
	{
		#region Fields

		private ConnectionInfoSettings _settings; // connection settings.
		
		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public CreateConnectionForm()
		{
			InitializeComponent();
			
			_settings = LIConfiguration<ConnectionInfoSettings>.Load();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the connection name.
		/// </summary>
		public string ConnectionName
		{
			get { return textBoxName.Text; }
		}
		
		#endregion
        
		#region Methods
		
		/// <summary>
		/// Populate the list of providers with
		/// the available providers on the machine.
		/// </summary>
		private void PopulateProviderList()
		{
			comboBoxProvider.Items.Clear();
			
			List<string> providers = new List<string>(LIProvider.List());
			comboBoxProvider.Items.AddRange(providers.ToArray());
		}
		
		/// <summary>
		/// Verify the values entered by the user.
		/// </summary>
		/// <returns>True if all values are good; otherwise false.</returns>
		private bool CheckValues()
		{
			if (string.IsNullOrEmpty(textBoxName.Text))
			{
				MessageBox.Show("You must enter a name !");
				textBoxName.Focus();
				return false;
			}
						
			if (_settings.Connections.Contains(textBoxName.Text))
			{
				MessageBox.Show("A connection with the same name already exists !");
				textBoxName.Focus();
				return false;
			}
			
			if (string.IsNullOrEmpty(comboBoxProvider.Text))
			{
				MessageBox.Show("You must enter or select a provider !");
				comboBoxProvider.Focus();
				return false;
			}
			
			if (LIProvider.Exists(comboBoxProvider.Text) == false)
			{
				MessageBox.Show("The provider doesn't exists !");
				comboBoxProvider.Focus();
				return false;
			}
			
			if (string.IsNullOrEmpty(textBoxConnectionString.Text))
			{
				MessageBox.Show("You must enter a connection string !");
				textBoxConnectionString.Focus();
				return false;
			}
			
			return true;
		}
		
		/// <summary>
		/// Raised when the form is loaded.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ConnectionFormLoad(object sender, EventArgs e)
		{
			PopulateProviderList();
		}
		
		/// <summary>
		/// Raised when the Create button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonCreateClick(object sender, EventArgs e)
		{
			if (CheckValues() == false) return;
			
			ConnectionInfo connection = new ConnectionInfo();
			connection.Name = textBoxName.Text;
			connection.ConnectionString = textBoxConnectionString.Text;
			connection.ProviderName = comboBoxProvider.Text;
			
			_settings.Connections.Add(connection);
			
			LIConfiguration<ConnectionInfoSettings>.Save(_settings);
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		/// <summary>
		/// Raised when the Test button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonTestClick(object sender, EventArgs e)
		{
			if (CheckValues() == false) return;
			
			LIConnection connection = new LIConnection(
				comboBoxProvider.Text,
				textBoxConnectionString.Text);
			
			string message;
			
			try
			{
				bool result = connection.Connect();
				if (result == false) message = "Connection failed !";
				else message = "Connection Ok !";
			}
			catch (Exception ex)
			{
				message = "Connection failed : " + ex.Message;
			}
			
			MessageBox.Show(message, "Connection");
			
			connection.Dispose();
		}
		
		#endregion
	}
}
