namespace CapstoneNet.Data
{
    public enum CsMode
    {
        CS_MODE_LITTLE_ENDIAN = 0,        // little-endian mode (default mode)
        CS_MODE_ARM = 0,                  // ARM mode
        CS_MODE_16 = (1 << 1),            // 16-bit mode (for X86)
        CS_MODE_32 = (1 << 2),            // 32-bit mode (for X86)
        CS_MODE_64 = (1 << 3),            // 64-bit mode (for X86, PPC)
        CS_MODE_THUMB = (1 << 4),         // ARM's Thumb mode, including Thumb-2
        CS_MODE_MCLASS = (1 << 5),        // ARM's Cortex-M series
        CS_MODE_V8 = (1 << 6),            // ARMv8 A32 encodings for ARM
        CS_MODE_MICRO = (1 << 4),         // MicroMips mode (MIPS architecture)
        CS_MODE_MIPS3 = (1 << 5),         // Mips III ISA
        CS_MODE_MIPS32R6 = (1 << 6),      // Mips32r6 ISA
        CS_MODE_MIPS2 = (1 << 7),         // Mips II ISA
        CS_MODE_V9 = (1 << 4),            // Sparc V9 mode (for Sparc)
        CS_MODE_QPX = (1 << 4),           // Quad Processing eXtensions mode (PPC)
        CS_MODE_M68K_000 = (1 << 1),      // M68K 68000 mode
        CS_MODE_M68K_010 = (1 << 2),      // M68K 68010 mode
        CS_MODE_M68K_020 = (1 << 3),      // M68K 68020 mode
        CS_MODE_M68K_030 = (1 << 4),      // M68K 68030 mode
        CS_MODE_M68K_040 = (1 << 5),      // M68K 68040 mode
        CS_MODE_M68K_060 = (1 << 6),      // M68K 68060 mode
        CS_MODE_BIG_ENDIAN = (1 << 31),   // big-endian mode
        CS_MODE_MIPS32 = CS_MODE_32,      // Mips32 ISA
        CS_MODE_MIPS64 = CS_MODE_64,      // Mips64 ISA
        CS_MODE_M680X_6301 = (1 << 1),    // M680X HD6301/3 mode
        CS_MODE_M680X_6309 = (1 << 2),    // M680X HD6309 mode
        CS_MODE_M680X_6800 = (1 << 3),    // M680X M6800/2 mode
        CS_MODE_M680X_6801 = (1 << 4),    // M680X M6801/3 mode
        CS_MODE_M680X_6805 = (1 << 5),    // M680X M6805 mode
        CS_MODE_M680X_6808 = (1 << 6),    // M680X M68HC08 mode
        CS_MODE_M680X_6809 = (1 << 7),    // M680X M6809 mode
        CS_MODE_M680X_6811 = (1 << 8),    // M680X M68HC11 mode
        CS_MODE_M680X_CPU12 = (1 << 9),   // M680X CPU12 mode
        CS_MODE_M680X_HCS08 = (1 << 10),  // M680X HCS08 mode
    }
}