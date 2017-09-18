using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLitePCL;
using Xero.Api.Core;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Infrastructure.RateLimiter;
using Xero.Api.Serialization;
using XeroAlexaHack.Models.InvoiceMessage;
using XeroAlexaHack.Models.Settings;


namespace XeroAlexaHack.Service
{
    public class XeroApiService 
    {
        
            private static readonly DefaultMapper Mapper = new DefaultMapper();
            private static readonly AppSettings ApplicationSettings = new AppSettings();

            
            

        public XeroCoreApi GetApi()
        {
            return new XeroCoreApi(ApplicationSettings.Uri, new PrivateAuthenticator(ApplicationSettings.SigningCertificatePath, ApplicationSettings.SigningCertificatePassword), new Consumer(ApplicationSettings.Key, ApplicationSettings.Secret), null, Mapper, Mapper, null);
        }

        public async Task<string> GetInvoices()
        {

            var api = GetApi();
            var invoice = await api.Invoices.FindAsync();
            var paidInvoicesCount = invoice.Where(o => o.AmountDue == 0).Count();
            var invoicesOutstanding = invoice.Where(o => o.AmountDue > 0);
            var amountOutstanding = invoicesOutstanding.Sum(o => o.AmountDue);
            var outstandingCount = invoicesOutstanding.Count();
            return $"You have {paidInvoicesCount} invoices that have been paid. You have {outstandingCount} invoice with a balance to pay of {amountOutstanding}";
        }


        public async Task<string> GetRisks()
        {
            var api = GetApi();
            var response = "There are no risks identified";

            var invoice = await api.Invoices.FindAsync();
            
            var invoicesOutstanding = invoice.Where(o => o.AmountDue > 0 && o.DueDate < DateTime.UtcNow.AddDays(-60));
            if(invoicesOutstanding.Any())
            response =$"You have {invoicesOutstanding.Count()} invoice with an outstanding balance of {invoicesOutstanding.Sum(o => o.AmountDue)}";


            return response;
        }
    }
}
