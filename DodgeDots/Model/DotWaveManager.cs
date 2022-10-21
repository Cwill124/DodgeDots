using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DodgeDots.GameValues;

namespace DodgeDots.Model
{
    /// <summary>
    ///     A manager for the Dot Waves
    /// </summary>
    public class DotWaveManager
    {
        #region Data members

        private const int NorthWave = 0;
        private const int WestWave = 1;
        private const int SouthWave = 2;
        private const int EastWave = 3;
        private const int NorthBlitzWave = 5;
        private const int SouthBlitzWave = 4;
        
        private int northTickCount;
        private int southTickCount;
        private int westTickCount;
        private int eastTickCount;
        private readonly Canvas background;
        private int northblitzTickCount;
        private int southblitzblitzTickCount;
        private readonly int spawnrate = 60;
        /// <summary>Gets the timer.</summary>
        /// <value>The timer.</value>
        public DispatcherTimer Timer { get; }

        #endregion

        #region Properties

        /// <summary>Gets the waves.</summary>
        /// <value>The waves.</value>
        public IList<DotWave> Waves { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="DotWaveManager" /> class.</summary>
        public DotWaveManager(Canvas background)
        {
            
            this.Waves = new List<DotWave>();

            this.Timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10)
            };
            this.Timer.Start();
            this.Timer.Tick += this.Timer_Tick;
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
            this.Waves.Add(new DotWave(Direction.North, this.background));
            this.Waves.Add(new DotWave(Direction.West, this.background));
            this.Waves.Add(new DotWave(Direction.South, this.background));
            this.Waves.Add(new DotWave(Direction.East, this.background));
            this.Waves.Add(new DotWave(Direction.BlitzSouth, this.background));
            this.Waves.Add(new DotWave(Direction.BlitzNorth, this.background));

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
            foreach (var currentDotWave in this.Waves)
            {
                currentDotWave.CreateDot();
            }
        }

        /// <summary>Starts the north wave.</summary>
        public void StartNorthWave()
        {
            if (this.northTickCount >= this.spawnrate)
            {
                this.Waves[NorthWave].CreateDot();
                this.northTickCount = 0;
            }
        }

        /// <summary>Starts the south wave.</summary>
        public void StartSouthWave()
        {
            if (this.southTickCount >= this.spawnrate)
            {
                this.Waves[SouthWave].CreateDot();
                this.southTickCount = 0;
            }
        }

        /// <summary>Starts the west wave.</summary>
        public void StartWestWave()
        {
            if (this.westTickCount >= this.spawnrate)
            {
                this.Waves[WestWave].CreateDot();
                this.westTickCount = 0;
            }
        }

        /// <summary>Starts the east wave.</summary>
        public void StartEastWave()
        {
            if (this.eastTickCount >= this.spawnrate)
            {
                this.Waves[EastWave].CreateDot();
                this.eastTickCount = 0;
            }
        }

        /// <summary>Starts the north blitz wave.</summary>
        public void StartNorthBlitzWave()
        {
            if (this.northblitzTickCount >= this.spawnrate)
            {
                this.Waves[NorthBlitzWave].CreateDot();
                this.northblitzTickCount = 0;
            }
        }

        /// <summary>Starts the south blitz wave.</summary>
        public void StartSouthBlitzWave()
        {
            if (this.southblitzblitzTickCount >= this.spawnrate)
            {
                this.Waves[SouthBlitzWave].CreateDot();
                this.southblitzblitzTickCount = 0;
            }
        }

        /// <summary>Manages the dot wave.</summary>
        /// <param name="index">The index.</param>
        public void ManageDotWave(int index)
        {
            IList<EnemyDot> toRemove = new List<EnemyDot>();
            foreach (var currentDot in this.Waves[index].Dots)
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
                this.Waves[index].Dots.Remove(currentEnemyDot);
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