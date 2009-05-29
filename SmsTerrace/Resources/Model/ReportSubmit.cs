using System;
using System.Collections.Generic;
using System.Text;

namespace hz.sms.Model
{
    /// <summary>
    /// 实体类report_submit 
    /// </summary>
    public class ReportSubmit
    {

        #region Model
        private string _seqid;

        public string seqid
        {
            get { return _seqid; }
            set { _seqid = value; }
        }
        private string _msgid;
        private string _mobileid;
        private int? _state;
        private int? _channelid;
        private string _statedesc;
       
        /// <summary>
        /// 
        /// </summary>
        public string msgId
        {
            set { _msgid = value; }
            get { return _msgid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mobileId
        {
            set { _mobileid = value; }
            get { return _mobileid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? channelId
        {
            set { _channelid = value; }
            get { return _channelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stateDesc
        {
            set { _statedesc = value; }
            get { return _statedesc; }
        }
        #endregion Model

    }
}

