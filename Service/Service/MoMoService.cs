#region

using System.Net;
using System.Text;
using Domain.CustomEntities.MomoEntities;
using Newtonsoft.Json;
using Service.IService;

#endregion

namespace Service.Service;

public class MoMoService : IMoMoService
{
    private const string MOMO_BASE_URL = "https://test-payment.momo.vn/v2/gateway/api/";
    private const string CREATE_MOMO = "create";
    private readonly IHttpClientFactory _clientFactory;

    public MoMoService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<MomoResponseEntity> GetMomoResponseEntity(MomoEntity request)
    {
        try
        {
            var createUrl = MOMO_BASE_URL + CREATE_MOMO;
            var resquestJson = new StringContent(JsonConvert.SerializeObject(request, Formatting.Indented),
                Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient();
            var httpResponse = await client.PostAsync(createUrl, resquestJson);
            httpResponse.EnsureSuccessStatusCode();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var momoResponse = JsonConvert.DeserializeObject<MomoResponseEntity>(responseString);
                return momoResponse;
            }
            else
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var pois = JsonConvert.DeserializeObject<MomoResponseEntity>(responseString);
                return pois;
            }
        }
        catch (Exception e)
        {
            return new MomoResponseEntity
            {
                Message = e.Message
            };
        }
    }
}