using System;
using System.Collections.Generic;
using System.Diagnostics;
using DodgeDots.GameValues;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DodgeDots.Model
{
    /// <summary>
    ///     A manager for the Dot waves
    /// </summary>
    public class DotWaveManager
    {
        #region Data members

        public IList<DotWave> waves { get; }
        private readonly DispatcherTimer timer;
        private int northTickCount;
        private int southTickCount;
        private Canvas background;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="DotWaveManager" /> class.</summary>
        public DotWaveManager(Canvas background)
        {
            this.waves = new List<DotWave>();
            this.timer = new DispatcherTimer();
            this.timer.Tick += this.Timer_Tick;
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            this.timer.Start();
            this.northTickCount = 0;
            this.southTickCount = 0;

            this.background = background;
            Debug.WriteLine(this.background.ToString());
             this.addDotWaves();
        }

        #endregion

        #region Methods

        private void addDotWaves()
        {   this.waves.Add(new DotWave(Direction.North,this.background));
            this.waves.Add(new DotWave(Direction.West,this.background));
            this.waves.Add(new DotWave(Direction.South,this.background));
            this.waves.Add(new DotWave(Direction.East,this.background));

            this.populateDotWave();
        }
        private void Timer_Tick(object sender, object e)
        {
            this.northTickCount++;
            this.southTickCount++;
        }
        private void populateDotWave()
        {
            foreach (var currentDotWave in this.waves)
            {
                currentDotWave.CreateDot();
            }
        }
        public void StartNorthWave()
        {
            if (this.northTickCount >= 40)
            {
                this.waves[0].CreateDot();
                this.northTickCount = 0;
            }
            
            
            
        }
        public void StartSouthWave()
        {
            if (this.southTickCount >= 40)
            {
                this.waves[2].CreateDot();
                this.southTickCount = 0;
            }



        }
        #endregion
    }
}