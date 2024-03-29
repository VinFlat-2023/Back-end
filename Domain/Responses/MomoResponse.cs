﻿namespace Domain.Responses;

public class MomoResponse
{
    public string PartnerCode { get; set; }
    public string OrderId { get; set; }
    public string RequestId { get; set; }
    public int Amount { get; set; }
    public long ResponseTime { get; set; }
    public string Message { get; set; }
    public int ResultCode { get; set; }
    public string PayUrl { get; set; }
}