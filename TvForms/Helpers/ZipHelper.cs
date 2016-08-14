using System.IO;
using System.IO.Compression;

namespace TvForms
{
    public class ZipHelper
    {

        /// <summary>
        /// Create a ZIP file of the files provided.
        /// </summary>
        /// <param name="archiveName">The full path and name to store the ZIP file at.</param>
        /// <param name="sourceFile">The list of files to be added.</param>
        public static void CreateZipFile(string archiveName, string sourceFile)
        {
            // Create and open a new ZIP file
            var zip = ZipFile.Open(archiveName, ZipArchiveMode.Create);

            zip.CreateEntryFromFile(sourceFile, Path.GetFileName(sourceFile), CompressionLevel.Optimal);
            zip.Dispose();
        }


    }
}