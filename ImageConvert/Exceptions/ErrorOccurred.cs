using System;

namespace ImageConvert.Exceptions
{
    internal class ErrorOccurredEventArgs : EventArgs
    {
        #region Public Fields

        public readonly string Message;

        #endregion

        #region Internal Methods

        internal ErrorOccurredEventArgs(string message)
        {
            Message = message;
        }

        #endregion
    }

    internal delegate void ErrorOccurredEventHandler(object sender, ErrorOccurredEventArgs e);
}
