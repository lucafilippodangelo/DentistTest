﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MailClassLibrary
{
    public class CustomJwt
    {
        public string Appointment { get; set; }
        public String DateTime { get; set; }
        public String InternalKey { get; set; } //LD the internal key is used to add internal complexity to the token. Te logic set this attributed in the activity "ResetPasswordCustomReceive" of the "AccountController"

    }
}
