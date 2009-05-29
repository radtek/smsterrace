
using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;

namespace hz.sms.Comm
{
    public class QueueManage
    {
       static public string SendQueuePath =@".\private$\cmdSms";
       static public  string ReceiveQueuePath = @".\private$\cmdSms";
        ///
        /// 发送对象到队列中
        ///
        ///
        //队列名称，最好写在配置文件中
        ///
        //要发出去的对象
        public static void SendQueue(string QueuePath, object sq)
        {
            System.Messaging.MessageQueue mqSend = new System.Messaging.MessageQueue(QueuePath, false);
            EnsureQueueExists(QueuePath);
            mqSend.Send(sq);
        }
        ///
        /// 检查队列，如果队列不存在，则建立
        ///
        ///
        //队列名称
        private static void EnsureQueueExists(string path)
        {
            if (!MessageQueue.Exists(path))
            {
                if (!MessageQueue.Exists(path))
                {
                    MessageQueue.Create(path);
                    MessageQueue mqTemp = new MessageQueue(path); 
                    mqTemp.SetPermissions("Everyone", System.Messaging.MessageQueueAccessRights.FullControl);
                    ///给了Everone全部权限,最好自己控制一下
                }
            }
        }
      /// <summary>从队列中复制出所有信息，
      /// 
      /// </summary>
      /// <param name="QueuePath"></param>
      /// <returns></returns>
        public static System.Collections.ArrayList GetMessage(string QueuePath)
        {
            string sq = null;
            System.Messaging.MessageQueue mq = new System.Messaging.MessageQueue(QueuePath, false);
            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            System.Messaging.Message[] arrM = mq.GetAllMessages();
            mq.Close();
            System.Collections.ArrayList al = new System.Collections.ArrayList();
            foreach (System.Messaging.Message m in arrM)
            {   
                sq = (string)m.Body;
                al.Add(sq);
            }
            //mq.Purge();
            return al;
        }
   
        public static string StartGet(string path)
        {
            System.Messaging.MessageQueue mq = new System.Messaging.MessageQueue(path, true);
                 mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            mq.ReceiveCompleted+=new ReceiveCompletedEventHandler(mq_ReceiveCompleted);
            mq.BeginReceive();
            return "";
            
        }

        static void mq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            Console.WriteLine(sender.ToString() + "===" + e.Message.Body.ToString());
            (sender as System.Messaging.MessageQueue).BeginReceive();
        }

       }
}