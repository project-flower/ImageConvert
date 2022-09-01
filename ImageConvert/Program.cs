using System;

namespace ImageConvert
{
    internal class Program
    {
        #region Internal Methods

        internal static int Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: ImageConvert.exe [Path] [Extension] [Destination]");
                return -1;
            }

            var mainEngine = new MainEngine();
            mainEngine.ErrorOccurred += mainEngine_ErrorOccurred;
            int result;
            string destination = args[2];

            try
            {
                result = mainEngine.ConvertInDirectory(args[0], args[1], destination);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return -1;
            }

            Console.WriteLine($"{result} files has been converted.");
            return 0;
        }

        #endregion

        #region Private Methods

        private static void mainEngine_ErrorOccurred(object sender, Exceptions.ErrorOccurredEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        #endregion
    }
}
