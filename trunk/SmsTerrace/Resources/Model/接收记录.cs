using System;
namespace SmsTerrace.Model
{
	/// <summary>
	/// ʵ������ռ�¼ ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class ���ռ�¼
	{
		public ���ռ�¼()
		{}
		#region Model
		private string _��ע;
		private int? _���;
		private string _������;
		private string _������;
		private string _����;
		private string _ʱ��;
		/// <summary>
		/// 
		/// </summary>
		public string ��ע
		{
			set{ _��ע=value;}
			get{return _��ע;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ���
		{
			set{ _���=value;}
			get{return _���;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ������
		{
			set{ _������=value;}
			get{return _������;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ������
		{
			set{ _������=value;}
			get{return _������;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ����
		{
			set{ _����=value;}
			get{return _����;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ʱ��
		{
			set{ _ʱ��=value;}
			get{return _ʱ��;}
		}
		#endregion Model

	}
}

