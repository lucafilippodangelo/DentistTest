﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MailClassLibrary
{
    public class CustomInfo
    {
        public Guid UserId { get; set; }
        public Guid AppointmentId { get; set; }
        public int ActionEnumerator { get; set; }
        public DateTime DateTime { get; set; }

        public string urlRouteConfirm { get; set; }
        public string urlRouteCallMaBack { get; set; }
        public string urlRouteCancel { get; set; }

        public string InternalKey { get; set; } //LD the internal key is used to add internal complexity to the token. Te logic set this attributed in the activity "ResetPasswordCustomReceive" of the "AccountController"

    }
}
