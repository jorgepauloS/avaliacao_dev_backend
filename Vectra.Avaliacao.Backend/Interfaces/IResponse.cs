using System.Net;
using System.Threading.Tasks;
using Vectra.Avaliacao.Backend.DTOs;

namespace Vectra.Avaliacao.Backend.Interfaces
{
    public interface IResponse
    {
        void AddErrorMessages(string message);
        Task<Response> GenerateResponse(HttpStatusCode statusCode = HttpStatusCode.OK, bool hasError = default, string message = default, object data = default);
    }
}
