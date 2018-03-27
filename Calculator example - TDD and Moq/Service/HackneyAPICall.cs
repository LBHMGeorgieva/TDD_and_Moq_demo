using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Calculator_example___TDD_and_Moq.Actions;
using Calculator_example___TDD_and_Moq.Intefaces;

namespace Calculator_example___TDD_and_Moq.Service
{
    public class HackneyAPICall : IHackneyAPICall
    {
        public HttpResponseMessage getAPIResponse(HttpClient client, string query)
        {
            var response = new HttpResponseMessage();
            try
            {
                response = client.GetAsync(query).Result;
              
            }
            catch (Exception ex)
            {

                response.StatusCode = HttpStatusCode.BadRequest;
                throw ex;
            }
            return response;
        }
    }
}