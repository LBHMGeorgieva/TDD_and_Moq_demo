using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Calculator_example___TDD_and_Moq.Actions;
using Calculator_example___TDD_and_Moq.Intefaces;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Calculator_example___TDD_and_Moq.Tests
{
    public class TagReferenceActionsTests
    {

        [Fact]
        public async Task check_if_get_tag_reference_returns_a_tag_reference_successfully_when_parameter_is_correct()
        {
            
            var dictionary = new Dictionary<string, List<string>>();
            var tag = new List<string>
            {
                "00001/01"
            };
            dictionary.Add("results", tag);

            string jsonString = JsonConvert.SerializeObject(dictionary);

            var apiCallResult = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json") };
            var moqHackneyAPICall = new Mock<IHackneyAPICall>();
            moqHackneyAPICall.Setup(x => x.getAPIResponse(It.IsAny<HttpClient>(), It.IsAny<string>())).Returns(apiCallResult);

            var actions = new TagReferenceActions(moqHackneyAPICall.Object);
            var result = await actions.getTagReference("1111");

            
            var expectedResult = new
            {
                result = "00001/01"
            };
            
            Assert.Equal(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task check_if_get_tag_reference_returns_an_empty_object_when_api_result_is_null()
        {
         
            var apiCallResult = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty, System.Text.Encoding.UTF8, "application/json") };
            var moqHackneyAPICall = new Mock<IHackneyAPICall>();
            moqHackneyAPICall.Setup(x => x.getAPIResponse(It.IsAny<HttpClient>(), It.IsAny<string>())).Returns(apiCallResult);

            var actions = new TagReferenceActions(moqHackneyAPICall.Object);
            var result = await actions.getTagReference("1111");

            var expectedResult = new
            {
                result = new object()
            };

            Assert.Equal(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task check_if_get_tag_reference_throws_a_missing_result_exception_when_server_responds_with_null()
        {
            var moqHackneyAPICall = new Mock<IHackneyAPICall>();
            moqHackneyAPICall.Setup(x => x.getAPIResponse(It.IsAny<HttpClient>(), It.IsAny<string>())).Returns(() => null);

            var actions = new TagReferenceActions(moqHackneyAPICall.Object);
          
            await Assert.ThrowsAsync<GetTagReferenceMissingResultException>(async ()  => await actions.getTagReference("1111"));
        }

        //Write a test that will check if a "GetTagReferenceServiceException" is thrown when the server responds with an error (not successful Http status code).

    }
}