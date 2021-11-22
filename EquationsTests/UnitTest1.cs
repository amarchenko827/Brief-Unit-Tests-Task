using NUnit.Framework;
using Task1GemsDev;
namespace EquationsTests
{
    public class Tests
    {
        [Test]
        public void TestEquationKeyboard() // тест решения с помощью ввода данных
        {
            SquareEquations.EquationSolution(1, -2, -3);
            SquareEquations.EquationSolution(1, 4, 4);
            SquareEquations.EquationSolution(-8.2, -1, -5);

            Assert.Pass();
        }

        [Test]
        public void TestEquationFile() // тест решения с помощью ввода данных
        {
            DataGet.FileEquation();

            Assert.Pass();
        }
    }
}