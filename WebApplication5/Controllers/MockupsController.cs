using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class MockupsController : Controller
    {

      

        [HttpGet]
        public IActionResult Quiz()
        {
            QuizModel qModel = QuizModel.Instance;
            qModel.Reset();
            qModel.Start();

            
            return View(qModel);
        }

        [HttpPost]
        public IActionResult Quiz(QuizModel qModel, string action)
        {
            qModel = QuizModel.Instance;

            if (ModelState.IsValid)

            {
                qModel.UserAnswer = Int32.Parse(Request.Form["UserAnswer"]);
                qModel.Jeck();
                


                if (action == "Next")
                {
                    QuizModel quModel = QuizModel.Instance;
                    quModel.Start();

                    return View(quModel);
                }
                return RedirectToAction("QuizResult");
            }
            else
            {
               
                QuizModel quModel = QuizModel.Instance;
                return View(quModel);
            }

        }
        public IActionResult QuizResult()
        {
            QuizModel qModel = QuizModel.Instance;
            ViewBag.Result = qModel.AllAnswers;
            ViewData["Total"] = "" + qModel.Count;
            ViewData["Correct"] = "" + qModel.CountOfRightAnswers;
            return View();
        }


    
    }
}