/*
 * User: lgermain
 * Date: 25/06/2008 10:32
 */

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.ComponentModel;

namespace LuGe.Common.Forms
{
	/// <summary>
	/// Form for displaying informations about the application.
	/// </summary>
	public partial class AboutForm : Form
	{
		#region Fields

		private Assembly _assembly;
		
		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of the class.
		/// </summary>
		public AboutForm()
		{
			InitializeComponent();
			
			LoadAssemblyInfo();
			LoadReferenceInfo();
		}

		#endregion

		#region Properties

		#endregion

		#region Methods
		
		/// <summary>
		/// Load and display the assembly informations.
		/// </summary>
		private void LoadAssemblyInfo()
		{
			_assembly = Assembly.GetEntryAssembly();
			Type[] types = _assembly.GetTypes();
			
			titleLabel.Text = SplashForm.AppTitle;
			versionLabel.Text = Application.ProductVersion.ToString();
		    authorLabel.Text = Application.CompanyName;
			                 
		    object[] attributes = _assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
		    copyrightLabel.Text = (attributes.Length == 0) ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright; 
			
			Icon appIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			pictureBoxIcon.Image = appIcon.ToBitmap();
		}
		
		/// <summary>
		/// Load and display the informations of all assembly references.
		/// </summary>
		private void LoadReferenceInfo()
		{
			DataTable table = new DataTable("ParentTable");
			table.Columns.Add("Name");
			table.Columns.Add("Version");
			table.Columns.Add("Path");
			
			foreach(AssemblyName reference in _assembly.GetReferencedAssemblies())
			{
				table.Rows.Add(new object[] {
				               	reference.Name,
				               	reference.Version.ToString(),
				               	Assembly.Load(reference).Location
				               });
			}
			
			dataGridView1.DataSource = table;
			dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
		}
		
		/// <summary>
		/// Raised when the close button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void CloseButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		/// <summary>
		/// Raised when the close button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ChangeLogButtonClick(object sender, EventArgs e)
		{
			ChangeLogForm form = new ChangeLogForm();
			form.ShowDialog();
		}
		
		#endregion
	}
}
