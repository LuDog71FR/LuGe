/*
 * User: Ludovic Germain
 * Date: 13/07/2007
 * Time: 14:48
 */

using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LuGe.Common
{
	/// <summary>
	/// This class provides a set of static methods that
	/// manipulate xml file.
	/// </summary>
	public sealed class LIXmlHelper
	{
		#region Fields
		
		private static bool _validateFlag; // value indicating the status of the validation.
		private static List<string> _errors; // list of errors that occurs during the validation.
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Private constructor for the LILog class,
		/// because the type only declares static members.
		/// </summary>
		private LIXmlHelper() {}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Gets the list of errors that occurs during the validation.
		/// </summary>
		public static ReadOnlyCollection<string> Errors
		{
			get { return _errors.AsReadOnly(); }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Validates the xml file specified.
		/// </summary>
		/// <param name="xmlFileName">XML file to validate.</param>
		/// <returns>Return True if the xml file is valid.</returns>
		public static bool Validate(string xmlFileName)
		{
			_validateFlag = true;
			_errors = new List<string>();

			XmlDocument document = new XmlDocument();
			
			try
			{
				document.Load(xmlFileName);
			}
			catch (System.Xml.XmlException ex)
			{
				_validateFlag = false;
				_errors.Add(ex.ToString());
			}

			return _validateFlag;
		}
		
		/// <summary>
		/// Validates the xml string specified.
		/// </summary>
		/// <param name="xmlText">XML string to validate.</param>
		/// <returns>Return True if the xml string is valid.</returns>
		public static bool ValidateString(string xmlText)
		{
			_validateFlag = true;
			_errors = new List<string>();

			XmlDocument document = new XmlDocument();
			
			try
			{
				document.LoadXml(xmlText);
			}
			catch (System.Xml.XmlException ex)
			{
				_validateFlag = false;
				_errors.Add(ex.ToString());
			}

			return _validateFlag;
		}
		
		/// <summary>
		/// Validates the xml file specified with the xml schema file
		/// specified.
		/// </summary>
		/// <param name="xmlFileName">XML file to validate.</param>
		/// <param name="schemaFileName">Schema to use
		/// for validation the XML file.</param>
		/// <returns>Return True if the xml file is valid.</returns>
		public static bool Validate(string xmlFileName,
		                            string schemaFileName)
		{
			_validateFlag = true;
			_errors = new List<string>();

			XmlDocument document = new XmlDocument();
			
			try
			{
				document.Load(xmlFileName);

				XmlSchemaSet schemas = new XmlSchemaSet();
				schemas.Add(null, schemaFileName);
				document.Schemas = schemas;

				ValidationEventHandler eventHandler =
					new ValidationEventHandler(ValidateEventHandler);

				document.Validate(eventHandler);
			}
			catch (System.Xml.XmlException ex)
			{
				_validateFlag = false;
				_errors.Add(ex.ToString());
			}

			return _validateFlag;
		}

		/// <summary>
		/// Event raised when the validation failed.
		/// </summary>
		/// <param name="sender">Object sender.</param>
		/// <param name="args">Event arguments.</param>
		private static void ValidateEventHandler(object sender,
		                                         ValidationEventArgs args)
		{
			_validateFlag = false;
			_errors.Add(args.Message);
		}

		/// <summary>
		/// Infer a xml schema file from a xml file.
		/// </summary>
		/// <param name="xmlFileName">XML source file.</param>
		/// <param name="schemaFileName">Schema file to create.</param>
		public static void Infer(string xmlFileName,
		                         string schemaFileName)
		{
			using(XmlTextReader r = new XmlTextReader(xmlFileName))
			{
				XmlSchemaInference infererence = new XmlSchemaInference();
				XmlSchemaSet sc = infererence.InferSchema(r);

				using(XmlWriter w = XmlWriter.Create(new StreamWriter(schemaFileName)))
				{
					foreach (XmlSchema schema in sc.Schemas()) schema.Write(w);
					
					w.Close();
				}
				
				r.Close();
			}
		}

		/// <summary>
		/// Executes the transform using the input document specified
		/// and outputs the results to a file. The transform is applied
		/// from the style sheet specified.
		/// </summary>
		/// <param name="xmlFileName">The URI of the input document.</param>
		/// <param name="resultFileName">The URI of the output file.</param>
		/// <param name="xslFileName">The URI of the style sheet.</param>
		public static void Transform(string xmlFileName,
		                             string resultFileName,
		                             string xslFileName)
		{
			XslCompiledTransform xslProc = new XslCompiledTransform();

			xslProc.Load(xslFileName);
			xslProc.Transform(xmlFileName, resultFileName);
		}
		
		/// <summary>
		/// Format the XML text specified.
		/// </summary>
		/// <param name="xmlText">The XML text to format.</param>
		/// <returns>The XML text formatted; otherwise <c>string.Empty</c>
		/// if XML text not valid.</returns>
		public static string FormatString(string xmlText)
		{
			if (LIXmlHelper.ValidateString(xmlText) == false) return string.Empty;
			
			XmlDocument document = new XmlDocument();
			document.LoadXml(xmlText);

			StringBuilder formattedText = new StringBuilder();
			StringWriter sw = new StringWriter(formattedText);

			XmlTextWriter xtw = null;
			xtw = new XmlTextWriter(sw);
			xtw.Formatting = Formatting.Indented;
			document.WriteTo(xtw);
			
			return formattedText.ToString();
		}
		
		#endregion
	}
}
