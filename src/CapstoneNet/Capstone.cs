using System;
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