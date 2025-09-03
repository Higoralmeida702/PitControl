using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PitControl.Application.Dto;

namespace PitControl.Application.Services
{
    public class ViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoDto> GetEnderecoByCep(string cep)
        {
            var data = await _httpClient.GetFromJsonAsync<EnderecoDto>(
                $"https://viacep.com.br/ws/{cep}/json/"
            );

            return data;
        }
    }
}
