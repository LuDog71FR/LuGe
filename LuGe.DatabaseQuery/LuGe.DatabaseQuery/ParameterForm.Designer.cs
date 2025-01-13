/*
 * User: lgermain
 * Date: 26/06/2008 10:13
 */
namespace LuGe.DatabaseQuery
{
	partial class ParameterForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterForm));
			this.ComboBoxType = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TextBoxValue = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TextBoxName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ButtonOk = new System.Windows.Forms.Button();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ComboBoxType
			// 
			this.ComboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxType.FormattingEnabled = true;
			this.ComboBoxType.Items.AddRange(new object[] {
									"String",
									"Double",
									"Integer"});
			this.ComboBoxType.Location = new System.Drawing.Point(96, 71);
			this.ComboBoxType.Name = "ComboBoxType";
			this.ComboBoxType.Size = new System.Drawing.Size(100, 21);
			this.ComboBoxType.TabIndex = 6;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ComboBoxType);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.TextBoxValue);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.TextBoxName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(2, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(266, 108);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Type :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TextBoxValue
			// 
			this.TextBoxValue.Location = new System.Drawing.Point(96, 45);
			this.TextBoxValue.Name = "TextBoxValue";
			this.TextBoxValue.Size = new System.Drawing.Size(153, 20);
			this.TextBoxValue.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Value :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TextBoxName
			// 
			this.TextBoxName.Location = new System.Drawing.Point(96, 19);
			this.TextBoxName.Name = "TextBoxName";
			this.TextBoxName.ReadOnly = true;
			this.TextBoxName.Size = new System.Drawing.Size(153, 20);
			this.TextBoxName.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Parameter :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ButtonOk
			// 
			this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ButtonOk.Image = ((System.Drawing.Image)(resources.GetObject("ButtonOk.Image")));
			this.ButtonOk.Location = new System.Drawing.Point(175, 116);
			this.ButtonOk.Name = "ButtonOk";
			this.ButtonOk.Size = new System.Drawing.Size(76, 27);
			this.ButtonOk.TabIndex = 4;
			this.ButtonOk.Text = "&Ok";
			this.ButtonOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonOk.UseVisualStyleBackColor = true;
			this.ButtonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("ButtonCancel.Image")));
			this.ButtonCancel.Location = new System.Drawing.Point(93, 116);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(76, 27);
			this.ButtonCancel.TabIndex = 5;
			this.ButtonCancel.Text = "&Cacel";
			this.ButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// ParameterForm
			// 
			this.AcceptButton = this.ButtonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ButtonCancel;
			this.ClientSize = new System.Drawing.Size(272, 148);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ButtonOk);
			this.Controls.Add(this.ButtonCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ParameterForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Parameter ...";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Button ButtonOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TextBoxName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TextBoxValue;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox ComboBoxType;
	}
}
