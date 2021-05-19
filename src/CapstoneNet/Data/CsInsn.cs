using System;
using System.Runtime.InteropServices;

namespace CapstoneNet.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CsInsn
    {
        public uint id;
        
        public ulong address;
        
        public ushort size;
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] bytes;
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string mnemonic;
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 160)]
        public string op_str;

        public IntPtr detail;

        public override string ToString()
        {
            return $"{nameof(CsInsn)}: {mnemonic} {op_str}";
        }
    }
}