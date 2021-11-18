using NUnit.Framework;
using Task1GemsDev;
using System;
using System.IO;

namespace EquationsTests
{
    public class Tests
    {
        [Test]
        public void TestEquationKeyboard() // ���� ������� � ������� ����� ������
        {
            SquareEquations.EquationKeyboard(1, -2, -3);
            SquareEquations.EquationKeyboard(1, 4, 4);
            SquareEquations.EquationKeyboard(-8.2, -1, -5);

            Assert.Pass();
        }

        [Test]
        public void TestEquationFile() // ���� ������� � ������� ������ �� �����
        {
            //arrange

            //act
            SquareEquations eq = new SquareEquations();
            SquareEquations.EquationFile();

            //assert
            Assert.Pass();
        }
    }
}