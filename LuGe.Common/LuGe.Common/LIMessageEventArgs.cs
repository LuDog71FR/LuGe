/*
 * User: Ludovic Germain
 * Date: 02/10/2007
 * Time: 10:54
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LuGe.Common
{
    /// <summary>
    /// This class contains event data for message event.
    /// </summary>
    public class LIMessageEventArgs: EventArgs
    {

        #region Fields

        private string _message;

		#endregion
		
		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LIMessageEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message pass to event handler.</param>
        public LIMessageEventArgs(string message)
        {
            _message = message;
        }

		#endregion
		
		#region Properties

        /// <summary>
        /// Gets the message pass to event handler.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get { return _message; }
        }

        #endregion
		
		#region Methods
		
		#endregion
		
    }
}
