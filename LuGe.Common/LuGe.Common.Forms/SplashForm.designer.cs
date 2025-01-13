//-----------------------------------------------------------------------
// <copyright file="SplashForm.cs" company="Itron">
// Copyright (c) 2009 All Right Reserved
// </copyright>
// <author>Ludovic GERMAIN</author>
// <email>ludovic.germain@actaris.itron.com</email>
// <date>19/03/2010</date>
// <summary>This file contains the SplashForm class.</summary>
//-----------------------------------------------------------------------

namespace LuGe.Common.Forms
{
    partial class SplashForm
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
                if (this.components != null) {
                    this.components.Dispose();
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
        	this.labVersion = new System.Windows.Forms.Label();
        	this.progressBar1 = new System.Windows.Forms.ProgressBar();
        	this.labMessage = new System.Windows.Forms.Label();
        	this.labAppName = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// labVersion
        	// 
        	this.labVersion.BackColor = System.Drawing.Color.Transparent;
        	this.labVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.labVersion.Location = new System.Drawing.Point(505, 55);
        	this.labVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.labVersion.Name = "labVersion";
        	this.labVersion.Size = new System.Drawing.Size(241, 30);
        	this.labVersion.TabIndex = 0;
        	this.labVersion.Text = "Version 1.0  Alpha 1";
        	this.labVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// progressBar1
        	// 
        	this.progressBar1.Location = new System.Drawing.Point(79, 399);
        	this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        	this.progressBar1.Name = "progressBar1";
        	this.progressBar1.Size = new System.Drawing.Size(264, 22);
        	this.progressBar1.TabIndex = 1;
        	// 
        	// labMessage
        	// 
        	this.labMessage.BackColor = System.Drawing.Color.Transparent;
        	this.labMessage.Location = new System.Drawing.Point(79, 425);
        	this.labMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.labMessage.Name = "labMessage";
        	this.labMessage.Size = new System.Drawing.Size(264, 18);
        	this.labMessage.TabIndex = 2;
        	this.labMessage.Text = "Loading ...";
        	// 
        	// labAppName
        	// 
        	this.labAppName.BackColor = System.Drawing.Color.Transparent;
        	this.labAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.labAppName.Location = new System.Drawing.Point(36, 55);
        	this.labAppName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.labAppName.Name = "labAppName";
        	this.labAppName.Size = new System.Drawing.Size(403, 30);
        	this.labAppName.TabIndex = 3;
        	this.labAppName.Text = "Application Name";
        	this.labAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// SplashForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
        	this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        	this.ClientSize = new System.Drawing.Size(784, 470);
        	this.Controls.Add(this.labAppName);
        	this.Controls.Add(this.labMessage);
        	this.Controls.Add(this.progressBar1);
        	this.Controls.Add(this.labVersion);
        	this.DoubleBuffered = true;
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        	this.Name = "SplashForm";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "SplashForm";
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Label labVersion;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labAppName;
    }
}
