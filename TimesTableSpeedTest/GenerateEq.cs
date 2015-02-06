using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimesTableSpeedTest
{
    class GenerateEq
    {
        public static IEnumerable<Equation> GenerateEquations(List<int> leftInts, Operation operation, List<int> rightInts)
        {
            foreach (int i in leftInts)
            {
                foreach (int j in rightInts)
                {
                    Equation equation = new Equation();
                    float answer = 0;
                    switch (operation)
                    {
                        case Operation.Multiply:
                            answer = i * j;
                            break;
                        case Operation.Divide:
                            answer = i / j;
                            break;
                        case Operation.Add:
                            answer = i + j;
                            break;
                        case Operation.Subtract:
                            answer = i - j;
                            break;
                    }
                    equation.leftTerm = i;
                    equation.rightTerm = j;
                    equation.operation = operation;
                    equation.answer = answer;
                    yield return equation;
                }
            }
        }
    }
}
