using System.Collections.Generic;

namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
        private readonly IDictionary<char, IStrategy> strategies = new Dictionary<char, IStrategy>
        {
            { '+', new AdditionStrategy() },
            { '-', new SubtractionStrategy() },
            { '*', new MultiplicationStrategy() },
            { '/', new DivisionStrategy() }
        };

        private IStrategy strategy;

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ChangeStrategy(char @operator)
        {
            this.strategy = this.strategies[@operator];
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
