/*
 * User: lgermain
 * Date: 26/06/2008 10:48
 */
namespace LuGe.DatabaseQuery
{
	partial class DataTableForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataTableForm));
			this.ToolStripButtonFilter = new System.Windows.Forms.ToolStripButton();
			this.ToolStripTextBoxFilterValue = new System.Windows.Forms.ToolStripTextBox();
			this.ToolStripComboBoxFilterSign = new System.Windows.Forms.ToolStripComboBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.ToolStripComboBoxFilterFieldName = new System.Windows.Forms.ToolStripComboBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ToolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
			this.ToolStripButtonSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripButtonImport = new System.Windows.Forms.ToolStripButton();
			this.ToolStripButtonExport = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.LabelLinesCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.DataGridViewData = new System.Windows.Forms.DataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.DataGridViewSchema = new System.Windows.Forms.DataGridView();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridViewData)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridViewSchema)).BeginInit();
			this.SuspendLayout();
			// 
			// ToolStripButtonFilter
			// 
			this.ToolStripButtonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripButtonFilter.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonFilter.Image")));
			this.ToolStripButtonFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripButtonFilter.Name = "ToolStripButtonFilter";
			this.ToolStripButtonFilter.Size = new System.Drawing.Size(23, 22);
			this.ToolStripButtonFilter.Text = "Filter";
			this.ToolStripButtonFilter.Click += new System.EventHandler(this.ToolStripButtonFilterClick);
			// 
			// ToolStripTextBoxFilterValue
			// 
			this.ToolStripTextBoxFilterValue.Name = "ToolStripTextBoxFilterValue";
			this.ToolStripTextBoxFilterValue.Size = new System.Drawing.Size(90, 25);
			// 
			// ToolStripComboBoxFilterSign
			// 
			this.ToolStripComboBoxFilterSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ToolStripComboBoxFilterSign.Items.AddRange(new object[] {
									"=",
									">",
									">=",
									"<",
									"<=",
									"Like"});
			this.ToolStripComboBoxFilterSign.Name = "ToolStripComboBoxFilterSign";
			this.ToolStripComboBoxFilterSign.Size = new System.Drawing.Size(75, 25);
			// 
			// ToolStripComboBoxFilterFieldName
			// 
			this.ToolStripComboBoxFilterFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ToolStripComboBoxFilterFieldName.Name = "ToolStripComboBoxFilterFieldName";
			this.ToolStripComboBoxFilterFieldName.Size = new System.Drawing.Size(100, 25);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.ToolStripButtonLoad,
									this.ToolStripButtonSave,
									this.toolStripSeparator1,
									this.ToolStripButtonImport,
									this.ToolStripButtonExport,
									this.toolStripSeparator2,
									this.toolStripLabel1,
									this.ToolStripComboBoxFilterFieldName,
									this.ToolStripComboBoxFilterSign,
									this.ToolStripTextBoxFilterValue,
									this.ToolStripButtonFilter});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(450, 25);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// ToolStripButtonLoad
			// 
			this.ToolStripButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonLoad.Image")));
			this.ToolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripButtonLoad.Name = "ToolStripButtonLoad";
			this.ToolStripButtonLoad.Size = new System.Drawing.Size(23, 22);
			this.ToolStripButtonLoad.Text = "Load all data from the database.";
			this.ToolStripButtonLoad.Click += new System.EventHandler(this.ToolStripButtonLoadClick);
			// 
			// ToolStripButtonSave
			// 
			this.ToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonSave.Image")));
			this.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripButtonSave.Name = "ToolStripButtonSave";
			this.ToolStripButtonSave.Size = new System.Drawing.Size(23, 22);
			this.ToolStripButtonSave.Text = "Save all data to the database.";
			this.ToolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSaveClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// ToolStripButtonImport
			// 
			this.ToolStripButtonImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripButtonImport.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonImport.Image")));
			this.ToolStripButtonImport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripButtonImport.Name = "ToolStripButtonImport";
			this.ToolStripButtonImport.Size = new System.Drawing.Size(23, 22);
			this.ToolStripButtonImport.Text = "Import data from file.";
			this.ToolStripButtonImport.ToolTipText = "Import data from file.";
			this.ToolStripButtonImport.Click += new System.EventHandler(this.ToolStripButtonImportClick);
			// 
			// ToolStripButtonExport
			// 
			this.ToolStripButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ToolStripButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonExport.Image")));
			this.ToolStripButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripButtonExport.Name = "ToolStripButtonExport";
			this.ToolStripButtonExport.Size = new System.Drawing.Size(23, 22);
			this.ToolStripButtonExport.Text = "Export data to file.";
			this.ToolStripButtonExport.ToolTipText = "Export data to file.";
			this.ToolStripButtonExport.Click += new System.EventHandler(this.ToolStripButtonExportClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(38, 22);
			this.toolStripLabel1.Text = "Filter :";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
			this.toolStripStatusLabel1.Text = "Lines count :";
			// 
			// LabelLinesCount
			// 
			this.LabelLinesCount.Name = "LabelLinesCount";
			this.LabelLinesCount.Size = new System.Drawing.Size(13, 17);
			this.LabelLinesCount.Text = "0";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel2,
									this.toolStripStatusLabel3});
			this.statusStrip1.Location = new System.Drawing.Point(0, 300);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(450, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 17);
			this.toolStripStatusLabel2.Text = "Lines count :";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 17);
			this.toolStripStatusLabel3.Text = "0";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 25);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(450, 275);
			this.tabControl1.TabIndex = 8;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.DataGridViewData);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(442, 249);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Data";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// DataGridViewData
			// 
			this.DataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridViewData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataGridViewData.Location = new System.Drawing.Point(3, 3);
			this.DataGridViewData.Name = "DataGridViewData";
			this.DataGridViewData.Size = new System.Drawing.Size(436, 243);
			this.DataGridViewData.TabIndex = 4;
			this.DataGridViewData.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DataGridViewDataUserAddedRow);
			this.DataGridViewData.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DataGridViewDataUserDeletedRow);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.DataGridViewSchema);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(442, 249);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Schema";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// DataGridViewSchema
			// 
			this.DataGridViewSchema.AllowUserToAddRows = false;
			this.DataGridViewSchema.AllowUserToDeleteRows = false;
			this.DataGridViewSchema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridViewSchema.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataGridViewSchema.Location = new System.Drawing.Point(3, 3);
			this.DataGridViewSchema.Name = "DataGridViewSchema";
			this.DataGridViewSchema.ReadOnly = true;
			this.DataGridViewSchema.Size = new System.Drawing.Size(436, 243);
			this.DataGridViewSchema.TabIndex = 0;
			// 
			// DataTableForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(450, 322);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(458, 349);
			this.Name = "DataTableForm";
			this.Text = "Data table";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataTableFormFormClosed);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataGridViewData)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataGridViewSchema)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.DataGridView DataGridViewSchema;
		private System.Windows.Forms.ToolStripButton ToolStripButtonFilter;
		private System.Windows.Forms.ToolStripStatusLabel LabelLinesCount;
		private System.Windows.Forms.ToolStripTextBox ToolStripTextBoxFilterValue;
		private System.Windows.Forms.DataGridView DataGridViewData;
		private System.Windows.Forms.ToolStripComboBox ToolStripComboBoxFilterSign;
		private System.Windows.Forms.ToolStripComboBox ToolStripComboBoxFilterFieldName;
		private System.Windows.Forms.ToolStripButton ToolStripButtonLoad;
		private System.Windows.Forms.ToolStripButton ToolStripButtonSave;
		private System.Windows.Forms.ToolStripButton ToolStripButtonImport;
		private System.Windows.Forms.ToolStripButton ToolStripButtonExport;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
	}
}
