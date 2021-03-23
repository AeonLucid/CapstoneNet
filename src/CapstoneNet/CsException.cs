using System;
using CapstoneNet.Data;

namespace CapstoneNet
{
    public class CsException : Exception
    {
        public CsException(CsErr ucErr) : base(ucErr.ToString())
        {
            UcicornError = ucErr;
        }

        public CsException(string message, CsErr ucErr) : base(message)
        {
        }
        
        public CsErr UcicornError { get; }
    }
}