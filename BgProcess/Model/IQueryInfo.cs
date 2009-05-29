using System;
namespace hz.web.Model
{
    interface IQueryInfo
    {
        int? channelId { get; set; }
        string content { get; set; }
        string extCode { get; set; }
        string mobileId { get; set; }
        DateTime? processDate { get; set; }
        decimal seqId { get; set; }
    }
}
