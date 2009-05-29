using System;
using hz.sms.Model;
namespace hz.sms.BLL
{
   public interface ISmsSendSession
    {
        event EventSession DealWithBegin;
        event EventSession DealWithEnd;
        void LoopSend();
        void ResultDealWith(hz.sms.Model.SmsSessionInfo smsSessionInfo);
        event EventSession SendBegin;
        void SendData();
        event EventSession SendEnd;
        string SendSms(hz.sms.Model.SmsSessionInfo smsSessionInfo);
        event EventSessionError SessionError;
        int ThreadNum { get; }
        string CreateUrl(SmsSessionInfo smsSessionInfo);
    }
}
