using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace LuGe.Common.Forms
{
	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
	public class ToolStripDateTimePickerControl : ToolStripControlHost
	{
        private FlowLayoutPanel controlPanel;
        private DateTimePicker _picker;
        
        public DateTimePicker Picker { get { return _picker; } }
 		
        public ToolStripDateTimePickerControl()
            : base(new FlowLayoutPanel())
        {
        	_picker = new DateTimePicker();
        	_picker.Format = DateTimePickerFormat.Short;
        	_picker.Size = new Size(100, _picker.Size.Height);
        	
            // Set up the FlowLayouPanel.
            controlPanel = (FlowLayoutPanel)base.Control;
            controlPanel.BackColor = Color.Transparent;
 
            // Add two child controls.
            controlPanel.Controls.Add(_picker);
        }
 
        public DateTime Value
        {
            get { return _picker.Value; }
            set { _picker.Value = value; }
        }
 
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
        }
 
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
        }
 	}
}
