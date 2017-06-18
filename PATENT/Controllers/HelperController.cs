using PATENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PATENT.Controllers
{
    public class HelperController : Controller
    {
        public ActionResult ShowHelperView()
        {
            return View("~/Views/Home/Resolver.cshtml", model: new HelpRequestObject());
        }

        public ActionResult GetHelperResult(HelpRequestObject helpRequestObject)
        {
            string answer = null;

            if (helpRequestObject.IsNewModel 
                && helpRequestObject.HaveInvLevel 
                && helpRequestObject.IsIndastryUsable
                && !helpRequestObject.IsIdea
                && !helpRequestObject.DoYouWantToShare)
            {
                answer = "По введенным параметрам больше подходит \"Патентирование полезной модели\"";

                if (helpRequestObject.IsProcessOrMethor 
                    || helpRequestObject.IsNotDesignOnly)
                {
                    answer = "По введенным параметрам больше подходит \"Патентирование изобретения\"";
                }                   
            }
            else if(helpRequestObject.DoYouWantToShare 
                || helpRequestObject.IsIdea)
            {
                answer = "По введенным параметрам больше подходит \"Получение авторского права на объект\"";
            }
            else
            {
                answer = "По введенным параметрам сложно определить ценность объекта для патентирования либо получения авторского права.";
            }

            string model = answer + ". Ответ не является заключением и мы рекомендуем Вам обратиться к консультанту для предоставления дополнительной информации. Спасибо.";

            return View("~/Views/Shared/WriteStringView.cshtml", model: model);
        }

    }
}