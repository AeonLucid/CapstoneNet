using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CapstoneNet.Data;

namespace CapstoneNet
{
    public class Capstone : IDisposable
    {
        public Capstone(CsArch arch, CsMode mode)
        {
            var result = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>());
            var err = CsNative.CsOpen(arch, mode, result);
            if (err != CsErr.CS_ERR_OK)
            {
                throw new CsException($"Failed to create native Capstone instance, error {err}.", err);
            }
            
            Handle = (IntPtr) Marshal.PtrToStructure(result, typeof(IntPtr));
        }
        
        public IntPtr Handle { get; }

        public CsErr Errno()
        {
            return CsNative.CsErrno(Handle);
        }

        public List<CsInsn> Disasm(byte[] code, ulong address, uint count = 0)
        {
            var result = new List<CsInsn>();
            
            var insnAll = new IntPtr();
            var insnSize = Marshal.SizeOf<CsInsn>();
            var res = CsNative.CsDisasm(Handle, code, code.Length, address, count, ref insnAll);
            if (res > 0)
            {
                try
                {
                    // Read all instructions.
                    var insnOffset = insnAll;
                
                    for (uint i = 0; i < res; i++)
                    {
                        result.Add(Marshal.PtrToStructure<CsInsn>(insnOffset));
                        insnOffset += insnSize;
                    }
                }
                finally
                {
                    // Free the buffer.
                    CsNative.CsFree(insnAll, res);
                }
            }
            else
            {
                var status = CsNative.CsErrno(Handle);
                if (status != CsErr.CS_ERR_OK)
                {
                    throw new CsException(status);
                }
            }

            return result;
        }

        public void Dispose()
        {
            var err = CsNative.CsClose(Handle);
            if (err != CsErr.CS_ERR_OK)
            {
                throw new CsException($"Failed to close native Unicorn instance, error {err}.", err);
            }
        }
    }
}