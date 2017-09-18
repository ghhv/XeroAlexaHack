using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using XeroAlexaHack.Models.Alexa;
using XeroAlexaHack.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XeroAlexaHack.Controllers
{
    public class AlexaController : Controller
    {



        [HttpPost]
        public async Task<IActionResult> Index([FromBody]AlexaRequest request)
        {
            try
            {

                switch (request.request.intent.name)
                {
                    case "test":
                        var testresponse = await (new XeroHackService().GetError(""));
                        return Json(testresponse);
                        break;
                    case "risk":
                        var riskresponse = await (new XeroHackService().GetRisk());
                        return Json(riskresponse);
                        break;
                    case "InvoiceStatus":
                        return Json(await (new XeroHackService().GetInvoiceStatus()));
                        break;
                }

            }
            catch (Exception e)
            {
                return Json(new XeroHackService().GetError(e.Message));
            }
            return Json(new XeroHackService().GetError(""));
        }
    }
}
