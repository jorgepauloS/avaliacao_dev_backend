﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.Interfaces;

namespace Vectra.Avaliacao.Backend.DTOs
{
    public class Response : IResponse
    {
        [JsonProperty("errorMessages")]
        public IList<string> ErrorMessages { get; protected set; } = new List<string>();
        [JsonProperty("hasErrors")]
        public bool HasErrors { get; protected set; }
        [JsonProperty("message")]
        public string Message { get; protected set; }
        [JsonProperty("statusCode")]
        public HttpStatusCode StatusCode { get; protected set; }
        [JsonProperty("data")]
        public object Data { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }

        public void AddErrorMessages(string message)
        {
            ErrorMessages.Add(message);
            HasErrors = true;
        }
        public Task<Response> GenerateResponse(HttpStatusCode statusCode = HttpStatusCode.OK, bool hasError = default, string message = default, object data = default)
        {
            StatusCode = statusCode;
            HasErrors = hasError;
            Message = message;
            Data = data;
            return Task.FromResult(this);
        }
    }
}
