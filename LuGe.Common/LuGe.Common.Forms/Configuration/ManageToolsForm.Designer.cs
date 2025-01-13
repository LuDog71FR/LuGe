/*
 * User: lgermain
 * Date: 04/08/2008 09:43
 */
namespace LuGe.Common.Forms.Configuration
{
	partial class ManageToolsForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageToolsForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.directoryNamePickerWorkDir = new LuGe.Common.Forms.DirectoryNamePicker();
			this.labelPosition = new System.Windows.Forms.Label();
			this.fileNamePickerCommand = new LuGe.Common.Forms.FileNamePicker();
			this.textboxArguments = new LuGe.Common.Forms.TextboxWithLabel();
			this.textboxTitle = new LuGe.Common.Forms.TextboxWithLabel();
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listBoxTools = new System.Windows.Forms.ListBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.buttonUp = new System.Windows.Forms.Button();
			this.buttonDown = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.buttonNew = new System.Windows.Forms.Button();
			this.buttonReload = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.directoryNamePickerWorkDir);
			this.groupBox1.Controls.Add(this.labelPosition);
			this.groupBox1.Controls.Add(this.fileNamePickerCommand);
			this.groupBox1.Controls.Add(this.textboxArguments);
			this.groupBox1.Controls.Add(this.textboxTitle);
			this.groupBox1.Controls.Add(this.pictureBoxIcon);
			this.groupBox1.Location = new System.Drawing.Point(3, 244);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(439, 133);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Details";
			// 
			// directoryNamePickerWorkDir
			// 
			this.directoryNamePickerWorkDir.Description = "Working directory of the command.";
			this.directoryNamePickerWorkDir.DirectoryName = "";
			this.directoryNamePickerWorkDir.LabelText = "Working directory :";
			this.directoryNamePickerWorkDir.Location = new System.Drawing.Point(21, 98);
			this.directoryNamePickerWorkDir.MaximumSize = new System.Drawing.Size(10000, 20);
			this.directoryNamePickerWorkDir.MinimumSize = new System.Drawing.Size(40, 20);
			this.directoryNamePickerWorkDir.Name = "directoryNamePickerWorkDir";
			this.directoryNamePickerWorkDir.Size = new System.Drawing.Size(389, 20);
			this.directoryNamePickerWorkDir.TabIndex = 21;
			this.directoryNamePickerWorkDir.Validated += new System.EventHandler(this.DirectoryNamePickerWorkDirValidated);
			this.directoryNamePickerWorkDir.Validating += new System.ComponentModel.CancelEventHandler(this.DirectoryNamePickerWorkDirValidating);
			// 
			// labelPosition
			// 
			this.labelPosition.Location = new System.Drawing.Point(387, 16);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new System.Drawing.Size(46, 23);
			this.labelPosition.TabIndex = 20;
			this.labelPosition.Text = "n° 0";
			this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// fileNamePickerCommand
			// 
			this.fileNamePickerCommand.FileName = "";
			this.fileNamePickerCommand.LabelText = "Command :";
			this.fileNamePickerCommand.Location = new System.Drawing.Point(57, 46);
			this.fileNamePickerCommand.MaximumSize = new System.Drawing.Size(10000, 20);
			this.fileNamePickerCommand.MinimumSize = new System.Drawing.Size(40, 20);
			this.fileNamePickerCommand.Name = "fileNamePickerCommand";
			this.fileNamePickerCommand.Size = new System.Drawing.Size(353, 20);
			this.fileNamePickerCommand.TabIndex = 1;
			this.fileNamePickerCommand.Validated += new System.EventHandler(this.FileNamePickerCommandValidated);
			this.fileNamePickerCommand.Validating += new System.ComponentModel.CancelEventHandler(this.FileNamePickerCommandValidating);
			// 
			// textboxArguments
			// 
			this.textboxArguments.LabelText = "Arguments :";
			this.textboxArguments.Location = new System.Drawing.Point(54, 72);
			this.textboxArguments.MaximumSize = new System.Drawing.Size(1000, 20);
			this.textboxArguments.MaxLength = 32767;
			this.textboxArguments.MinimumSize = new System.Drawing.Size(20, 20);
			this.textboxArguments.Name = "textboxArguments";
			this.textboxArguments.Size = new System.Drawing.Size(308, 20);
			this.textboxArguments.TabIndex = 2;
			// 
			// textboxTitle
			// 
			this.textboxTitle.LabelText = "Title :";
			this.textboxTitle.Location = new System.Drawing.Point(85, 19);
			this.textboxTitle.MaximumSize = new System.Drawing.Size(1000, 20);
			this.textboxTitle.MaxLength = 30;
			this.textboxTitle.MinimumSize = new System.Drawing.Size(20, 20);
			this.textboxTitle.Name = "textboxTitle";
			this.textboxTitle.Size = new System.Drawing.Size(228, 20);
			this.textboxTitle.TabIndex = 0;
			this.textboxTitle.Validated += new System.EventHandler(this.TextboxTitleValidated);
			this.textboxTitle.Validating += new System.ComponentModel.CancelEventHandler(this.TextboxTitleValidating);
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Location = new System.Drawing.Point(9, 19);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(37, 37);
			this.pictureBoxIcon.TabIndex = 14;
			this.pictureBoxIcon.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listBoxTools);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(392, 235);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "List";
			// 
			// listBoxTools
			// 
			this.listBoxTools.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxTools.FormattingEnabled = true;
			this.listBoxTools.Location = new System.Drawing.Point(3, 16);
			this.listBoxTools.Name = "listBoxTools";
			this.listBoxTools.Size = new System.Drawing.Size(386, 212);
			this.listBoxTools.TabIndex = 0;
			this.listBoxTools.SelectedIndexChanged += new System.EventHandler(this.ListBoxToolsSelectedIndexChanged);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
			this.buttonAdd.Location = new System.Drawing.Point(401, 162);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(40, 34);
			this.buttonAdd.TabIndex = 7;
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
			this.buttonDelete.Location = new System.Drawing.Point(401, 92);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(40, 34);
			this.buttonDelete.TabIndex = 5;
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// buttonEdit
			// 
			this.buttonEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonEdit.Image")));
			this.buttonEdit.Location = new System.Drawing.Point(401, 197);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(40, 34);
			this.buttonEdit.TabIndex = 8;
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
			// 
			// buttonUp
			// 
			this.buttonUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonUp.Image")));
			this.buttonUp.Location = new System.Drawing.Point(401, 12);
			this.buttonUp.Name = "buttonUp";
			this.buttonUp.Size = new System.Drawing.Size(40, 34);
			this.buttonUp.TabIndex = 3;
			this.buttonUp.UseVisualStyleBackColor = true;
			this.buttonUp.Click += new System.EventHandler(this.ButtonUpClick);
			// 
			// buttonDown
			// 
			this.buttonDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonDown.Image")));
			this.buttonDown.Location = new System.Drawing.Point(401, 47);
			this.buttonDown.Name = "buttonDown";
			this.buttonDown.Size = new System.Drawing.Size(40, 34);
			this.buttonDown.TabIndex = 4;
			this.buttonDown.UseVisualStyleBackColor = true;
			this.buttonDown.Click += new System.EventHandler(this.ButtonDownClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.Location = new System.Drawing.Point(190, 383);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 27);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonSave
			// 
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.Location = new System.Drawing.Point(285, 383);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 27);
			this.buttonSave.TabIndex = 2;
			this.buttonSave.Text = "&Save";
			this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// buttonNew
			// 
			this.buttonNew.Image = ((System.Drawing.Image)(resources.GetObject("buttonNew.Image")));
			this.buttonNew.Location = new System.Drawing.Point(401, 127);
			this.buttonNew.Name = "buttonNew";
			this.buttonNew.Size = new System.Drawing.Size(40, 34);
			this.buttonNew.TabIndex = 6;
			this.buttonNew.UseVisualStyleBackColor = true;
			this.buttonNew.Click += new System.EventHandler(this.ButtonNewClick);
			// 
			// buttonReload
			// 
			this.buttonReload.Image = ((System.Drawing.Image)(resources.GetObject("buttonReload.Image")));
			this.buttonReload.Location = new System.Drawing.Point(90, 383);
			this.buttonReload.Name = "buttonReload";
			this.buttonReload.Size = new System.Drawing.Size(75, 27);
			this.buttonReload.TabIndex = 0;
			this.buttonReload.Text = "&Reload";
			this.buttonReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonReload.UseVisualStyleBackColor = true;
			this.buttonReload.Click += new System.EventHandler(this.ButtonReloadClick);
			// 
			// ManageToolsForm
			// 
			this.AcceptButton = this.buttonSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(454, 414);
			this.Controls.Add(this.buttonReload);
			this.Controls.Add(this.buttonNew);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonDown);
			this.Controls.Add(this.buttonUp);
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ManageToolsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Manage Tools ...";
			this.Load += new System.EventHandler(this.ManageToolsFormLoad);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
		}
		private LuGe.Common.Forms.DirectoryNamePicker directoryNamePickerWorkDir;
		private System.Windows.Forms.Button buttonReload;
		private System.Windows.Forms.Button buttonNew;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Label labelPosition;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private LuGe.Common.Forms.FileNamePicker fileNamePickerCommand;
		private LuGe.Common.Forms.TextboxWithLabel textboxArguments;
		private LuGe.Common.Forms.TextboxWithLabel textboxTitle;
		private System.Windows.Forms.ListBox listBoxTools;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Button buttonUp;
		private System.Windows.Forms.Button buttonDown;
		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
