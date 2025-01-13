/*
 * User: lgermain
 * Date: 10/09/2008 08:45
 */
namespace LuGe.Common.Forms
{
	partial class DirectoryNamePicker
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryNamePicker));
			this.buttonDir = new System.Windows.Forms.Button();
			this.textboxWithLabel1 = new LuGe.Common.Forms.TextboxWithLabel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonDir
			// 
			this.buttonDir.FlatAppearance.BorderSize = 0;
			this.buttonDir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLightLight;
			this.buttonDir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
			this.buttonDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDir.Image = ((System.Drawing.Image)(resources.GetObject("buttonDir.Image")));
			this.buttonDir.Location = new System.Drawing.Point(134, 0);
			this.buttonDir.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.buttonDir.Name = "buttonDir";
			this.buttonDir.Size = new System.Drawing.Size(21, 20);
			this.buttonDir.TabIndex = 2;
			this.buttonDir.TabStop = false;
			this.buttonDir.UseVisualStyleBackColor = true;
			this.buttonDir.Click += new System.EventHandler(this.ButtonDirClick);
			// 
			// textboxWithLabel1
			// 
			this.textboxWithLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textboxWithLabel1.LabelText = "label1 :";
			this.textboxWithLabel1.Location = new System.Drawing.Point(0, 0);
			this.textboxWithLabel1.Margin = new System.Windows.Forms.Padding(0);
			this.textboxWithLabel1.MaximumSize = new System.Drawing.Size(1000, 20);
			this.textboxWithLabel1.MaxLength = 32767;
			this.textboxWithLabel1.MinimumSize = new System.Drawing.Size(20, 20);
			this.textboxWithLabel1.Name = "textboxWithLabel1";
			this.textboxWithLabel1.Size = new System.Drawing.Size(131, 20);
			this.textboxWithLabel1.TabIndex = 3;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.Controls.Add(this.buttonDir, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.textboxWithLabel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(155, 20);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// DirectoryNamePicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximumSize = new System.Drawing.Size(10000, 20);
			this.MinimumSize = new System.Drawing.Size(40, 20);
			this.Name = "DirectoryNamePicker";
			this.Size = new System.Drawing.Size(155, 20);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private LuGe.Common.Forms.TextboxWithLabel textboxWithLabel1;
		private System.Windows.Forms.Button buttonDir;
	}
}
