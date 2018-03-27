using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Calculator_example___TDD_and_Moq.Actions;
using Calculator_example___TDD_and_Moq.Intefaces;
using Calculator_example___TDD_and_Moq.Models;
using Calculator_example___TDD_and_Moq.Service;

namespace Calculator_example___TDD_and_Moq.Controllers
{
   public class GetTagReferenceController : ApiController
    {
        private IHackneyAPICall _apiCall;
       
        public GetTagReferenceController()
        {
            _apiCall = new HackneyAPICall();
        }


        [System.Web.Http.HttpGet]
        public async Task<object> GetTagReferenceByHackneyHomesId(string hackneyHomesId)
        {
            try
            {
                if (!string.IsNullOrEmpty(hackneyHomesId))
                {
                    var actions = new TagReferenceActions(_apiCall);
                    var result = await actions.getTagReference(hackneyHomesId);

                    var tagReferenceResult = Json(result);
                    return tagReferenceResult;
                }
                else
                {
                    var errors = new APIErrors
                    {
                        developerMessage = "Tag reference is empty",
                        userMessage = "Please provide a tag reference number"
                    };

                    var jsonResponse = Json(errors);
                    return jsonResponse;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}