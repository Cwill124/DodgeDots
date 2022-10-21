using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DodgeDots.GameValues;

namespace DodgeDots.Model
{
    /// <summary>
    ///     A manager for the Dot waves
    /// </summary>
    public class DotWaveManager
    {
        #region Data members

        private const int NorthWave = 0;
        private const int WestWave = 1;
        private const int SouthWave = 2;
        private const int EastWave = 3;
        private readonly DispatcherTimer timer;
        private int northTickCount;
        private int southTickCount;
        private int westTickCount;
        private int eastTickCount;
        private readonly Canvas background;
        private int northblitzTickCount;
        private int southblitzblitzTickCount;
        private readonly int spawnrate = 60;
        

        #endregion

        #region Properties

        public IList<DotWave> waves { get; }

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
            this.westTickCount = 0;
            this.eastTickCount = 0;
            this.northblitzTickCount = 0;
            this.southblitzblitzTickCount = 0;

            this.background = background;
            this.addDotWaves();
        }

        #endregion

        #region Methods

        private void addDotWaves()
        {
            this.waves.Add(new DotWave(Direction.North, this.background));
            this.waves.Add(new DotWave(Direction.West, this.background));
            this.waves.Add(new DotWave(Direction.South, this.background));
            this.waves.Add(new DotWave(Direction.East, this.background));
            this.waves.Add(new DotWave(Direction.BlitzSouth, this.background));
            this.waves.Add(new DotWave(Direction.BlitzNorth, this.background));


            this.populateDotWave();
        }

        private void Timer_Tick(object sender, object e)
        {
            this.northTickCount++;
            this.southTickCount++;
            this.westTickCount++;
            this.eastTickCount++;
            this.northblitzTickCount++;
            this.southblitzblitzTickCount++;
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
            if (this.northTickCount >= this.spawnrate)
            {
                this.waves[0].CreateDot();
                this.northTickCount = 0;
            }
        }

        public void StartSouthWave()
        {
            if (this.southTickCount >= this.spawnrate)
            {
                this.waves[2].CreateDot();
                this.southTickCount = 0;
            }
        }

        public void StartWestWave()
        {
            if (this.westTickCount >= this.spawnrate)
            {
                this.waves[1].CreateDot();
                this.westTickCount = 0;
            }
        }

        public void StartEastWave()
        {
            if (this.eastTickCount >= this.spawnrate)
            {
                this.waves[3].CreateDot();
                this.eastTickCount = 0;
            }
        }

        public void StartNorthBlitzWave()
        {
            if (this.northblitzTickCount >= this.spawnrate)
            {
                this.waves[5].CreateDot();
                this.northblitzTickCount = 0;
            }
        }
        public void StartSouthBlitzWave()
        {
            if (this.southblitzblitzTickCount >= this.spawnrate)
            {
                this.waves[4].CreateDot();
                this.southblitzblitzTickCount = 0;
            }
        }

        public void manageDotWave(int index)
        {
            IList<EnemyDot> toRemove = new List<EnemyDot>();
            foreach (var currentDot in this.waves[index].dots)
            {
                this.moveDotWave(index, currentDot);
                if (this.checkToRemoveDot(index, currentDot))
                {
                    toRemove.Add(currentDot);
                }
            }

            this.removeOffScreenDot(index, toRemove);
        }

        private void removeOffScreenDot(int index, IList<EnemyDot> toRemove)
        {
            foreach (var currentEnemyDot in toRemove)
            {
                this.waves[index].dots.Remove(currentEnemyDot);
            }
        }

        private bool checkToRemoveDot(int index, EnemyDot currentDot)
        {
            var remove = false;
            var towardsPositiveBorder = 430;
            var towardsNegativeBorder = -30;
            switch (index)
            {
                case NorthWave:
                {
                    if (currentDot.Y > towardsPositiveBorder)
                    {
                        this.background.Children.Remove(currentDot.Sprite);
                        remove = true;
                    }

                    break;
                }
                case WestWave:
                {
                    if (currentDot.X > towardsPositiveBorder)
                    {
                        this.background.Children.Remove(currentDot.Sprite);
                        remove = true;
                    }

                    break;
                }
                case SouthWave:
                {
                    if (currentDot.Y < towardsNegativeBorder)
                    {
                        this.background.Children.Remove(currentDot.Sprite);
                        remove = true;
                    }

                    break;
                }
                case EastWave:
                {
                    if (currentDot.X < towardsNegativeBorder)
                    {
                        this.background.Children.Remove(currentDot.Sprite);
                        remove = true;
                    }

                    break;
                }
            }

            return remove;
        }

        private void moveDotWave(int index, EnemyDot currentDot)
        {
            if (index == NorthWave || index == 5)
            {
                currentDot.MoveDown();
            }
            else if (index == WestWave)
            {
                currentDot.MoveRight();
            }
            else if (index == SouthWave || index == 4)
            {
                currentDot.MoveUp();
            }
            else
            {
                currentDot.MoveLeft();
            }
        }

        #endregion
    }
}