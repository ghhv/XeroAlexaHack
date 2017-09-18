using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroAlexaHack.Models.Alexa
{
    public class AlexaResponse
    {

        public AlexaResponse()
        {
            sessionAttributes = new Sessionattributes();
            response = new Response();
        }
        public string version { get; set; }
        public Sessionattributes sessionAttributes { get; set; }
        public Response response { get; set; }
    }

    public class Sessionattributes
    {

    }


    public class Response
    {
        public Response()
        {
            outputSpeech = new Outputspeech();
            card = new Card();
            reprompt = new Reprompt();
        }
        public Outputspeech outputSpeech { get; set; }
        public Card card { get; set; }
        public Reprompt reprompt { get; set; }
        public bool shouldEndSession { get; set; }
    }

    public class Outputspeech
    {
        public string type { get; set; }
        public string text { get; set; }

    }

    public class Card
    {
        public string type { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }

    public class Reprompt
    {
        public Reprompt()
        {
            outputSpeech = new Outputspeech1();
        }
        public Outputspeech1 outputSpeech { get; set; }
    }

    public class Outputspeech1
    {
        public string type { get; set; }
        public string text { get; set; }
    }
}
