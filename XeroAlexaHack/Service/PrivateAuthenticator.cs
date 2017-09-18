using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Infrastructure.OAuth.Signing;

namespace XeroAlexaHack.Service
{
    public class PrivateAuthenticator : IAuthenticator
    {
        private readonly X509Certificate2 _certificate;

        public PrivateAuthenticator(string certificatePath)
            : this(certificatePath, (string) "")
        {

        }

        public PrivateAuthenticator(string certificatePath, string certificatePassword = "")
        {
            var filebytes = new System.Net.WebClient().DownloadData(certificatePath);
            //var filebytes = File.ReadAllBytes(certificatePath);
            try
            {
                _certificate = new X509Certificate2(filebytes, certificatePassword, X509KeyStorageFlags.MachineKeySet |
                                                                                              X509KeyStorageFlags.PersistKeySet |
                                                                                              X509KeyStorageFlags.Exportable);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }

        public PrivateAuthenticator(X509Certificate2 certificate)
        {
            _certificate = certificate;
        }

        public string GetSignature(IConsumer consumer, IUser user, Uri uri, string verb, IConsumer consumer1)
        {
            var token = new Token
            {
                ConsumerKey = consumer.ConsumerKey,
                ConsumerSecret = consumer.ConsumerSecret,
                TokenKey = consumer.ConsumerKey
            };

            return new RsaSha1Signer().CreateSignature(_certificate, token, uri, verb);
        }

        public X509Certificate Certificate { get { return _certificate; } }

        public IToken GetToken(IConsumer consumer, IUser user)
        {
            return null;
        }

        public IUser User { get; set; }
    }
}