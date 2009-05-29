using System;
namespace SmsTerrace.Model
{
	/// <summary>
	/// 实体类短信记录 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class 短信记录
	{
		public 短信记录()
		{}
		#region Model
		private string _备注;
		private int? _编号;
		private string _号码;
		private string _内容;
		private string _时间;
		private string _状态;
		/// <summary>
		/// 
		/// </summary>
		public string 备注
		{
			set{ _备注=value;}
			get{return _备注;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? 编号
		{
			set{ _编号=value;}
			get{return _编号;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 号码
		{
			set{ _号码=value;}
			get{return _号码;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 内容
		{
			set{ _内容=value;}
			get{return _内容;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 时间
		{
			set{ _时间=value;}
			get{return _时间;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 状态
		{
			set{ _状态=value;}
			get{return _状态;}
		}
		#endregion Model

	}
}

