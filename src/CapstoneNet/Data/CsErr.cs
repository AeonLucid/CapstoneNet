namespace CapstoneNet.Data
{
    public enum CsErr
    {
        CS_ERR_OK = 0,         // No error: everything was fine
        CS_ERR_MEM = 1,        // Out-Of-Memory error: cs_open(), cs_disasm()
        CS_ERR_ARCH = 2,       // Unsupported architecture: cs_open()
        CS_ERR_HANDLE = 3,     // Invalid handle: cs_op_count(), cs_op_index()
        CS_ERR_CSH = 4,        // Invalid csh argument: cs_close(), cs_errno(), cs_option()
        CS_ERR_MODE = 5,       // Invalid/unsupported mode: cs_open()
        CS_ERR_OPTION = 6,     // Invalid/unsupported option: cs_option()
        CS_ERR_DETAIL = 7,     // Invalid/unsupported option: cs_option()
        CS_ERR_MEMSETUP = 8,
        CS_ERR_VERSION = 9,    // Unsupported version (bindings)
        CS_ERR_DIET = 10,      // Information irrelevant in diet engine
        CS_ERR_SKIPDATA = 11,  // Access irrelevant data for "data" instruction in SKIPDATA mode
        CS_ERR_X86_ATT = 12,   // X86 AT&T syntax is unsupported (opt-out at compile time)
        CS_ERR_X86_INTEL = 13, // X86 Intel syntax is unsupported (opt-out at compile time)
        CS_ERR_X86_MASM = 14,  // X86 Intel syntax is unsupported (opt-out at compile time)
    }
}