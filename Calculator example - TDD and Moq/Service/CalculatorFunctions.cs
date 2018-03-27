using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Calculator_example___TDD_and_Moq.Intefaces;

namespace Calculator_example___TDD_and_Moq.Actions
{
    public class CalculatorFunctions : ICalculatorFunctions
    {
        public double PerformDivision(double firstNumber, double secondNumber)
        {
           return firstNumber / secondNumber;
        }

        public double PerformAddition(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}