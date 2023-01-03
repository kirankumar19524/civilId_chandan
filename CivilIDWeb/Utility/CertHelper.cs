using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CivilIDWeb.Utility
{

    public class CertHelper : ICertificateService
    {
        public byte[]? GetCertificateFromLocalMachineStore(string friendlyName)
        {
            var store = GetLocalMachineCertificates();
            X509Certificate2? certificate = null;
            foreach (var cert in store.Cast<X509Certificate2>().Where(cert => cert.FriendlyName.Equals(friendlyName)))
            {
                certificate = cert;
            }
            return certificate?.Export(X509ContentType.Pkcs12);
        }

        private static X509Certificate2Collection GetLocalMachineCertificates()
        {
            var localMachineStore = new X509Store(StoreLocation.LocalMachine);
            localMachineStore.Open(OpenFlags.ReadOnly);
            var certificates = localMachineStore.Certificates;
            localMachineStore.Close();
            return certificates;
        }
    }

    public interface ICertificateService
    {
        byte[]? GetCertificateFromLocalMachineStore(string friendlyName);
    }
}



