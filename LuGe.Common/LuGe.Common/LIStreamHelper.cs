/*
 * User: Ludovic Germain
 * Date: 21/01/2008 15:21:21
 */

using System;
using System.IO;

namespace LuGe.Common
{
	/// <summary>
	/// This class gives some static methods to easly manage streams.
	/// </summary>
	public sealed class LIStreamHelper
	{

		#region Fields

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LIStreamHelper"/> class.
		/// </summary>
		/// <remarks>
		/// This constructor is private because all methods of the class are static
		/// and the class is marked as sealed.
		/// </remarks>
		private LIStreamHelper()
		{
		}

		#endregion

		#region Properties

		#endregion

		#region Methods

		/// <summary>
		/// Save Streams to the specified file.
		/// </summary>
		/// <param name="inputStream">The input stream to save.</param>
		/// <param name="outputFile">The output file.</param>
		/// <param name="fileMode">The file mode.</param>
		public static void SaveStreamToFile(Stream inputStream, string outputFile, FileMode fileMode)
		{
			if (inputStream == null) throw new ArgumentNullException("inputStream");
			if (String.IsNullOrEmpty(outputFile)) throw new ArgumentNullException("outputFile");

			using (FileStream outputStream = new FileStream(outputFile, fileMode, FileAccess.Write))
			{
				int cnt = 0;
				const int LEN = 4096;
				byte[] buffer = new byte[LEN];
				
				while ((cnt = inputStream.Read(buffer, 0, LEN)) != 0) outputStream.Write(buffer, 0, cnt);
			}
		}
		
		/// <summary>
		/// Write to a stream and from a stream.
		/// </summary>
		/// <param name="readStream">The input stream to read.</param>
		/// <param name="writeStream">The ouput stream to save.</param>
		public static void ReadWriteStream(Stream readStream, Stream writeStream)
		{
			if (readStream == null) throw new ArgumentNullException("readStream");
			if (writeStream == null) throw new ArgumentNullException("writeStream");
			
			const int Length = 256;
			byte[] buffer = new Byte[Length];
			int bytesRead = readStream.Read(buffer,0,Length);
			
			while( bytesRead > 0 )
			{
				writeStream.Write(buffer,0,bytesRead);
				bytesRead = readStream.Read(buffer,0,Length);
			}
			
			readStream.Close();
			writeStream.Close();
		}
		
		#endregion

	}
}
