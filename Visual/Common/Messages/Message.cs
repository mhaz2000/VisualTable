﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Messages
{
    //A class for messages.
    public class Message
    {
        public static string RepetitiveTableName()
        {
            return "این نام قبلا استفاده شده است!";
        }
        public static string AcceptableName()
        {
            return "استفاده از این نام مجاز است.";
        }
    }
}
