using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_example___TDD_and_Moq.Intefaces
{
    public interface ICalculatorFunctions
    {
        double PerformDivision(double firstNumber, double secondNumber);
        double PerformAddition(double firstNumber, double secondNumber);
    }
}
