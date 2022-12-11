using CementAndConcrete.BLL.Interfaces;
using CementAndConcrete.BLL.Strategies;
using CementAndConcrete.Domain.Enums;

namespace CementAndConcrete.BLL.Services.AlgorithmServices
{
    /// <summary>
    ///     A class that selects a strategy based on a user-selected type from the enum Algorithms.
    /// </summary>
    /// <owner>Oleg Novak</owner>
    public sealed class StrategyPicker
    {
        /// <summary>
        ///     Stores current algorithm strategy.
        /// </summary>
        public IAlgorithmStrategy? CurrentStrategy;

        /// <summary>
        ///     Stores the selected value of algorithm by user.
        /// </summary>
        private Algorithms selectedAlgorithm;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StrategyPicker" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        public StrategyPicker()
        {
            this.selectedAlgorithm = default;
            this.CurrentStrategy = this.ChooseStrategyAccordingSelectedAlgorithm();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StrategyPicker" /> class.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="selectedAlgorithmByUser">Contains selected value of algorithm by user </param>
        public StrategyPicker(Algorithms selectedAlgorithmByUser)
        {
            this.ChooseStrategyAccordingSelectedAlgorithm(selectedAlgorithmByUser);
        }

        /// <summary>
        ///     Selects an algorithm strategy based on the one stored in the class field selectedAlgorithm.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <returns>Return an algorithm strategy</returns>
        public IAlgorithmStrategy ChooseStrategyAccordingSelectedAlgorithm()
        {
            return this.selectedAlgorithm switch
            {
                Algorithms.Insert => this.CurrentStrategy = new InsertSortStrategy(),
                Algorithms.Merge => this.CurrentStrategy = new MergeSortStrategy(),
                Algorithms.Quick => this.CurrentStrategy = new QuickSortStrategy(),
                _ => throw new ArgumentOutOfRangeException(nameof(this.selectedAlgorithm), this.selectedAlgorithm, null)
            };
        }

        /// <summary>
        ///     Selects an algorithm strategy based on the incoming param selectedAlgorithmByUser.
        /// </summary>
        /// <owner>Oleg Novak</owner>
        /// <param name="selectedAlgorithmByUser">Contains selected value of algorithm by user</param>
        /// <returns>Return an algorithm strategy</returns>
        public IAlgorithmStrategy ChooseStrategyAccordingSelectedAlgorithm(Algorithms selectedAlgorithmByUser)
        {
            this.selectedAlgorithm = selectedAlgorithmByUser;

            return this.ChooseStrategyAccordingSelectedAlgorithm();
        }
    }
}