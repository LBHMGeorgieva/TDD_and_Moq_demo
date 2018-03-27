using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calculator_example___TDD_and_Moq.Intefaces;

namespace Calculator_example___TDD_and_Moq.Actions
{
    public class CalculatorResultActions
    {
        public ICalculatorFunctions _calculatorActions;
        public CalculatorResultActions(ICalculatorFunctions calculatorActions)
        {
            _calculatorActions = calculatorActions;
        }

        public bool GetResultAndCheckIfItIsAnEvenNumber(double firstNumber, double secondNumber, string method)
        {
            double? result = null;
            switch (method)
            {
                case "addition":
                    result =  _calculatorActions.PerformAddition(firstNumber, secondNumber);
                    break;
                case "division":
                    if (secondNumber == 0)
                    {
                        throw new CannotDivideByZeroException();
                    }
                    result = _calculatorActions.PerformDivision(firstNumber, secondNumber);
                    break;
            }

            return result % 1 == 0;

        }

    }

    public class CannotDivideByZeroException : Exception
    {
    }
}