using System.IO;
using System.IO.Compression;
using System.Linq;

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
            var zip = ZipFile.Open(archiveName, ZipArchiveMode.Update);

            zip.CreateEntryFromFile(sourceFile, Path.GetFileName(sourceFile), CompressionLevel.Optimal);
            zip.Dispose();
        }


        public static string UnzipArchiveWithFavourite(string fileName)
        {
            var unzipedFileName = fileName.Split('.')[0] + ".xml";

            if (fileName.Split('.').Last().ToLower() == "zip")
            {
                var extractPath = Path.GetDirectoryName(fileName);
                if(File.Exists(unzipedFileName))
                    File.Delete(unzipedFileName);

                ZipFile.ExtractToDirectory(fileName, extractPath);
            }
            return unzipedFileName;

        }
    }
}