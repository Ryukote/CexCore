using CexCore.Common;
using CexCore.Exceptions;
using CexCore.Utilities;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CexCore.Models.Request
{
    /// <summary>
    /// Base request model for all request models
    /// </summary>
    public class BaseRequest
    {
        private static string _userId = string.Empty;
        private static string _apiKey = string.Empty;
        private static string _apiSecret = string.Empty;
        private static long _nonce = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        public BaseRequest(string userId, string apiKey, string apiSecret)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
            {
                throw new UserIdNotProvidedException(CexExceptionMessages.UserIdNotProvidedException);
            }

            else if (string.IsNullOrEmpty(apiKey) || string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ApiKeyNotProvidedException(CexExceptionMessages.ApiKeyNotProvidedException);
            }

            else if (string.IsNullOrEmpty(apiSecret) || string.IsNullOrWhiteSpace(apiSecret))
            {
                throw new ApiSecretNotProvidedException(CexExceptionMessages.ApiSecretNotProvidedException);
            }

            _userId = userId;
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

        [JsonProperty("key")]
        public string Key { get { return _apiKey; } }

        [JsonProperty("signature")]
        public string Signature { get { return SignatureGenerator.Compute(_userId, _apiKey, _nonce, _apiSecret); } }

        [JsonProperty("nonce")]
        public string Nonce { get { return _nonce.ToString(); } }
    }
}
