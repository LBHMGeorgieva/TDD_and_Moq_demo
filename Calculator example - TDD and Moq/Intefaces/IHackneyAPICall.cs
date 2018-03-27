using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_example___TDD_and_Moq.Intefaces
{
    public interface IHackneyAPICall
    {
        HttpResponseMessage getAPIResponse(HttpClient client, string query);
    }
}
