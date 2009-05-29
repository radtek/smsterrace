using System;
namespace SmsTerrace.Model
{
	/// <summary>
	/// 实体类接收记录 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class 接收记录
	{
		public 接收记录()
		{}
		#region Model
		private string _备注;
		private int? _编号;
		private string _发送人;
		private string _接收人;
		private string _内容;
		private string _时间;
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
		public string 发送人
		{
			set{ _发送人=value;}
			get{return _发送人;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 接收人
		{
			set{ _接收人=value;}
			get{return _接收人;}
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
		#endregion Model

	}
}

