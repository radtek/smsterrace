using System;
using System.Collections.Generic;
using System.Text;

namespace hz.sms.Model
{    /// <summary>
	/// 实体类mo_pending_deal 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    public class MoPendingDeal
    {
        private string _seqid;

    public MoPendingDeal()
    {
    }
        public MoPendingDeal(string _seqid, string _mobileid, string _extcode, int? _channelid, string _content, DateTime? _processdate)
        {
            this._seqid = _seqid;
            this._mobileid = _mobileid;
            this._extcode = _extcode;
            this._channelid = _channelid;
            this._content = _content;
            this._processdate = _processdate;
        }

    public string Seqid
        {
            get { return _seqid; }
            set { _seqid = value; }
        }
		private string _mobileid;
		private string _extcode;
		private int? _channelid;
		private string _content;
		private DateTime? _processdate;
		
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
