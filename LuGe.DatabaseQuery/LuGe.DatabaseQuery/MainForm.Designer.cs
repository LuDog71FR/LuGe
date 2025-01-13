/*
 * User: lgermain
 * Date: 25/06/2008 10:10
 */
namespace LuGe.DatabaseQuery
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.executeQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tilehorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileverticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileCascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.databaseToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.messageToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.connectToToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.disconnectToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.cancelToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.executeQueryToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.tablesToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.databaseToolStripMenuItem,
									this.tablesToolStripMenuItem,
									this.toolsToolStripMenuItem,
									this.windowToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(646, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// databaseToolStripMenuItem
			// 
			this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.connectToToolStripMenuItem,
									this.disconnectToolStripMenuItem,
									this.propertiesToolStripMenuItem,
									this.toolStripMenuItem1,
									this.saveToolStripMenuItem,
									this.cancelToolStripMenuItem,
									this.toolStripMenuItem2,
									this.optionsToolStripMenuItem,
									this.toolStripSeparator4,
									this.quitToolStripMenuItem,
									this.restartToolStripMenuItem});
			this.databaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("databaseToolStripMenuItem.Image")));
			this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
			this.databaseToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
			this.databaseToolStripMenuItem.Text = "&Database";
			// 
			// connectToToolStripMenuItem
			// 
			this.connectToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newConnectionToolStripMenuItem,
									this.toolStripMenuItem3});
			this.connectToToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectToToolStripMenuItem.Image")));
			this.connectToToolStripMenuItem.Name = "connectToToolStripMenuItem";
			this.connectToToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.connectToToolStripMenuItem.Text = "&Connect to";
			// 
			// newConnectionToolStripMenuItem
			// 
			this.newConnectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newConnectionToolStripMenuItem.Image")));
			this.newConnectionToolStripMenuItem.Name = "newConnectionToolStripMenuItem";
			this.newConnectionToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.newConnectionToolStripMenuItem.Text = "&New ...";
			this.newConnectionToolStripMenuItem.Click += new System.EventHandler(this.NewConnectionToolStripMenuItemClick);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(107, 6);
			// 
			// disconnectToolStripMenuItem
			// 
			this.disconnectToolStripMenuItem.Enabled = false;
			this.disconnectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disconnectToolStripMenuItem.Image")));
			this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
			this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.disconnectToolStripMenuItem.Text = "&Disconnect";
			this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.DisconnectToolStripMenuItemClick);
			// 
			// propertiesToolStripMenuItem
			// 
			this.propertiesToolStripMenuItem.Enabled = false;
			this.propertiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("propertiesToolStripMenuItem.Image")));
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.propertiesToolStripMenuItem.Text = "&Properties";
			this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItemClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// cancelToolStripMenuItem
			// 
			this.cancelToolStripMenuItem.Enabled = false;
			this.cancelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cancelToolStripMenuItem.Image")));
			this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
			this.cancelToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.cancelToolStripMenuItem.Text = "&Cancel";
			this.cancelToolStripMenuItem.Click += new System.EventHandler(this.CancelToolStripMenuItemClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(130, 6);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.optionsToolStripMenuItem.Text = "&Options ...";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItemClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(130, 6);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitToolStripMenuItem.Image")));
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.quitToolStripMenuItem.Text = "&Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItemClick);
			// 
			// restartToolStripMenuItem
			// 
			this.restartToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartToolStripMenuItem.Image")));
			this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
			this.restartToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.restartToolStripMenuItem.Text = "Res&tart";
			this.restartToolStripMenuItem.ToolTipText = "Restart the application";
			this.restartToolStripMenuItem.Click += new System.EventHandler(this.RestartToolStripMenuItemClick);
			// 
			// tablesToolStripMenuItem
			// 
			this.tablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.executeQueryToolStripMenuItem,
									this.refreshToolStripMenuItem,
									this.toolStripMenuItem4});
			this.tablesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tablesToolStripMenuItem.Image")));
			this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
			this.tablesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
			this.tablesToolStripMenuItem.Text = "&Tables";
			// 
			// executeQueryToolStripMenuItem
			// 
			this.executeQueryToolStripMenuItem.Enabled = false;
			this.executeQueryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("executeQueryToolStripMenuItem.Image")));
			this.executeQueryToolStripMenuItem.Name = "executeQueryToolStripMenuItem";
			this.executeQueryToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.executeQueryToolStripMenuItem.Text = "&Execute query";
			this.executeQueryToolStripMenuItem.Click += new System.EventHandler(this.ExecuteQueryToolStripMenuItemClick);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Enabled = false;
			this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.refreshToolStripMenuItem.Text = "&Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItemClick);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(144, 6);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolsToolStripMenuItem.Image")));
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.toolsToolStripMenuItem.Text = "T&ools";
			// 
			// windowToolStripMenuItem
			// 
			this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tilehorizontalToolStripMenuItem,
									this.tileverticalToolStripMenuItem,
									this.tileCascadeToolStripMenuItem,
									this.tileIconsToolStripMenuItem,
									this.closeAllToolStripMenuItem,
									this.toolStripSeparator1});
			this.windowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("windowToolStripMenuItem.Image")));
			this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
			this.windowToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
			this.windowToolStripMenuItem.Text = "&Window";
			// 
			// tilehorizontalToolStripMenuItem
			// 
			this.tilehorizontalToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tilehorizontalToolStripMenuItem.Image")));
			this.tilehorizontalToolStripMenuItem.Name = "tilehorizontalToolStripMenuItem";
			this.tilehorizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.tilehorizontalToolStripMenuItem.Text = "&Horizontal";
			this.tilehorizontalToolStripMenuItem.Click += new System.EventHandler(this.TilehorizontalToolStripMenuItemClick);
			// 
			// tileverticalToolStripMenuItem
			// 
			this.tileverticalToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tileverticalToolStripMenuItem.Image")));
			this.tileverticalToolStripMenuItem.Name = "tileverticalToolStripMenuItem";
			this.tileverticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.tileverticalToolStripMenuItem.Text = "&Vertical";
			this.tileverticalToolStripMenuItem.Click += new System.EventHandler(this.TileverticalToolStripMenuItemClick);
			// 
			// tileCascadeToolStripMenuItem
			// 
			this.tileCascadeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tileCascadeToolStripMenuItem.Image")));
			this.tileCascadeToolStripMenuItem.Name = "tileCascadeToolStripMenuItem";
			this.tileCascadeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.tileCascadeToolStripMenuItem.Text = "C&ascade";
			this.tileCascadeToolStripMenuItem.Click += new System.EventHandler(this.TileCascadeToolStripMenuItemClick);
			// 
			// tileIconsToolStripMenuItem
			// 
			this.tileIconsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tileIconsToolStripMenuItem.Image")));
			this.tileIconsToolStripMenuItem.Name = "tileIconsToolStripMenuItem";
			this.tileIconsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.tileIconsToolStripMenuItem.Text = "&Icons";
			this.tileIconsToolStripMenuItem.Click += new System.EventHandler(this.TileIconsToolStripMenuItemClick);
			// 
			// closeAllToolStripMenuItem
			// 
			this.closeAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeAllToolStripMenuItem.Image")));
			this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
			this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.closeAllToolStripMenuItem.Text = "&Close all";
			this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.aboutToolStripMenuItem.Text = "About ...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.databaseToolStripStatusLabel,
									this.messageToolStripStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 526);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.statusStrip1.Size = new System.Drawing.Size(646, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// databaseToolStripStatusLabel
			// 
			this.databaseToolStripStatusLabel.Name = "databaseToolStripStatusLabel";
			this.databaseToolStripStatusLabel.Size = new System.Drawing.Size(86, 17);
			this.databaseToolStripStatusLabel.Text = "Not connected";
			// 
			// messageToolStripStatusLabel
			// 
			this.messageToolStripStatusLabel.Name = "messageToolStripStatusLabel";
			this.messageToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.connectToToolStripDropDownButton,
									this.disconnectToolStripButton,
									this.toolStripSeparator2,
									this.saveToolStripButton,
									this.cancelToolStripButton,
									this.toolStripSeparator3,
									this.executeQueryToolStripButton,
									this.tablesToolStripDropDownButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(646, 25);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// connectToToolStripDropDownButton
			// 
			this.connectToToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.connectToToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("connectToToolStripDropDownButton.Image")));
			this.connectToToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.connectToToolStripDropDownButton.Name = "connectToToolStripDropDownButton";
			this.connectToToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
			this.connectToToolStripDropDownButton.Text = "Connect to";
			// 
			// disconnectToolStripButton
			// 
			this.disconnectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.disconnectToolStripButton.Enabled = false;
			this.disconnectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("disconnectToolStripButton.Image")));
			this.disconnectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.disconnectToolStripButton.Name = "disconnectToolStripButton";
			this.disconnectToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.disconnectToolStripButton.Text = "Disconnect";
			this.disconnectToolStripButton.Click += new System.EventHandler(this.DisconnectToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Enabled = false;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton.Text = "Save Database";
			this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// cancelToolStripButton
			// 
			this.cancelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cancelToolStripButton.Enabled = false;
			this.cancelToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelToolStripButton.Image")));
			this.cancelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cancelToolStripButton.Name = "cancelToolStripButton";
			this.cancelToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.cancelToolStripButton.Text = "Cancel";
			this.cancelToolStripButton.Click += new System.EventHandler(this.CancelToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// executeQueryToolStripButton
			// 
			this.executeQueryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.executeQueryToolStripButton.Enabled = false;
			this.executeQueryToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("executeQueryToolStripButton.Image")));
			this.executeQueryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.executeQueryToolStripButton.Name = "executeQueryToolStripButton";
			this.executeQueryToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.executeQueryToolStripButton.Text = "Execute query";
			this.executeQueryToolStripButton.Click += new System.EventHandler(this.ExecuteQueryToolStripMenuItemClick);
			// 
			// tablesToolStripDropDownButton
			// 
			this.tablesToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tablesToolStripDropDownButton.Enabled = false;
			this.tablesToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("tablesToolStripDropDownButton.Image")));
			this.tablesToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tablesToolStripDropDownButton.Name = "tablesToolStripDropDownButton";
			this.tablesToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
			this.tablesToolStripDropDownButton.Text = "Tables";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(646, 548);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Itron Simple Database Query";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton connectToToolStripDropDownButton;
		private System.Windows.Forms.ToolStripButton disconnectToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripButton cancelToolStripButton;
		private System.Windows.Forms.ToolStripButton executeQueryToolStripButton;
		private System.Windows.Forms.ToolStripDropDownButton tablesToolStripDropDownButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tileIconsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tileCascadeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tileverticalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tilehorizontalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel messageToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel databaseToolStripStatusLabel;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem executeQueryToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem newConnectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectToToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}
