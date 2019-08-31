using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace DentistCore2._2.Utilities
{
    public class Rendering
    {
        /*
        public static string RenderPartialToString(string viewName, object model, ControllerContext ctrlc, ICompositeViewEngine _viewEngine)
        {
            //if (string.IsNullOrEmpty(viewName))
            //    viewName = Microsoft.AspNetCore.Mvc.ControllerContext.RouteData.GetRequiredString("action");

            ViewDataDictionary ViewData;
            //TempDataDictionary TempData = new Microsoft.AspNetCore.Mvc.ViewFeatures.TempDataDictionary(null,null);
            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                //ViewEngineResult viewResult = Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult FindView(ctrlc, viewName);
                ViewEngineResult viewResult = _viewEngine.FindView(ctrlc, viewName, false);

                ViewContext viewContext = new ViewContext(ctrlc, viewResult.View, ViewData, null, sw, null);
                
                //viewResult.View.Render(viewContext, sw);
                viewResult.View.RenderAsync(viewContext);

                //return sw.GetStringBuilder().ToString();
            }

            //TEST

            var view = _viewEngine.FindView(ctrlc, viewName, true).View;

            var writer = new StringWriter();

            var viewContext = new ViewContext(
                ctrlc, view, ViewData,
                TempData, writer, new HtmlHelperOptions()
            );

            await view.RenderAsync(viewContext);

            return writer.ToString();



        }*/
    }
    
}



