using ImageConvert.Exceptions;
using System;
using System.Drawing;
using System.IO;

namespace ImageConvert
{
    internal class MainEngine
    {
        #region Internal Properties

        internal event ErrorOccurredEventHandler ErrorOccurred = delegate { };

        #endregion

        #region Internal Methods

        internal void Convert(string fileName, string extension, string destination)
        {
            using (Image image = Image.FromFile(fileName))
            {
                if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

                image.Save(Path.Combine(destination, Path.ChangeExtension(Path.GetFileNameWithoutExtension(fileName), extension)));
            }
        }

        internal int ConvertInDirectory(string path, string extension, string destination)
        {
            string directoryName = Path.GetDirectoryName(path);
            string[] filesNames;
            string fileName = Path.GetFileName(path);

            if (fileName.Contains("*") || fileName.Contains("?"))
            {
                filesNames = Directory.GetFiles(directoryName, fileName);
            }
            else
            {
                filesNames = new string[] { path };
            }

            int result = 0;

            foreach (string fileName_ in filesNames)
            {
                try
                {
                    Convert(fileName_, extension, destination);
                    ++result;
                }
                catch (Exception exception)
                {
                    ErrorOccurred(this, new ErrorOccurredEventArgs(exception.Message));
                }
            }

            return result;
        }

        #endregion
    }
}
