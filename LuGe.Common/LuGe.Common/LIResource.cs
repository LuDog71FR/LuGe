/*
 * User: Ludovic Germain
 * Date: 09/01/2008 16:43:21
 */

using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Reflection;

namespace LuGe.Common
{
    /// <summary>
    /// This class gives some static methods to easly extract embedded files.
    /// With these methods you can extract : image, string, xml or a stream from any embedded file.
    /// </summary>
    public sealed class LIResource
    {

        #region Fields

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LIResource"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is private because all methods of the class are static
        /// and the class is marked as sealed.
        /// </remarks>
        private LIResource()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods
        
        //-----------------------------------------------------------------------------
        #region File

        /// <summary>
        /// Saves the embedded file to the output file.
        /// </summary>
        /// <param name="assemblyName">The namespace of you assembly.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <param name="outputFileName">Name of the output file.</param>
        public static void SaveEmbeddedFile(string assemblyName, string fileName, string outputFileName)
        {
            LIStreamHelper.SaveStreamToFile(
                GetEmbeddedFile(assemblyName, fileName),
                outputFileName, 
                FileMode.CreateNew);
        }

        /// <summary>
        /// Saves the embedded file to the output file.
        /// </summary>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <param name="outputFileName">Name of the output file.</param>
        public static void SaveEmbeddedFile(string fileName, string outputFileName)
        {
            string assemblyName = Assembly.GetCallingAssembly().GetName().Name;

            LIStreamHelper.SaveStreamToFile(
                GetEmbeddedFile(assemblyName, fileName),
                outputFileName,
                FileMode.CreateNew);
        }

        /// <summary>
        /// Saves the embedded file to the output file.
        /// </summary>
        /// <param name="assembly">The assembly containing the resource.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <param name="outputFileName">Name of the output file.</param>
        public static void SaveEmbeddedFile(Assembly assembly, string fileName, string outputFileName)
        {
            LIStreamHelper.SaveStreamToFile(
                GetEmbeddedFile(assembly, fileName),
                outputFileName,
                FileMode.CreateNew);
        }

        /// <summary>
        /// Saves the embedded file to the output file.
        /// </summary>
        /// <param name="type">The type where we retreive the assembly in which it's declared.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <param name="outputFileName">Name of the output file.</param>
        public static void SaveEmbeddedFile(Type type, string fileName, string outputFileName)
        {
            LIStreamHelper.SaveStreamToFile(
                GetEmbeddedFile(type, fileName),
                outputFileName,
                FileMode.CreateNew);
        }

        #endregion

        //-----------------------------------------------------------------------------
        #region Stream

        /// <summary>
        /// Extracts an embedded file out of a given assembly.
        /// </summary>
        /// <param name="assemblyName">The namespace of you assembly.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A stream containing the file data.</returns>
        /// <remarks>
        /// This is the base method for all override methods from this class.
        /// </remarks>
        public static Stream GetEmbeddedFile(string assemblyName, string fileName)
        {
            if (string.IsNullOrEmpty(assemblyName)) throw new ArgumentNullException("assemblyName");
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException("fileName");

            Assembly a = Assembly.Load(assemblyName);
            Stream str = a.GetManifestResourceStream(assemblyName + "." + fileName);
            
            return str;
        }

        /// <summary>
        /// Extracts an embedded file out of the Assembly of the method 
        /// that invoked the currently executing method.
        /// </summary>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A stream containing the file data.</returns>
        public static Stream GetEmbeddedFile(string fileName)
        {
            string assemblyName = Assembly.GetCallingAssembly().GetName().Name;
            return GetEmbeddedFile(assemblyName, fileName);
        }

        /// <summary>
        /// Extracts an embedded file out of a given assembly.
        /// </summary>
        /// <param name="assembly">The assembly containing the resource.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A stream containing the file data.</returns>
        public static Stream GetEmbeddedFile(Assembly assembly, string fileName)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");

            string assemblyName = assembly.GetName().Name;
            return GetEmbeddedFile(assemblyName, fileName);
        }

        /// <summary>
        /// Extracts an embedded file out of an assembly declaring a given type.
        /// </summary>
        /// <param name="type">The type where we retreive the assembly in which it's declared.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A stream containing the file data.</returns>   
        public static Stream GetEmbeddedFile(Type type, string fileName)
        {
            if (type == null) throw new ArgumentNullException("type");

            string assemblyName = type.Assembly.GetName().Name;
            return GetEmbeddedFile(assemblyName, fileName);
        }

        #endregion

        //-----------------------------------------------------------------------------
        #region Image
        
        /// <summary>
        /// Extracts an embedded image file out of a given stream.
        /// </summary>
        /// <param name="str">The stream to extract.</param>
        /// <returns>A bitmap containing the data extract from the stream.</returns>
        private static Bitmap GetEmbeddedImage(Stream str)
        {
        	if (str == null) return null;
        	
            return new Bitmap(str);
        }

        /// <summary>
        /// Extracts an embedded image file out of a given assembly.
        /// </summary>
        /// <param name="assemblyName">The namespace of you assembly.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A bitmap containing the file data.</returns>
        public static Bitmap GetEmbeddedImage(string assemblyName, string fileName)
        {
            Stream str = GetEmbeddedFile(assemblyName, fileName);
            return GetEmbeddedImage(str);
        }

        /// <summary>
        /// Extracts an embedded image file out of the Assembly of the method 
        /// that invoked the currently executing method.
        /// </summary>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A bitmap containing the file data.</returns>
        public static Bitmap GetEmbeddedImage(string fileName)
        {
        	string assemblyName = Assembly.GetCallingAssembly().GetName().Name;
            Stream str = GetEmbeddedFile(assemblyName, fileName);
            
            return GetEmbeddedImage(str);
        }

        /// <summary>
        /// Extracts an embedded image file out of a given assembly.
        /// </summary>
        /// <param name="assembly">The assembly containing the resource.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A bitmap containing the file data.</returns>
        public static Bitmap GetEmbeddedImage(Assembly assembly, string fileName)
        {
            Stream str = GetEmbeddedFile(assembly, fileName);
            return GetEmbeddedImage(str);
        }

        /// <summary>
        /// Gets the embedded image file out of an assembly declaring a given type.
        /// </summary>
        /// <param name="type">The type where we retreive the assembly in which it's declared.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A bitmap containing the image file.</returns>
        public static Bitmap GetEmbeddedImage(Type type, string fileName)
        {
            Stream str = GetEmbeddedFile(type, fileName);
            return GetEmbeddedImage(str);
        }

        #endregion

        //-----------------------------------------------------------------------------
        #region XML

        /// <summary>
        /// Extracts an embedded xml file out of a given stream.
        /// </summary>
        /// <param name="str">The stream to extract.</param>
        /// <returns>An XmlDocument containing the data extract from the stream.</returns>
        private static XmlDocument GetEmbeddedXml(Stream str)
        {
        	if (str == null) return null;
        	
            XmlTextReader tr = new XmlTextReader(str);
            XmlDocument xml = new XmlDocument();
            xml.Load(tr);

            return xml;
        }

        /// <summary>
        /// Extracts an embedded xml file out of a given assembly.
        /// </summary>
        /// <param name="assemblyName">The namespace of you assembly.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>An XmlDocument containing the file data.</returns>
        public static XmlDocument GetEmbeddedXml(string assemblyName, string fileName)
        {
            Stream str = GetEmbeddedFile(assemblyName, fileName);
            return GetEmbeddedXml(str);
        }

        /// <summary>
        /// Extracts an embedded xml file out of the Assembly of the method 
        /// that invoked the currently executing method.
        /// </summary>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>An XmlDocument containing the file data.</returns>
        public static XmlDocument GetEmbeddedXml(string fileName)
        {
        	string assemblyName = Assembly.GetCallingAssembly().GetName().Name;
            Stream str = GetEmbeddedFile(assemblyName, fileName);
            
            return GetEmbeddedXml(str);
        }

        /// <summary>
        /// Extracts an embedded xml file out of a given assembly.
        /// </summary>
        /// <param name="assembly">The assembly containing the resource.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>An XmlDocument containing the file data.</returns>
        public static XmlDocument GetEmbeddedXml(Assembly assembly, string fileName)
        {
            Stream str = GetEmbeddedFile(assembly, fileName);
            return GetEmbeddedXml(str);
        }

        /// <summary>
        /// Gets the embedded xml file out of an assembly declaring a given type.
        /// </summary>
        /// <param name="type">The type where we retreive the assembly in which it's declared.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>An XmlDocument containing the image file.</returns>
        public static XmlDocument GetEmbeddedXml(Type type, string fileName)
        {
            Stream str = GetEmbeddedFile(type, fileName);
            return GetEmbeddedXml(str);
        }

        #endregion

        //-----------------------------------------------------------------------------
        #region String

        /// <summary>
        /// Extracts an embedded text file out of a given stream.
        /// </summary>
        /// <param name="str">The stream to extract.</param>
        /// <returns>A string containing the data extract from the stream.</returns>
        private static string GetEmbeddedString(Stream str)
        {
        	if (str == null) return string.Empty;
        	
            TextReader tr = new StreamReader(str);
            return tr.ReadToEnd();
        }

        /// <summary>
        /// Extracts an embedded text file out of a given assembly.
        /// </summary>
        /// <param name="assemblyName">The namespace of you assembly.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A string containing the file data.</returns>
        public static string GetEmbeddedString(string assemblyName, string fileName)
        {
            Stream str = GetEmbeddedFile(assemblyName, fileName);
            return GetEmbeddedString(str);
        }

        /// <summary>
        /// Extracts an embedded text file out of the Assembly of the method 
        /// that invoked the currently executing method.
        /// </summary>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A string containing the file data.</returns>
        public static string GetEmbeddedString(string fileName)
        {
        	string assemblyName = Assembly.GetCallingAssembly().GetName().Name;
            Stream str = GetEmbeddedFile(assemblyName, fileName);

            return GetEmbeddedString(str);
        }

        /// <summary>
        /// Extracts an embedded text file out of a given assembly.
        /// </summary>
        /// <param name="assembly">The assembly containing the resource.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A string containing the file data.</returns>
        public static string GetEmbeddedString(Assembly assembly, string fileName)
        {
            Stream str = GetEmbeddedFile(assembly, fileName);
            return GetEmbeddedString(str);
        }

        /// <summary>
        /// Gets the embedded text file out of an assembly declaring a given type.
        /// </summary>
        /// <param name="type">The type where we retreive the assembly in which it's declared.</param>
        /// <param name="fileName">The name of the file to extract.</param>
        /// <returns>A string containing the image file.</returns>
        public static string GetEmbeddedString(Type type, string fileName)
        {
            Stream str = GetEmbeddedFile(type, fileName);
            return GetEmbeddedString(str);
        }

        #endregion

        #endregion

    }
}
