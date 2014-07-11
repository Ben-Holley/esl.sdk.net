﻿using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    /// <summary>
    /// Get a package's messages (ex: opt-out or decline messages from signers).
    /// </summary>
    public class GetPackageMessageExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new GetPackageMessageExample(Props.GetInstance()).Run();
        }

        private string email1;
        private Stream fileStream1;

        public GetPackageMessageExample(Props props) : this(props.Get("api.url"), props.Get("api.key"), props.Get("1.email"))
        {
        }

        public GetPackageMessageExample(string apiKey, string apiUrl, string email1) : base(apiKey, apiUrl)
        {
            this.email1 = email1;
            this.fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document.pdf").FullName);
        }

        override public void Execute()
        {
            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed("GetPackageMessageExample: " + DateTime.Now)
                    .DescribedAs("This is a package created using the e-SignLive SDK")
                    .ExpiresOn(DateTime.Now.AddMonths(100))
                    .WithEmailMessage("This message should be delivered to all signers")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                        .WithCustomId("Client1")
                        .WithFirstName("John")
                        .WithLastName("Smith")
                        .WithTitle("Managing Director")
                        .WithCompany("Acme Inc."))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                        .FromStream(fileStream1, DocumentType.PDF)
                        .WithSignature(SignatureBuilder.SignatureFor(email1)
                            .OnPage(0)
                            .AtPosition(100, 100)
                            .WithSize(200, 50)))
                    .Build();

            packageId = eslClient.CreateAndSendPackage(superDuperPackage);

            // Signer opt-out or decline signing.

            // Get the list of messages from signer (ex: opt-out or decline reasons)
            IList<Message> declineMessages = eslClient.GetPackage(packageId).Messages;

            Console.WriteLine("Decline reason : " + declineMessages[0].Content);
        }
    }
}
