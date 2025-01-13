/*
 * User: lgermain
 * Date: 09/10/2008 15:26
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace LuGe.Common.Forms
{
	/// <summary>
	/// Waiting form.
	/// </summary>
	public partial class WaitForm : Form
	{
	
		#region Delegates
		
		private delegate void SetMsgDelegate(string message);
		
		#endregion
		
		#region Events
		
		/// <summary>
		/// Event raised when the user click on the "cancel" button.
		/// </summary>
		public event CancelEventHandler Canceled;
		
		#endregion
		
		#region Fields
		
		#endregion

		#region Constructors
		
		/// <summary>
		/// Creates a new instance of the class.
		/// </summary>
		public WaitForm()
		{
			InitializeComponent();
			ResizeTheForm();
		}
		
		#endregion

		#region Properties
		
		/// <summary>
		/// Gets or sets a value indicating if the "Cancel" button is avaible.
		/// </summary>
		public bool AllowCancel
		{
			get { return buttonCancel.Enabled; }
			set
			{
				buttonCancel.Enabled = value;
				ResizeTheForm();
			}
		}
		
		/// <summary>
		/// Gets or sets the title of the waiting form.
		/// </summary>
		public string Title
		{
			get { return this.Text; }
			set { this.Text = value; }
		}

		/// <summary>
		/// Gets or sets the message displayed for the end-user.
		/// </summary>
		/// <remarks>The setter is thread-safe.</remarks>
		public string Message
		{
			get { return label1.Text; }
			set 
			{
				if (this.InvokeRequired)
				{
					this.Invoke(new SetMsgDelegate(SetMessage), new object[] {value});
				}
				else
				{
					SetMessage(value);
				}				
			}
		}
		
		/// <summary>
		/// Gets or sets the maximum value of the progress bar.
		/// </summary>
		public int Maximum
		{
			get { return progressBar1.Maximum; }
			set { progressBar1.Maximum = value; }
		}
		
		/// <summary>
		/// Gets or sets the current value of the progress bar.
		/// </summary>
		public int Value
		{
			get { return progressBar1.Value; }
			set
			{
				if (progressBar1.Value == progressBar1.Maximum) progressBar1.Value = 0;
				else progressBar1.Value = value;
			}
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Sets the message of information for the end-user.
		/// </summary>
		/// <param name="message">Message.</param>
		private void SetMessage(string message)
		{
			label1.Text = message;
		}
		
		/// <summary>
		/// Resize the form according to the state of the cancel button.
		/// </summary>
		private void ResizeTheForm()
		{
			if (buttonCancel.Enabled) 
			{
				this.Height = 158;
				groupBox1.Height = 127;
			}
			else 
			{
				this.Height = 121;
				groupBox1.Height = 91;
			}
		}
		
		/// <summary>
		/// Raised when the "Cancel" button is clicked.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/>
		/// instance containing the event data.</param>
		private void ButtonCancelClick(object sender, EventArgs e)
		{
			buttonCancel.Enabled = false;
			
			if (Canceled != null)
			{
				Canceled(sender, new CancelEventArgs(true));
			}
		}
		
		#endregion

	}
}
