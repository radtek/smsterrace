using System;
using System.Collections.Generic;
namespace hz.sms.Model
{
    /// <summary>
    /// 实体类SmsUser 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SmsUser
    {
        public SmsUser()
        { }
        #region Model
        private string _userid;
        private int? _paytype;
        private int? _repaytype;
        private int? _logflag;
        private int? _state;
        private string _oemid;
        private string _parentuserid;
        private int? _groupid;
        private DateTime? _processdate;
        private int? _agentlevel;
        private string _username;
        private string _password;
        private string _agentpass;
        private string _corpsign;
        private string _corporation;
        private string _province;
        private string _phone;
        private string _linkman;
        /// <summary>
        /// 
        /// </summary>
        public string userId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? payType
        {
            set { _paytype = value; }
            get { return _paytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? repayType
        {
            set { _repaytype = value; }
            get { return _repaytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? logFlag
        {
            set { _logflag = value; }
            get { return _logflag; }
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
        public string oemId
        {
            set { _oemid = value; }
            get { return _oemid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string parentUserId
        {
            set { _parentuserid = value; }
            get { return _parentuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? groupId
        {
            set { _groupid = value; }
            get { return _groupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? processDate
        {
            set { _processdate = value; }
            get { return _processdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? agentLevel
        {
            set { _agentlevel = value; }
            get { return _agentlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string agentPass
        {
            set { _agentpass = value; }
            get { return _agentpass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string corpSign
        {
            set { _corpsign = value; }
            get { return _corpsign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string corporation
        {
            set { _corporation = value; }
            get { return _corporation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string linkman
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        #endregion Model

        private List<Business> _businesss;
        /// <summary>
        /// 子类 
        /// </summary>
        public List<Business> Businesss
        {
            set { _businesss = value; }
            get { return _businesss; }
        }

    }
    /// <summary>
    /// 实体类Business 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Business
    {
        public Business()
        { }
        #region Model
        private string _userid;
        private int _businessid;
        private int? _priority;
        private decimal? _price;
        private int _channelid;
        private int? _feetype;
        private int? _channelgroupid;
        private int? _flag;
        private decimal? _useablecount;
        /// <summary>
        /// 
        /// </summary>
        public string userId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int businessId
        {
            set { _businessid = value; }
            get { return _businessid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? priority
        {
            set { _priority = value; }
            get { return _priority; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int channelId
        {
            set { _channelid = value; }
            get { return _channelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? feeType
        {
            set { _feetype = value; }
            get { return _feetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? channelGroupId
        {
            set { _channelgroupid = value; }
            get { return _channelgroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? useableCount
        {
            set { _useablecount = value; }
            get { return _useablecount; }
        }
        #endregion Model

    }
}

