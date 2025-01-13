//
// User: Ludovic Germain
// Date: 29/07/2007
// Time: 09:29
//

using System;
using System.IO;
using System.Xml.Serialization;

namespace LuGe.Common
{
    /// <summary>
    /// This class provides methods to serialize/deserialize any object
    /// in/from a xml file.
    /// </summary>
    public class LISerialization<T>
    {
	    #region Fields

	    private T _value;

	    #endregion

	    #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LISerialization&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="value">An instance of the objet.</param>
        /// <remarks>An instance of the object must be passed even for deserializing
        /// to recover the specific type of the object.</remarks>
	    public LISerialization(T value)
	    {
            if (value == null) throw new ArgumentNullException("value");

		    _value = value;
	    }

	    #endregion

	    #region Properties

        /// <summary>
        /// Gets the objet.
        /// </summary>
        /// <value>The objet.</value>
	    public T Value {
		    get { return _value; }
	    }

	    #endregion

	    #region Methods

	    /// <summary>
        /// Serialize the object in a xml file.
	    /// </summary>
	    /// <param name="fileName">Xml file name.</param>
	    /// <remarks>
	    /// Raise a exception if the file already exists !
	    /// </remarks>
	    public void Serialize(string fileName)
	    {
		    if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException("fileName");
		    if (File.Exists(fileName)) File.Delete(fileName);

		    FileStream fs = new FileStream(fileName, FileMode.CreateNew);
		    XmlSerializer sf = new XmlSerializer(Value.GetType());

		    sf.Serialize(fs, Value);

		    fs.Close();
	    }

	    /// <summary>
        /// Deserialize an object from a xml file.
	    /// </summary>
	    /// <param name="fileName">Xml file name.</param>
	    /// <remarks>
        /// Raise a exception if the file doesn't exists !
        /// </remarks>
	    public void Deserialize(string fileName)
	    {
		    if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException("fileName");
		    if (!File.Exists(fileName)) throw new FileNotFoundException(fileName);

		    FileStream fs = new FileStream(fileName, FileMode.Open);
		    XmlSerializer sf = new XmlSerializer(Value.GetType());

		    _value = (T)sf.Deserialize(fs);

		    fs.Close();
	    }

	    #endregion
    }
}
