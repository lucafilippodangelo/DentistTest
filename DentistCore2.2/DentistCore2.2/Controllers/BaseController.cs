using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailClassLibrary;
using Microsoft.AspNetCore.Mvc;

namespace LdDevWebApp.Controllers
{
    public class BaseController : Controller
    {
        /*
         ALERT TYPE START
         These methods are going to help us record and render alerts from our controller and into our views.
        */
        public void Success(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message, dismissable);
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Danger, message, dismissable);
        }


        /*
         ADD ALERT
         The AddAlert method takes care of fetching or creating a list of alerts. 
        */
        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey) ? (List<Alert>)TempData[Alert.TempDataKey] : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[Alert.TempDataKey] = alerts;
        }

    }
}


