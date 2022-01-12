using AElf.Cryptography.ECDSA;

namespace Price.Query.AElfWeb.Managers.KeyAccount
{
    public interface IKeyStore
    {
        ECKeyPair GetAccountKeyPair();
    }
}