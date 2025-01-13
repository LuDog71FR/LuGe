/*
 * User: lgermain
 * Date: 04/09/2008 16:26
 */
namespace LuGe.DatabaseQuery
{
	partial class OptionsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
			this.buttonReload = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxUseTransac = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.autoUpdateOptionsPanel1 = new LuGe.AutoUpdate.AutoUpdateOptionsPanel();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.buttonReloadDefault = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonReload
			// 
			this.buttonReload.Image = ((System.Drawing.Image)(resources.GetObject("buttonReload.Image")));
			this.buttonReload.Location = new System.Drawing.Point(31, 270);
			this.buttonReload.Name = "buttonReload";
			this.buttonReload.Size = new System.Drawing.Size(75, 27);
			this.buttonReload.TabIndex = 3;
			this.buttonReload.Text = "&Reload";
			this.buttonReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonReload.UseVisualStyleBackColor = true;
			this.buttonReload.Click += new System.EventHandler(this.ButtonReloadClick);
			// 
			// buttonSave
			// 
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.Location = new System.Drawing.Point(226, 270);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 27);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "&Save";
			this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.Location = new System.Drawing.Point(131, 270);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 27);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(1, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(341, 261);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.checkBoxUseTransac);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(333, 235);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Connection";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(30, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(233, 45);
			this.label1.TabIndex = 4;
			this.label1.Text = "Warning ! If you are connected to a database, you must disconnect from it to have" +
			" the changes apply.";
			// 
			// checkBoxUseTransac
			// 
			this.checkBoxUseTransac.Location = new System.Drawing.Point(7, 6);
			this.checkBoxUseTransac.Name = "checkBoxUseTransac";
			this.checkBoxUseTransac.Size = new System.Drawing.Size(256, 40);
			this.checkBoxUseTransac.TabIndex = 3;
			this.checkBoxUseTransac.Text = "Use a global transaction to save or cancel the changes.";
			this.checkBoxUseTransac.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.autoUpdateOptionsPanel1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(333, 235);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Update";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// autoUpdateOptionsPanel1
			// 
			this.autoUpdateOptionsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.autoUpdateOptionsPanel1.Location = new System.Drawing.Point(3, 3);
			this.autoUpdateOptionsPanel1.Name = "autoUpdateOptionsPanel1";
			this.autoUpdateOptionsPanel1.Size = new System.Drawing.Size(327, 229);
			this.autoUpdateOptionsPanel1.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.buttonReloadDefault);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(333, 235);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Advanced";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// buttonReloadDefault
			// 
			this.buttonReloadDefault.Image = ((System.Drawing.Image)(resources.GetObject("buttonReloadDefault.Image")));
			this.buttonReloadDefault.Location = new System.Drawing.Point(101, 88);
			this.buttonReloadDefault.Name = "buttonReloadDefault";
			this.buttonReloadDefault.Size = new System.Drawing.Size(117, 39);
			this.buttonReloadDefault.TabIndex = 0;
			this.buttonReloadDefault.Text = "Reload all default settings";
			this.buttonReloadDefault.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonReloadDefault.UseVisualStyleBackColor = true;
			this.buttonReloadDefault.Click += new System.EventHandler(this.ButtonReloadDefaultClick);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(41, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(265, 45);
			this.label2.TabIndex = 1;
			this.label2.Text = "If you click on the button below you will lose all your settings including all co" +
			"nnections configuration.";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(26, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Warning ! ";
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.buttonSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(346, 302);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.buttonReload);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options ...";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button buttonReloadDefault;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabPage3;
		private LuGe.AutoUpdate.AutoUpdateOptionsPanel autoUpdateOptionsPanel1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxUseTransac;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonReload;
	}
}
