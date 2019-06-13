using CexCore.Contracts;
using CexCore.Models.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CexCore.Utilities
{
    internal static class ResponseConverter<TResponse> where TResponse : IResponse
    {
        internal static Tuple<HttpStatusCode, TResponse> ConvertResponse(Tuple<HttpStatusCode, string> response)
        {
            TResponse convertedResponse = JsonConvert.DeserializeObject<TResponse>(response.Item2);

            return new Tuple<HttpStatusCode, TResponse>(response.Item1, convertedResponse);
        }
    }
}
