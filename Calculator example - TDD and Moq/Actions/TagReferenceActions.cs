using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Calculator_example___TDD_and_Moq.Intefaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Calculator_example___TDD_and_Moq.Actions
{
    public class TagReferenceActions
    {
        private IHackneyAPICall _apiCall;
        public TagReferenceActions(IHackneyAPICall apiCall)
        {
            _apiCall = apiCall;
        }

        public async Task<object> getTagReference(string hackneyHomesId)
        {
            HttpResponseMessage result = null;
            try
            {
                var query = "http://sandboxapi.hackney.gov.uk/v1/Accounts/GetTagReferencenumber?hackneyhomesId=" +
                            hackneyHomesId;
                result = _apiCall.getAPIResponse(new HttpClient(), query);

                if (result != null)
                {
                    if (!result.IsSuccessStatusCode)
                    {
                        throw new GetTagReferenceServiceException();
                    }

                    var tagReferenceResult = JsonConvert.DeserializeObject<JObject>(result.Content.ReadAsStringAsync().Result);

                    if (tagReferenceResult !=null)
                    {
                        var getTagReference = tagReferenceResult["results"];
                        return new
                        {
                            result = getTagReference.First
                        };
                    }
                    else
                    {
                        return new
                        {
                            result = new object()
                        };
                    }
                }
                else
                {
                    throw new GetTagReferenceMissingResultException();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

    public class GetTagReferenceServiceException : Exception
    {
    }

    public class GetTagReferenceMissingResultException : Exception
    {
    }
}