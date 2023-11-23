using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger_v2.Models;

namespace ZeroHunger_v2.Annotations
{
    public class UniqueUsername : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            var username = value.ToString();


            var db = new ZeroHungerContainer();

            var data = db.Users.SingleOrDefault(u => u.Username == username);

            /*var data = (from u in db.Users
                        where u.Username == username
                        select u).SingleOrDefault();*/
            if (data == null)
            {
                return true;
            }
            return false;





        }
    }
}