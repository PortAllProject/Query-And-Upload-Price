using AElf.Types;

namespace Price.Query.AElfWeb.Extensions
{
    public static class AddressExtension
    {
        public static Address ConvertAddress(this string address)
        {
            return Address.FromBase58(address);
        }
    }
}