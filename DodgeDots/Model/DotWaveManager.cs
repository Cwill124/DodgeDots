using System.Collections.Generic;
using DodgeDots.GameValues;

namespace DodgeDots.Model
{
    /// <summary>
    ///     A manager for the Dot waves
    /// </summary>
    public class DotWaveManager
    {
        #region Data members

        public IList<DotWave> waves { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="DotWaveManager" /> class.</summary>
        public DotWaveManager()
        {
            this.waves = new List<DotWave>();
            this.addDotWaves();
        }

        #endregion

        #region Methods

        private void addDotWaves()
        {
            this.waves.Add(new DotWave(DirectionFacing.South));
            this.waves.Add(new DotWave(DirectionFacing.West));
            this.waves.Add(new DotWave(DirectionFacing.North));
            this.waves.Add(new DotWave(DirectionFacing.East));

            this.populateDotWave();
        }

        private void populateDotWave()
        {
            foreach (var currentDotWave in this.waves)
            {
                currentDotWave.CreateDots();
            }
        }

        #endregion
    }
}