﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZeroHunger_v2.Models;

namespace ZeroHunger_v2.Annotations
{
    public class GreaterTime : ValidationAttribute
    {

        public override bool IsValid(object value)
        {

            var MaxTime = (DateTime)value;



            if (MaxTime > DateTime.Now)
            {
                return true;
            }
            return false;





        }
    }
}