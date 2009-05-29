using System;
using System.Collections.Generic;
using System.Text;

namespace hz.sms.Model
{
   public class QueryInfo
    {
        private decimal _seqid;
		private string _mobileid;
		private string _extcode;
		private int? _channelid;
		private string _content;
		private DateTime? _processdate;
		/// <summary>
		/// 
		/// </summary>
		public decimal seqId
		{
			set{ _seqid=value;}
			get{return _seqid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobileId
		{
			set{ _mobileid=value;}
			get{return _mobileid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string extCode
		{
			set{ _extcode=value;}
			get{return _extcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? channelId
		{
			set{ _channelid=value;}
			get{return _channelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? processDate
		{
			set{ _processdate=value;}
			get{return _processdate;}
		}
	

	
    }
}
