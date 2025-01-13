/*
 * User: lgermain
 * Date: 25/06/2008 10:10
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

using LuGe.Common;
using LuGe.Common.Data;
using LuGe.Common.Forms;
using LuGe.Common.Forms.Configuration;

namespace LuGe.DatabaseQuery
{
	/// <summary>
	/// Main form of the application.
	/// </summary>
	public partial class MainForm : Form
	{
		
		#region Fields

		private LIConnection _connection; // Main connection.
		
		private List<ToolStripItem> _connectionMenus; // List of connections.
		private List<ToolStripItem> _tableMenus; // List of tables.
		private ToolsMenu _toolMenu; // Tools menu manager.
		
		#endregion
		
		#region Constructors

		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			
			ToolStripManager.Renderer = new ActarisRenderer();
			
			_connectionMenus = new List<ToolStripItem>();
			_tableMenus = new List<ToolStripItem>();
			_toolMenu = new ToolsMenu(toolsToolStripMenuItem);
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the active connection.
		/// </summary>
		public LIConnection Connection {
			get { return _connection; }
		}
		
		/// <summary>
		/// Gets or sets the message displayed
		/// in the status bar of the main form.
		/// </summary>
		public string Message {
			get { return messageToolStripStatusLabel.Text; }
			set { messageToolStripStatusLabel.Text = value; }
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Refresh the list of tables.
		/// </summary>
		public void RefreshTables()
		{
			DisplayListOfTables();
		}
		
		/// <summary>
		/// Display the list of available connections
		/// in the submenu "Connect to" and in the toolbar.
		/// </summary>
		private void DisplayListOfConnections()
		{
			DeleteConnectionMenu();
			
			ConnectionInfoSettings settings = LIConfiguration<ConnectionInfoSettings>.Load();
			
			foreach(ConnectionInfo connection in settings.Connections)
			{
				ToolStripMenuItem item =
					(ToolStripMenuItem)connectToToolStripMenuItem.DropDownItems.Add(connection.Name);
				
				ToolStripItem subItem = item.DropDownItems.Add(
					"Connect to",
					LIResource.GetEmbeddedImage("database_connect.png"),
					ConnectToDatabase_Click);
				subItem.Tag = connection.Name;
				
				subItem = item.DropDownItems.Add(
					"Display",
					LIResource.GetEmbeddedImage("page_white_database.png"),
					DisplayConnectionToolStripMenuItemClick);
				subItem.Tag = connection.Name;
				
				subItem = item.DropDownItems.Add(
					"Edit",
					LIResource.GetEmbeddedImage("database_edit.png"),
					EditConnectionToolStripMenuItemClick);
				subItem.Tag = connection.Name;
				
				subItem = item.DropDownItems.Add(
					"Delete",
					LIResource.GetEmbeddedImage("database_delete.png"),
					DeleteConnectionToolStripMenuItemClick);
				subItem.Tag = connection.Name;
				
				subItem = connectToToolStripDropDownButton.DropDownItems.Add(
					connection.Name, null, ConnectToDatabase_Click);
				subItem.Tag = connection.Name;
				
				_connectionMenus.Add(item);
			}
		}
		
		/// <summary>
		/// Display the list of available tables
		/// in the submenu "Tables" and in the toolbar.
		/// </summary>
		private void DisplayListOfTables()
		{
			DeleteTablesMenu();
			
			if (_connection == null) return;
			
			List<string> sortedTables = new List<string>(_connection.ListAllTables());
			sortedTables.Sort();
			
			foreach(string tableName in sortedTables)
			{
				_tableMenus.Add(
					tablesToolStripMenuItem.DropDownItems.Add(
						tableName, null, DatabaseTable_Click));
				
				tablesToolStripDropDownButton.DropDownItems.Add(
					tableName, null, DatabaseTable_Click);
			}
		}
		
		/// <summary>
		/// Delete all the items created for each connection
		/// in the menu and the toolbar.
		/// </summary>
		private void DeleteConnectionMenu()
		{
			foreach(ToolStripItem item in _connectionMenus)
			{
				connectToToolStripMenuItem.DropDownItems.Remove(item);
			}
			
			_connectionMenus.Clear();
			connectToToolStripDropDownButton.DropDownItems.Clear();
		}
		
		/// <summary>
		/// Delete all the items created for each table
		/// of the database	in the menu and the toolbar.
		/// </summary>
		private void DeleteTablesMenu()
		{
			foreach(ToolStripItem item in _tableMenus)
			{
				tablesToolStripMenuItem.DropDownItems.Remove(item);
			}
			
			_tableMenus.Clear();
			tablesToolStripDropDownButton.DropDownItems.Clear();
		}
		
		/// <summary>
		/// Toggle the enable property of all buttons
		/// according to the connection or not.
		/// </summary>
		private void ToggleButtons()
		{
			bool connected = (_connection != null);
			
			connectToToolStripMenuItem.Enabled = !connected;
			disconnectToolStripMenuItem.Enabled = connected;
			propertiesToolStripMenuItem.Enabled = connected;
			executeQueryToolStripMenuItem.Enabled = connected;
			refreshToolStripMenuItem.Enabled = connected;
			connectToToolStripDropDownButton.Enabled = !connected;
			disconnectToolStripButton.Enabled = connected;
			executeQueryToolStripButton.Enabled = connected;
			tablesToolStripDropDownButton.Enabled = connected;
			
			if (connected && _connection.UseTransaction)
			{
				saveToolStripMenuItem.Enabled = connected;
				cancelToolStripMenuItem.Enabled = connected;
				saveToolStripButton.Enabled = connected;
				cancelToolStripButton.Enabled = connected;
			}
			else
			{
				saveToolStripMenuItem.Enabled = false;
				cancelToolStripMenuItem.Enabled = false;
				saveToolStripButton.Enabled = false;
				cancelToolStripButton.Enabled = false;
			}
		}
		
		/// <summary>
		/// Raised when the form is loaded.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void MainFormLoad(object sender, EventArgs e)
		{			
			LIVersion version = new LIVersion(Assembly.GetExecutingAssembly());
			
			this.Text += " " + version.ToString();
			
			ToggleButtons();
			DisplayListOfConnections();
		}
		
		/// <summary>
		/// Raised when the quit menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void QuitToolStripMenuItemClick(object sender, EventArgs e)
		{
			DisconnectToolStripMenuItemClick(sender, e);
			Application.Exit();
		}
		
		/// <summary>
		/// Raised when the about menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			AboutForm form = new AboutForm();
			form.ShowDialog(this);
		}
		
		/// <summary>
		/// Raised when the "new connection" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void NewConnectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateConnectionForm form = new CreateConnectionForm();
			DialogResult result = form.ShowDialog(this);
			
			if (result != DialogResult.OK) return;
			
			DisplayListOfConnections();
			messageToolStripStatusLabel.Text = "New connection created !";
		}
		
		/// <summary>
		/// Raised when the "edit connection" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void EditConnectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			EditConnectionForm form = new EditConnectionForm();
			form.ConnectionName = (sender as ToolStripItem).Tag.ToString();
			DialogResult result = form.ShowDialog(this);
			
			if (result != DialogResult.OK) return;
			
			DisplayListOfConnections();
			messageToolStripStatusLabel.Text = "Connection updated !";
		}
		
		/// <summary>
		/// Raised when the "edit connection" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void DeleteConnectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			string name = (sender as ToolStripItem).Tag.ToString();
			
			DialogResult result = MessageBox.Show(
				"Do you wants to delete the connection '" +
				name + "' ?", "Delete connection", MessageBoxButtons.YesNo);
			
			if (result == DialogResult.No) return;
			
			ConnectionInfoSettings settings = LIConfiguration<ConnectionInfoSettings>.Load();
			if (settings.Connections.Count == 0) settings.LoadDefault();		
			
			settings.Connections.Remove(name);
			
			LIConfiguration<ConnectionInfoSettings>.Save(settings);
			
			DisplayListOfConnections();
			messageToolStripStatusLabel.Text = "Connection deleted !";
		}
		
		/// <summary>
		/// Raised when the "display connection" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void DisplayConnectionToolStripMenuItemClick(object sender, EventArgs e)
		{
			DisplayConnectionForm form = new DisplayConnectionForm();
			form.ConnectionName = (sender as ToolStripItem).Tag.ToString();
			form.ShowDialog(this);
		}
		
		/// <summary>
		/// Raised when the "Properties" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void PropertiesToolStripMenuItemClick(object sender, EventArgs e)
		{
			DisplayConnectionForm form = new DisplayConnectionForm();
			form.ConnectionName = databaseToolStripStatusLabel.Text;
			form.ShowDialog(this);
		}
		
		/// <summary>
		/// Raised when a table menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void DatabaseTable_Click(object sender, EventArgs e)
		{
			DataTableForm form = new DataTableForm();
			form.MdiParent = this;
			bool result = form.LoadTable((sender as ToolStripItem).Text);
			
			if (result == false) return;
			
			form.Show();
		}
		
		/// <summary>
		/// Raised when the "connect to" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ConnectToDatabase_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			
			string connectionName = (sender as ToolStripItem).Tag.ToString();
			
			Directory.SetCurrentDirectory(Application.UserAppDataPath);
			
			bool result;
			try
			{
				AppSettings appSettings = LIConfiguration<AppSettings>.Load();
				ConnectionInfoSettings connectSettings = LIConfiguration<ConnectionInfoSettings>.Load();
				
				_connection = new LIConnection(
					connectSettings.Connections[connectionName].ProviderName,
					connectSettings.Connections[connectionName].ConnectionString,
					appSettings.UseTransaction);
				result = _connection.Connect();
			}
			catch (Exception ex)
			{
				messageToolStripStatusLabel.Text = "Connection failed : " + ex.Message;
				this.Cursor = Cursors.Default;
				return;
			}
			
			if (result == false)
			{
				messageToolStripStatusLabel.Text = "Connection failed !";
				this.Cursor = Cursors.Default;
				return;
			}
			
			DisplayListOfTables();
			ToggleButtons();
			
			databaseToolStripStatusLabel.Text = connectionName;
			messageToolStripStatusLabel.Text = String.Empty;
			
			this.Cursor = Cursors.Default;
		}
		
		/// <summary>
		/// Raised when the disconnect menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void DisconnectToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (_connection == null) return;

			this.Cursor = Cursors.WaitCursor;
			
			_connection.Disconnect();
			_connection.Dispose();
			_connection = null;
			
			DeleteTablesMenu();
			ToggleButtons();
			CloseAllToolStripMenuItemClick(sender, e);
			
			databaseToolStripStatusLabel.Text = "Not connected";
			messageToolStripStatusLabel.Text = string.Empty;
			
			this.Cursor = Cursors.Default;
		}
		
		/// <summary>
		/// Raised when the save menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (_connection == null) return;
			
			this.Cursor = Cursors.WaitCursor;
			
			_connection.Transaction.Commit();
			messageToolStripStatusLabel.Text = "Save database done !";
			
			this.Cursor = Cursors.Default;
		}
		
		/// <summary>
		/// Raised when the cancel menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void CancelToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (_connection == null) return;
			
			this.Cursor = Cursors.WaitCursor;
			
			_connection.Transaction.Rollback();
			messageToolStripStatusLabel.Text = "Cancel database done !";
			
			this.Cursor = Cursors.Default;
		}

		/// <summary>
		/// Raised when the "execute query" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ExecuteQueryToolStripMenuItemClick(object sender, EventArgs e)
		{
			ExecQueryForm form = new ExecQueryForm();
			form.MdiParent = this;
			form.Show();
		}

		/// <summary>
		/// Raised when the "tile horizontal" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void TilehorizontalToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}
		
		/// <summary>
		/// Raised when the "tile vertical" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void TileverticalToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}
		
		/// <summary>
		/// Raised when the "tile cascade" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void TileCascadeToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}
		
		/// <summary>
		/// Raised when the "tile icons" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void TileIconsToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.LayoutMdi(MdiLayout.ArrangeIcons);
		}
		
		/// <summary>
		/// Raised when the "close all" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void CloseAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach(Form form in this.MdiChildren)
			{
				form.Close();
			}
		}
		
		/// <summary>
		/// Raised when the "refresh" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void RefreshToolStripMenuItemClick(object sender, EventArgs e)
		{
			RefreshTables();
		}
		
		/// <summary>
		/// Raised when the "options" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void OptionsToolStripMenuItemClick(object sender, EventArgs e)
		{
			OptionsForm form = new OptionsForm();
			form.ShowDialog(this);
		}
		
		/// <summary>
		/// Raised when the "restart" menu is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void RestartToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Restart();
		}
		
		void MainFormShown(object sender, EventArgs e)
		{
			NativeMethods.SetForegroundWindow(this.Handle);
			this.BringToFront();
			this.Activate();
		}

		#endregion
	}
}
