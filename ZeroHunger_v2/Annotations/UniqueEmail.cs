using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZeroHunger_v2.Models;

namespace ZeroHunger_v2.Annotations
{
    public class UniqueEmail : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            var email = value.ToString();


            var db = new ZeroHungerContainer();
            var data = (from u in db.Users
                        where u.Email == email
                        select u).SingleOrDefault();
            if (data == null)
            {
                return true;
            }
            return false;





        }
    }
}