using Ishopping.Application;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ishopping.Controllers.Professional
{
    public class TechgutApiController : ApiController
    {
        private readonly UserSerializeViewDataAppService _userSerializeViewDataAppService;

        public TechgutApiController(UserSerializeViewDataAppService userSerializeViewDataAppService)
        {
            _userSerializeViewDataAppService = userSerializeViewDataAppService;
        }            
               
        [HttpGet]
        public Task<HttpResponseMessage> Get(int id = 0)
        {                  
            HttpResponseMessage response = new HttpResponseMessage();                

            try
            {           
                var result = _userSerializeViewDataAppService.GetBySiteNumber(id, 4020).Serialize;
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;                                  
        }

    }
}
