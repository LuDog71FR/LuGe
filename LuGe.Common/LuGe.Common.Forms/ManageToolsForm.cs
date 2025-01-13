/*
 * User: lgermain
 * Date: 04/08/2008 09:43
 */

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace Actaris.Quality.Common.Forms
{
	/// <summary>
	/// Form to manage the external tools of an application.
	/// </summary>
	public partial class ManageToolsForm : Form
	{

		#region Enums
		
		/// <summary>
		/// Enumeration to use with the MoveTool function. It identifes
		/// the direction available : up or down.
		/// </summary>
		private enum MoveDirection
		{
			Up,
			Down
		}

		#endregion

		#region Fields

		private bool _isNew; // Value indicating if the current tool is a new one.
		private Configuration _config; // The Configuration file of the application.
		private ToolsSection _section; // The Tools section of the configuration file.
		
		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public ManageToolsForm()
		{
			InitializeComponent();
			InitSection();
		}

		#endregion

		#region Properties

		#endregion

		#region Methods
		
		/// <summary>
		/// Initialize the configuration and section objects used.
		/// </summary>
		private void InitSection()
		{
			_config = ConfigurationManager.OpenExeConfiguration(
				ConfigurationUserLevel.None);
			_section = (ToolsSection)_config.GetSection(
				ToolsSection.SectionName);
		}
		
		/// <summary>
		/// Clear all values entered by the user.
		/// </summary>
		private void ClearData()
		{
			errorProvider1.Clear();
			
			labelPosition.Text = "n° 0";
			pictureBoxIcon.Image = null;
			textboxTitle.Text = string.Empty;
			fileNamePickerCommand.Text = string.Empty;
			textboxArguments.Text = string.Empty;
			directoryNamePickerWorkDir.Text = string.Empty;
		}
		
		/// <summary>
		/// Display the tool in the "Details" panel.
		/// </summary>
		/// <param name="tool">Tool to display.</param>
		private void ShowData(ToolInfoElement tool)
		{
			if (tool == null) return;
			
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
			if (File.Exists(tool.Command))
			{
				Icon toolIcon = Icon.ExtractAssociatedIcon(tool.Command);
				pictureBoxIcon.Image = toolIcon.ToBitmap();
			}
			
			labelPosition.Text = "n° " + tool.Position.ToString();
			textboxTitle.Text = tool.Title;
			fileNamePickerCommand.Text = tool.Command;
			textboxArguments.Text = tool.Arguments;
			directoryNamePickerWorkDir.Text = tool.WorkingDirectory;
		}
		
		/// <summary>
		/// Refresh the list of tools.
		/// </summary>
		private void RefreshTools()
		{
			listBoxTools.Items.Clear();
			
			foreach(ToolInfoElement tool in _section.List.Sort())
			{
				listBoxTools.Items.Add(tool);
			}
		}
		
		/// <summary>
		/// Raised when the form is loaded.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ManageToolsFormLoad(object sender, EventArgs e)
		{
			RefreshTools();
		}
		
		/// <summary>
		/// Raised when selected index of the tools list changed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ListBoxToolsSelectedIndexChanged(object sender, EventArgs e)
		{
			ClearData();
			if (listBoxTools.SelectedItem == null) return;
			ShowData((ToolInfoElement)listBoxTools.SelectedItem);
		}
		
		/// <summary>
		/// Move a tool in the list up or down.
		/// </summary>
		/// <param name="direction">Direction up or down.</param>
		private void MoveTool(MoveDirection direction)
		{
			if (listBoxTools.SelectedItem == null) return;
			
			short delta;
			if (direction == MoveDirection.Up) delta = -1;
			else delta = 1;
			
			ToolInfoElement tool = (ToolInfoElement)listBoxTools.SelectedItem;
			if (tool.Position + delta < 1) return;
			if (tool.Position + delta > _section.List.Count) return;
			
			tool.Position += delta;
			
			listBoxTools.Items.Remove(tool);
			listBoxTools.Items.Insert(tool.Position - 1, tool);
			listBoxTools.SelectedItem = tool;
		}
		
		/// <summary>
		/// Raised when the up button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonUpClick(object sender, EventArgs e)
		{
			MoveTool(MoveDirection.Up);
		}
		
		/// <summary>
		/// Raised when the down button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonDownClick(object sender, EventArgs e)
		{
			MoveTool(MoveDirection.Down);
		}
		
		/// <summary>
		/// Raised when the delete button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (listBoxTools.SelectedItem == null) return;
			
			ToolInfoElement tool = (ToolInfoElement)listBoxTools.SelectedItem;
			
			_section.List.Remove(tool);
			listBoxTools.Items.Remove(tool);
			ClearData();
		}
		
		/// <summary>
		/// Save the values entered by the user to the specified tool.
		/// </summary>
		/// <param name="tool">The tool where to save.</param>
		private void SaveToTool(ToolInfoElement tool)
		{
			tool.Title = textboxTitle.Text.Trim();
			tool.Command = fileNamePickerCommand.Text.Trim();
			tool.Arguments = textboxArguments.Text.Trim();
			tool.WorkingDirectory = directoryNamePickerWorkDir.Text.Trim();
		}
		
		/// <summary>
		/// Raised when the add button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonAddClick(object sender, EventArgs e)
		{
			_isNew = true;
			if (ValidateChildren() == false) return;
			
			ToolInfoElement tool = new ToolInfoElement();
			tool.Position = _section.List.Count + 1;
			SaveToTool(tool);
			
			_section.List.Add(tool);
			listBoxTools.Items.Add(tool);
			listBoxTools.SelectedItem = tool;
		}
		
		/// <summary>
		/// Raised when the edit button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonEditClick(object sender, EventArgs e)
		{
			if (listBoxTools.SelectedItem == null) return;
			_isNew = false;
			if (ValidateChildren() == false) return;
			
			ToolInfoElement tool = (ToolInfoElement)listBoxTools.SelectedItem;
			SaveToTool(tool);
			
			listBoxTools.Items.Remove(tool);
			listBoxTools.Items.Insert(tool.Position-1, tool);
			listBoxTools.SelectedItem = tool;
		}
		
		/// <summary>
		/// Raised when the new button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		void ButtonNewClick(object sender, EventArgs e)
		{
			listBoxTools.SelectedIndex = -1;
			ClearData();
		}
		
		/// <summary>
		/// Raised when the cancel button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		/// <summary>
		/// Raised when the save button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonSaveClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			_config.Save();
			
			this.Close();
		}
		
		/// <summary>
		/// Raised when the reload button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonReloadClick(object sender, EventArgs e)
		{
			InitSection();
			RefreshTools();
		}
		
		/// <summary>
		/// Raised when the title is validating.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void TextboxTitleValidating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(textboxTitle.Text.Trim()))
			{
				textboxTitle.Focus();
				errorProvider1.SetError(textboxTitle,
				                        "A title is required !");
				e.Cancel = true;
				return;
			}
			
			foreach(ToolInfoElement tool in listBoxTools.Items)
			{
				if (tool.Title != textboxTitle.Text.Trim()) continue;
				
				if ((_isNew) || (tool != listBoxTools.SelectedItem))
				{
					textboxTitle.Focus();
					errorProvider1.SetError(textboxTitle,
					                        "This title still exists !");
					e.Cancel = true;
					return;
				}				
			}
		}
		
		/// <summary>
		/// Raised when the title is validated.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void TextboxTitleValidated(object sender, EventArgs e)
		{
			errorProvider1.SetError(textboxTitle, string.Empty);
		}
		
		/// <summary>
		/// Raised when the command is validating.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void FileNamePickerCommandValidating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(fileNamePickerCommand.Text.Trim()))
			{
				fileNamePickerCommand.Focus();
				errorProvider1.SetError(fileNamePickerCommand,
				                        "A command is required !");
				e.Cancel = true;
				return;
			}
			
			if (File.Exists(fileNamePickerCommand.Text.Trim()) == false)
			{
				fileNamePickerCommand.Focus();
				errorProvider1.SetError(fileNamePickerCommand,
				                        "The command don't exists !");
				e.Cancel = true;
				return;
			}
		}
		
		/// <summary>
		/// Raised when the command is validated.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void FileNamePickerCommandValidated(object sender, EventArgs e)
		{
			errorProvider1.SetError(fileNamePickerCommand, string.Empty);
		}
		
		/// <summary>
		/// Raised when the "working directory" is validating.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void DirectoryNamePickerWorkDirValidating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(directoryNamePickerWorkDir.Text.Trim())) return;
			
			if (Directory.Exists(directoryNamePickerWorkDir.Text.Trim()) == false)
			{
				directoryNamePickerWorkDir.Focus();
				errorProvider1.SetError(directoryNamePickerWorkDir,
				                        "The working directory don't exists !");
				e.Cancel = true;
				return;
			}
		}
		
		/// <summary>
		/// Raised when the "working directory" is validated.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void DirectoryNamePickerWorkDirValidated(object sender, EventArgs e)
		{
			errorProvider1.SetError(directoryNamePickerWorkDir, string.Empty);
		}
		
		#endregion
		
	}
}
