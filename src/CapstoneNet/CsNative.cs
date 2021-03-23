using System;
using System.IO;
using System.Runtime.InteropServices;
using CapstoneNet.Data;

namespace CapstoneNet
{
    public static class CsNative
    {
#if NETCOREAPP
        private const string LibraryName = "Capstone";

        static CsNative()
        {
            NativeLibrary.SetDllImportResolver(typeof(CsNative).Assembly, (name, assembly, path) =>
            {
                var handle = IntPtr.Zero;

                if (name == LibraryName)
                {
                    var basePath = Path.GetDirectoryName(assembly.Location);
                    if (basePath == null)
                    {
                        throw new ArgumentException("Expected directory of Assembly.Location to not be null.", nameof(basePath));    
                    }
                    
                    var libraryFile = "capstone.dll";

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        libraryFile = "capstone.so";
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        libraryFile = "capstone.dylib";
                    }

                    switch (RuntimeInformation.ProcessArchitecture)
                    {
                        case Architecture.X64:
                            NativeLibrary.TryLoad(Path.Combine(basePath, "Libs", "x64", libraryFile), out handle);
                            break;
                        case Architecture.Arm64:
                            NativeLibrary.TryLoad(Path.Combine(basePath, "Libs", "arm64", libraryFile), out handle);
                            break;
                        default:
                            throw new NotImplementedException("Unsupported architecture.");
                    }
                }

                return handle;
            });
        }
#else
        private const string LibraryName = "Libs/x64/unicorn";
#endif
        
        [DllImport(LibraryName, EntryPoint = "cs_version")]
        public static extern uint CsVersion(IntPtr major, IntPtr minor);
        
        [DllImport(LibraryName, EntryPoint = "cs_open")]
        public static extern CsErr CsOpen(CsArch arch, CsMode mode, IntPtr engine);
        
        [DllImport(LibraryName, EntryPoint = "cs_close")]
        public static extern CsErr CsClose(IntPtr handle);
        
        [DllImport(LibraryName, EntryPoint = "cs_errno")]
        public static extern CsErr CsErrno(IntPtr handle);
        
        [DllImport(LibraryName, EntryPoint = "cs_disasm")]
        public static extern ulong CsDisasm(IntPtr handle, byte[] code, int codeSize, ulong address, ulong count, ref IntPtr insn);

        [DllImport(LibraryName, EntryPoint = "cs_free")]
        public static extern void CsFree(IntPtr addr, ulong count);
    }
}