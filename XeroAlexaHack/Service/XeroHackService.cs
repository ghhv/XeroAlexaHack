using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroAlexaHack.Models.Alexa;

namespace XeroAlexaHack.Service
{
    public class XeroHackService
    {
        public async Task<AlexaResponse> GetInvoiceStatus()
        {
             var apiService =  new XeroApiService();
            var invoiceContent = await apiService.GetInvoices();


            var response = new AlexaResponse()
            {
                version = "1.0",
                response = new Response()
                {
                    card = new Card()
                    {
                        type = "Simple",
                        title = "Invoice",
                        content = invoiceContent,
                    },
                    outputSpeech = new Outputspeech()
                    {
                        type = "PlainText",
                        text = invoiceContent
                    },
                    reprompt = new Reprompt()
                    {
                        outputSpeech = new Outputspeech1()
                        {
                            type = "PlainText",
                            text = "Can I help you with anything else?"
                        }
                    },
                    shouldEndSession = false,
                }
            };
            return response;
        }

        public async Task<AlexaResponse> GetRisk()
        {

            var apiService = new XeroApiService();
            var riskContent = await apiService.GetRisks();
            var response = new AlexaResponse()
            {
                version = "1.0",
                response = new Response()
                {
                    card = new Card()
                    {
                        type = "Simple",
                        title = "Risk",
                        content = riskContent,
                    },
                    outputSpeech = new Outputspeech()
                    {
                        type = "PlainText",
                        text = riskContent
                    },
                    reprompt = new Reprompt()
                    {
                        outputSpeech = new Outputspeech1()
                        {
                            type = "PlainText",
                            text = "Can I help you with anything else?"
                        }
                    },
                    shouldEndSession = false,
                }
            };

            return response;
        }

        public async Task<AlexaResponse> GetError( string error)
        {
            var response = new AlexaResponse()
            {
                version = "1.0",
                response = new Response()
                {
                    card = new Card()
                    {
                        type = "Simple",
                        title = "Error",
                        content = "There was an error" + error,
                    },
                    outputSpeech = new Outputspeech()
                    {
                        type = "PlainText",
                        text = "There was an error"
                    },
                    reprompt = new Reprompt()
                    {
                        outputSpeech = new Outputspeech1()
                        {
                            type = "PlainText",
                            text = "Can I help you with anything else?"
                        }
                    },
                    shouldEndSession = false,
                }
            };

            return response;
        }
    }
}
