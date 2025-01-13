/*
 * User: lgermain
 * Date: 08/10/2008 15:04
 */

using System;
using System.IO;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.BZip2;

namespace LuGe.Common
{
	/// <summary>
	/// Zip and UnZip files.
	/// </summary>
	public class LIZip
	{
		#region Consts
		
		/// <summary>
		/// Maximum level of compression.
		/// </summary>
		public const int CompressionLevelMax = 9;
		
		#endregion
		
		#region Fields
		
		private string _zipFileName; // Name of the zip file.
		private int _compressionLevel; // Compression level ( 0 - store only to 9 - means best compression ).
		
		#endregion
		
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="LIZip">LIZip</see> class.
		/// </summary>
		public LIZip()
		{
			_compressionLevel = 9;
		}
		
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="LIZip">LIZip</see> class.
		/// </summary>
		/// <param name="zipFileName">Name of the zip file.</param>
		public LIZip(string zipFileName): this()
		{
			ZipFileName = zipFileName;
		}
		
		#endregion

		#region Properties
		
		/// <summary>
		/// Gets or sets the name of the zip file.
		/// </summary>
		public string ZipFileName
		{
			get { return _zipFileName; }
			set
			{
				if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");
				
				_zipFileName = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the compression level
		/// ( 0 - store only to 9 - means best compression ).
		/// </summary>
		/// <remarks>
		/// Set to 9 by default.
		/// </remarks>
		public int CompressionLevel
		{
			get { return _compressionLevel; }
			set { _compressionLevel = value; }
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// BZip the file specified into the bzip file.
		/// </summary>
		/// <param name="fileName">File to zip.</param>
		public void BZip(string fileName)
		{
			using (BZip2OutputStream s = new BZip2OutputStream(File.Create(this.ZipFileName)))
			{
				byte[] buffer = new byte[4096];
				
				using (FileStream fs = File.OpenRead(fileName))
				{
					int sourceBytes;
					
					do
					{
						sourceBytes = fs.Read(buffer, 0, buffer.Length);
						s.Write(buffer, 0, sourceBytes);
					} while ( sourceBytes > 0 );
				}
				
				s.Flush();
				s.Close();
			}
		}
		
		/// <summary>
		/// Zip all the files specified into the zip file.
		/// </summary>
		/// <param name="fileNames">List of files to zip.</param>
		public void Zip(IEnumerable<string> fileNames)
		{
			using (ZipOutputStream s = new ZipOutputStream(File.Create(this.ZipFileName)))
			{
				s.SetLevel(_compressionLevel);
				
				byte[] buffer = new byte[4096];
				
				foreach (string file in fileNames)
				{
					ZipEntry entry = new ZipEntry(Path.GetFileName(file));
					
					entry.DateTime = DateTime.Now;
					s.PutNextEntry(entry);
					
					using (FileStream fs = File.OpenRead(file))
					{
						int sourceBytes;
						
						do
						{
							sourceBytes = fs.Read(buffer, 0, buffer.Length);
							s.Write(buffer, 0, sourceBytes);
						} while ( sourceBytes > 0 );
					}
				}
				
				s.Finish();
				s.Close();
			}
		}
		
		/// <summary>
		/// Unzip the file in the directory specified.
		/// </summary>
		/// <param name="destDir">Destination directory.</param>
		public void UnZip(string destDir)
		{
			if (Directory.Exists(destDir) == false) throw new ArgumentException("Destination directory don't exists !");
			if (File.Exists(_zipFileName) == false) throw new ArgumentException("Zip file don't exits !");
			
			string oldCurrentDirectory = Directory.GetCurrentDirectory();
			
			using (ZipInputStream s = new ZipInputStream(File.OpenRead(ZipFileName)))
			{
				Directory.SetCurrentDirectory(destDir);
				
				ZipEntry theEntry;
				
				while ((theEntry = s.GetNextEntry()) != null)
				{
					string directoryName = Path.GetDirectoryName(theEntry.Name);
					string fileName      = Path.GetFileName(theEntry.Name);
					
					if (directoryName.Length > 0) Directory.CreateDirectory(directoryName);
					
					if (fileName == String.Empty) continue;
					
					using (FileStream streamWriter = File.Create(theEntry.Name))
					{
						int size = 2048;
						byte[] data = new byte[2048];
						
						while (true)
						{
							size = s.Read(data, 0, data.Length);
							if (size > 0) streamWriter.Write(data, 0, size);
							else 	break;
						}
					}
				}
			}
			
			Directory.SetCurrentDirectory(oldCurrentDirectory);
		}
		
		/// <summary>
		/// Unzip the array specified.
		/// </summary>
		/// <param name="source">Array of byte to unzip.</param>
		/// <returns>An array of byte unzipped.</returns>
		public static byte[] UnZipByteArray(byte[] source)
		{
			Stream dataStream = new MemoryStream(source);
			List<byte> unzippedData = new List<byte>();
			
			using (ZipInputStream streamReader = new ZipInputStream(dataStream))
			{
				ZipEntry theEntry;
				
				while ((theEntry = streamReader.GetNextEntry()) != null)
				{
					if (string.IsNullOrEmpty(theEntry.Name)) continue;
					
					using (MemoryStream streamWriter = new MemoryStream())
					{
						int size = 2048;
						byte[] data = new byte[2048];
						
						while (true)
						{
							size = streamReader.Read(data, 0, data.Length);
							if (size > 0) streamWriter.Write(data, 0, size);
							else break;
						}
						
						unzippedData.AddRange(streamWriter.ToArray());
					}
				}
			}
			
			return unzippedData.ToArray();
		}
		
		/// <summary>
		/// Zip the array specified.
		/// </summary>
		/// <param name="source">Array of byte to zip.</param>
		/// <param name="compressionLevel">Compression level.</param>
		/// <returns>An array of byte zipped.</returns>
		public static byte[] ZipByteArray(byte[] source, int compressionLevel)
		{
			MemoryStream dataStream = new MemoryStream();
			List<byte> zippedData = new List<byte>();
			
			using (ZipOutputStream s =  new ZipOutputStream(dataStream))
			{
				s.SetLevel(compressionLevel);
				
				ZipEntry entry = new ZipEntry("data.txt");
				entry.DateTime = DateTime.Now;
				s.PutNextEntry(entry);
				
				s.Write(source, 0, source.Length);
				
				s.Finish();
				s.Close();
			}
			
			zippedData.AddRange(dataStream.ToArray());
			
			return zippedData.ToArray();
		}
		
		/// <summary>
		/// Zip the array specified.
		/// </summary>
		/// <param name="source">Array of byte to zip.</param>
		/// <returns>An array of byte zipped.</returns>
		/// <remarks>
		/// The maximum compression level is used.
		/// </remarks>
		/// <seealso cref="CompressionLevelMax">CompressionLevelMax</seealso>
		public static byte[] ZipByteArray(byte[] source)
		{
			return ZipByteArray(source, CompressionLevelMax);
		}
		
		#endregion
		
	}
}
