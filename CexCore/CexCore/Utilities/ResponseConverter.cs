using CexCore.Contracts;
using Newtonsoft.Json;
using System;
using System.Net;

namespace CexCore.Utilities
{
    /// <summary>
    /// Generic response converters.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    internal static class ResponseConverter<TResponse> where TResponse : IResponse
    {
        /// <summary>
        /// Convert Tuple response.
        /// </summary>
        /// <param name="response">Tuple response with HttpStatusCode and string.</param>
        /// <returns>New tuple with HttpStatusCode and TResponse.</returns>
        internal static Tuple<HttpStatusCode, TResponse> ConvertResponse(Tuple<HttpStatusCode, string> response)
        {
            TResponse convertedResponse = JsonConvert.DeserializeObject<TResponse>(response.Item2);

            return new Tuple<HttpStatusCode, TResponse>(response.Item1, convertedResponse);
        }

        /// <summary>
        /// Convert JSON response to TResponse array.
        /// </summary>
        /// <param name="json">JSON string.</param>
        /// <returns>Array of TResponse.</returns>
        internal static TResponse[] ConvertToArray(string json) => JsonConvert.DeserializeObject<TResponse[]>(json);
    }
}
