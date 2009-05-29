using System;
using System.Collections.Generic;
using System.Text;
using hz.sms.DAL;
using hz.sms.Model;

namespace hz.sms.BLL
{
    public class UserManage
    {
        private SmsUserService userDal = new SmsUserService();
        public SmsUser GetUserInfo(string userId)
        {
            return userDal.GetModel(userId);
        }
      public  SmsUser ValidateUser(string userId, string pwd)
        {
            SmsUser user = GetUserInfo(userId);
            if (user.password.Equals(pwd))
            {
                return user;
            }
            return null;
        }
    }
}
