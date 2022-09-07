using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordsVaultUI.HelperClasses.Exceptions
{
    public class DataLoadingExceptions : Exception
    { 
        public DataLoadingExceptions(string message)
            : base(message) { }
    }

    public class FailedDecryptionException : DataLoadingExceptions
    {
        public FailedDecryptionException(string message)
        : base(message) { }
    }

    public class FailedLoginMissingFileException : DataLoadingExceptions
    {
        public FailedLoginMissingFileException(string message)
        : base(message) { }
    }
}
