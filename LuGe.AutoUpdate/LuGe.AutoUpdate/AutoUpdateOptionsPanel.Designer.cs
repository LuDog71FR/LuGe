/*
 * User: lgermain
 * Date: 14/10/2008 08:54
 */

namespace LuGe.AutoUpdate
{
	partial class AutoUpdateOptionsPanel
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButtonDownload = new System.Windows.Forms.RadioButton();
			this.radioButtonAsk = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBoxProduct = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBoxDisplayChanges = new System.Windows.Forms.CheckBox();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonDownload);
			this.groupBox1.Controls.Add(this.radioButtonAsk);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(3, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(288, 81);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			// 
			// radioButtonDownload
			// 
			this.radioButtonDownload.AutoSize = true;
			this.radioButtonDownload.Checked = true;
			this.radioButtonDownload.Location = new System.Drawing.Point(32, 55);
			this.radioButtonDownload.Name = "radioButtonDownload";
			this.radioButtonDownload.Size = new System.Drawing.Size(243, 17);
			this.radioButtonDownload.TabIndex = 14;
			this.radioButtonDownload.TabStop = true;
			this.radioButtonDownload.Text = "Automatically download and install the update.";
			this.radioButtonDownload.UseVisualStyleBackColor = true;
			// 
			// radioButtonAsk
			// 
			this.radioButtonAsk.AutoSize = true;
			this.radioButtonAsk.Location = new System.Drawing.Point(32, 32);
			this.radioButtonAsk.Name = "radioButtonAsk";
			this.radioButtonAsk.Size = new System.Drawing.Size(148, 17);
			this.radioButtonAsk.TabIndex = 13;
			this.radioButtonAsk.Text = "Ask me what I want to do.";
			this.radioButtonAsk.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(154, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "When new updates are found :";
			// 
			// checkBoxProduct
			// 
			this.checkBoxProduct.Checked = true;
			this.checkBoxProduct.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxProduct.Location = new System.Drawing.Point(35, 26);
			this.checkBoxProduct.Name = "checkBoxProduct";
			this.checkBoxProduct.Size = new System.Drawing.Size(286, 24);
			this.checkBoxProduct.TabIndex = 17;
			this.checkBoxProduct.Text = "< Product name >";
			this.checkBoxProduct.UseVisualStyleBackColor = true;
			this.checkBoxProduct.CheckedChanged += new System.EventHandler(this.CheckBoxProductCheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Automatically check for updates to :";
			// 
			// checkBoxDisplayChanges
			// 
			this.checkBoxDisplayChanges.Checked = true;
			this.checkBoxDisplayChanges.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxDisplayChanges.Location = new System.Drawing.Point(33, 192);
			this.checkBoxDisplayChanges.Name = "checkBoxDisplayChanges";
			this.checkBoxDisplayChanges.Size = new System.Drawing.Size(243, 36);
			this.checkBoxDisplayChanges.TabIndex = 20;
			this.checkBoxDisplayChanges.Text = "Display the changes made to the application after updating.";
			this.checkBoxDisplayChanges.UseVisualStyleBackColor = true;
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Location = new System.Drawing.Point(33, 166);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.Size = new System.Drawing.Size(288, 20);
			this.textBoxUrl.TabIndex = 19;
			this.textBoxUrl.Text = "http://mcn0337:8080/updates/";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 150);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(158, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "URL where updates are stored :";
			// 
			// AutoUpdateOptionsPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBoxDisplayChanges);
			this.Controls.Add(this.textBoxUrl);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.checkBoxProduct);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Name = "AutoUpdateOptionsPanel";
			this.Size = new System.Drawing.Size(328, 234);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox checkBoxDisplayChanges;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBoxProduct;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton radioButtonAsk;
		private System.Windows.Forms.RadioButton radioButtonDownload;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxUrl;
	}
}
