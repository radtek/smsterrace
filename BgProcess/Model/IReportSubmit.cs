using System;
namespace hz.web.Model
{
    interface IReportSubmit
    {
        int? channelId { get; set; }
        string mobileId { get; set; }
        string msgId { get; set; }
        string seqid { get; set; }
        int? state { get; set; }
        string stateDesc { get; set; }
    }
}
