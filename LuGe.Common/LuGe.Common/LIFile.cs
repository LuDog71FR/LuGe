/*
 * User: Ludovic Germain
 * Date: 23/01/2008 14:35:53
 */

using System;
using System.IO;

namespace LuGe.Common
{
	/// <summary>
	/// This class provides methods to easly manipulate files.
	/// </summary>
	public static class LIFile
	{

		#region Fields

		#endregion

		#region Constructors

		#endregion

		#region Properties

		#endregion

		#region Methods
		
		/// <summary>
		/// Check if a file is locked.
		/// </summary>
		/// <param name="file">The file to check.</param>
		/// <returns>True if the file is locked; otherwise false.</returns>
		public static bool IsFileLocked(FileInfo file)
		{
			try
			{
				using(file.Open(FileMode.Open, FileAccess.Read, FileShare.None)) { };
			}
			catch (IOException)
			{
				return true;
			}
			
			return false;
		}
		
		/// <summary>
		/// Compare two text files.
		/// </summary>
		/// <param name="fileName">Name of the first file.</param>
		/// <param name="fileName2">Name of the second file.</param>
		/// <returns>True if both files contains the same text; otherwise False.</returns>
		public static bool Equals(string fileName, string fileName2)
		{
			return File.ReadAllText(fileName) == File.ReadAllText(fileName2);
		}

		/// <summary>
		/// Get the number of lines in the specified text file.
		/// </summary>
		/// <param name="fileName">Name of the text file.</param>
		/// <returns>The number of lines</returns>
		public static int NumberOfLines(string fileName)
		{
			var lineCount = 0;
			
			using (var reader = File.OpenText(fileName))
			{
				while (reader.ReadLine() != null)
				{
					lineCount++;
				}
			}
			
			return lineCount;
		}
		
		#endregion

	}
}
