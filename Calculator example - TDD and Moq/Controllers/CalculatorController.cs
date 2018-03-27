using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Calculator_example___TDD_and_Moq.Actions;
using Calculator_example___TDD_and_Moq.Intefaces;

namespace Calculator_example___TDD_and_Moq.Controllers
{
   public class CalculatorController : ApiController
    {
        public ICalculatorFunctions _calculatorActions;
        public CalculatorController()
        {
            _calculatorActions = new CalculatorFunctions();
        }
       
        [HttpGet]
       public bool isResultEven(double firstNumber, double secondNumber, string method)
        {
            var calculateResultActions = new CalculatorResultActions(_calculatorActions);

            var result = calculateResultActions.GetResultAndCheckIfItIsAnEvenNumber(firstNumber, secondNumber, method);

            return result;
        }

    }

  
}