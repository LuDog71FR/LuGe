/*
 * User: lgermain
 * Date: 26/06/2008 08:51
 */
namespace LuGe.DatabaseQuery
{
	partial class ExecQueryForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecQueryForm));
			this.dataGridViewResult = new System.Windows.Forms.DataGridView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.TextBoxSqlQuery = new System.Windows.Forms.RichTextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.ButtonExecute = new System.Windows.Forms.Button();
			this.ButtonLoad = new System.Windows.Forms.Button();
			this.ButtonSave = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.LabelLinesNumber = new System.Windows.Forms.ToolStripStatusLabel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridViewResult
			// 
			this.dataGridViewResult.AllowUserToAddRows = false;
			this.dataGridViewResult.AllowUserToDeleteRows = false;
			this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewResult.Location = new System.Drawing.Point(3, 16);
			this.dataGridViewResult.Name = "dataGridViewResult";
			this.dataGridViewResult.ReadOnly = true;
			this.dataGridViewResult.Size = new System.Drawing.Size(447, 227);
			this.dataGridViewResult.TabIndex = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
			this.splitContainer1.Panel1MinSize = 126;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel2MinSize = 100;
			this.splitContainer1.Size = new System.Drawing.Size(453, 398);
			this.splitContainer1.SplitterDistance = 126;
			this.splitContainer1.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tableLayoutPanel1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(453, 126);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.TextBoxSqlQuery, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(447, 107);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(345, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "SQL Query to execute :";
			// 
			// TextBoxSqlQuery
			// 
			this.TextBoxSqlQuery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TextBoxSqlQuery.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBoxSqlQuery.Location = new System.Drawing.Point(3, 23);
			this.TextBoxSqlQuery.Name = "TextBoxSqlQuery";
			this.TextBoxSqlQuery.Size = new System.Drawing.Size(345, 81);
			this.TextBoxSqlQuery.TabIndex = 1;
			this.TextBoxSqlQuery.Text = "";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.ButtonExecute);
			this.flowLayoutPanel1.Controls.Add(this.ButtonLoad);
			this.flowLayoutPanel1.Controls.Add(this.ButtonSave);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(354, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel1, 2);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(90, 101);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// ButtonExecute
			// 
			this.ButtonExecute.Image = ((System.Drawing.Image)(resources.GetObject("ButtonExecute.Image")));
			this.ButtonExecute.Location = new System.Drawing.Point(3, 71);
			this.ButtonExecute.Name = "ButtonExecute";
			this.ButtonExecute.Size = new System.Drawing.Size(87, 27);
			this.ButtonExecute.TabIndex = 1;
			this.ButtonExecute.Text = "&Execute";
			this.ButtonExecute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonExecute.UseVisualStyleBackColor = true;
			this.ButtonExecute.Click += new System.EventHandler(this.ButtonExecuteClick);
			// 
			// ButtonLoad
			// 
			this.ButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("ButtonLoad.Image")));
			this.ButtonLoad.Location = new System.Drawing.Point(3, 38);
			this.ButtonLoad.Name = "ButtonLoad";
			this.ButtonLoad.Size = new System.Drawing.Size(87, 27);
			this.ButtonLoad.TabIndex = 0;
			this.ButtonLoad.Text = "&Load";
			this.ButtonLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonLoad.UseVisualStyleBackColor = true;
			this.ButtonLoad.Click += new System.EventHandler(this.ButtonLoadClick);
			// 
			// ButtonSave
			// 
			this.ButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSave.Image")));
			this.ButtonSave.Location = new System.Drawing.Point(3, 5);
			this.ButtonSave.Name = "ButtonSave";
			this.ButtonSave.Size = new System.Drawing.Size(87, 27);
			this.ButtonSave.TabIndex = 2;
			this.ButtonSave.Text = "&Save";
			this.ButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonSave.UseVisualStyleBackColor = true;
			this.ButtonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dataGridViewResult);
			this.groupBox1.Controls.Add(this.statusStrip1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(453, 268);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Result";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel1,
									this.LabelLinesNumber});
			this.statusStrip1.Location = new System.Drawing.Point(3, 243);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(447, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
			this.toolStripStatusLabel1.Text = "Lines count :";
			// 
			// LabelLinesNumber
			// 
			this.LabelLinesNumber.Name = "LabelLinesNumber";
			this.LabelLinesNumber.Size = new System.Drawing.Size(13, 17);
			this.LabelLinesNumber.Text = "0";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// ExecQueryForm
			// 
			this.AcceptButton = this.ButtonExecute;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(453, 398);
			this.Controls.Add(this.splitContainer1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(461, 425);
			this.Name = "ExecQueryForm";
			this.ShowInTaskbar = false;
			this.Text = "SQL Query";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExecQueryFormFormClosed);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button ButtonExecute;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripStatusLabel LabelLinesNumber;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button ButtonSave;
		private System.Windows.Forms.Button ButtonLoad;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.RichTextBox TextBoxSqlQuery;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dataGridViewResult;
	}
}
