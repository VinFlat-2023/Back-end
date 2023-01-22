#region

using Newtonsoft.Json;

#endregion

namespace Domain.CustomEntities.MomoEntities;

public class MomoEntity
{
    [JsonProperty("partnerCode")] public string PartnerCode { get; set; }
    [JsonProperty("partnerName")] public string PartnerName { get; set; }
    [JsonProperty("storeId")] public string StoreId { get; set; }
    [JsonProperty("requestType")] public string RequestType { get; set; }
    [JsonProperty("ipnUrl")] public string IpnUrl { get; set; }
    [JsonProperty("redirectUrl")] public string RedirectUrl { get; set; }
    [JsonProperty("orderId")] public string OrderId { get; set; }
    [JsonProperty("amount")] public int Amount { get; set; }
    [JsonProperty("lang")] public string Lang { get; set; }
    [JsonProperty("orderInfo")] public string OrderInfo { get; set; }
    [JsonProperty("requestId")] public string RequestId { get; set; }
    [JsonProperty("extraData")] public string ExtraData { get; set; }
    [JsonProperty("signature")] public string Signature { get; set; }
}