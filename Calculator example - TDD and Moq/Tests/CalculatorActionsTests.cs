using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Calculator_example___TDD_and_Moq.Actions;
using Calculator_example___TDD_and_Moq.Intefaces;
using Moq;
using Xunit;

namespace Calculator_example___TDD_and_Moq.Tests
{
    public class CalculatorActionsTests
    {
        [Fact]
        public async Task return_true_if_when_the_result_of_divison_is_a_whole_number()
        {

            var moqCalculatorActions = new Mock<ICalculatorFunctions>();

            moqCalculatorActions.Setup(x => x.PerformDivision(It.IsAny<double>(), It.IsAny<double>())).Returns(8);

            var actions = new CalculatorResultActions(moqCalculatorActions.Object);

            var result = actions.GetResultAndCheckIfItIsAnEvenNumber(64, 8, "division");

            Assert.True(result);
        }

        [Fact]
        public async Task throw_cannot_divide_by_zero_exception_if_method_is_division()
        {
            var moqCalculatorActions = new Mock<ICalculatorFunctions>();

            var actions = new CalculatorResultActions(moqCalculatorActions.Object);

            Assert.Throws<CannotDivideByZeroException>(() => actions.GetResultAndCheckIfItIsAnEvenNumber(It.IsAny<double>(), 0, "division"));

        }

        [Theory]
        [InlineData(2.5,3,false)]
        [InlineData(7, 3, true)]
        [InlineData(1.8, 2.2, true)]
        public async Task check_if_result_matches_inline_theory_for_different_scenarios_when_method_is_addition(double firstNumber, double secondNumber, bool expected)
        {

            var moqCalculatorActions = new Mock<ICalculatorFunctions>();

            var expectedResult = firstNumber + secondNumber;

            moqCalculatorActions.Setup(x => x.PerformAddition(firstNumber, secondNumber)).Returns(expectedResult);

            var actions = new CalculatorResultActions(moqCalculatorActions.Object);

            var result = actions.GetResultAndCheckIfItIsAnEvenNumber(firstNumber, secondNumber, "addition");

            Assert.Equal(result,expected);
        }

        [Theory]
        [InlineData(19, 3, false)]
        [InlineData(6, 3, true)]
        [InlineData(11, 2.2, true)]
        public async Task check_if_result_matches_inline_theory_for_different_scenarios_when_method_is_division(double firstNumber, double secondNumber, bool expected)
        {

            var moqCalculatorActions = new Mock<ICalculatorFunctions>();

            var expectedResult = firstNumber / secondNumber;

            moqCalculatorActions.Setup(x => x.PerformDivision(firstNumber, secondNumber)).Returns(expectedResult);

            var actions = new CalculatorResultActions(moqCalculatorActions.Object);

            var result = actions.GetResultAndCheckIfItIsAnEvenNumber(firstNumber,secondNumber, "division");

            Assert.Equal(result, expected);
        }


            //Write a test case for a new method within the action class. The method should be taking two parameters and should be calling the
            // "PerformAddition" action and returning the result of it.

      
    }
}