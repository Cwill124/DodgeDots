using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DodgeDots.Model
{
    /// <summary>
    ///     Manages the entire game.
    /// </summary>
    public class GameManager
    {
        #region Data members

        private const int NorthWave = 0;
        private const int WestWave = 1;
        private const int SouthWave = 2;
        private const int EastWave = 3;
        private const int FiveSeconds = 5;
        private const int TenSeconds = 10;
        private const int FiftteenSeconds = 15;
        private const int TwentyfiveSeconds = 25;
        private readonly double backgroundHeight;
        private readonly double backgroundWidth;

        private Player player;

        private readonly DispatcherTimer timer;

        private readonly DispatcherTimer winTimer;

        private readonly Random random;

        private Canvas canvas;

        private DotWaveManager dotWaveManager;

        private int tickCount;

        private int winTickCount;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameManager" /> class.
        ///     Precondition: backgroundHeight > 0 AND backgroundWidth > 0
        /// </summary>
        /// <param name="backgroundHeight">The backgroundHeight of the game play window.</param>
        /// <param name="backgroundWidth">The backgroundWidth of the game play window.</param>
        public GameManager(double backgroundHeight, double backgroundWidth)
        {
            if (backgroundHeight <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(backgroundHeight));
            }

            if (backgroundWidth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(backgroundWidth));
            }

            this.canvas = null;
            this.random = new Random();
            this.backgroundHeight = backgroundHeight;
            this.backgroundWidth = backgroundWidth;
            this.dotWaveManager = null;
            this.timer = new DispatcherTimer();

            this.timer.Tick += this.Timer_Tick;
            this.winTimer = new DispatcherTimer();
            this.winTimer.Tick += this.WinTimer_Tick;

            this.winTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            this.timer.Interval = new TimeSpan(0, 0, 0, 0, 10);

            this.timer.Start();
            this.winTimer.Start();

            this.winTickCount = 0;
            this.tickCount = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Checks for collision. does not work i Could not figure out to work correctly
        /// </summary>
        /// <param name="index">The index.</param>
        private void checkForNorthWaveForCollision(int index)
        {
            foreach (var dot in this.dotWaveManager.waves[index].dots)
            {
                if (this.player.Sprite.IsTouching(this.player.Sprite, dot.Sprite))
                {
                    this.displayGameOverMessage();
                    this.timer.Stop();
                    this.winTimer.Stop();
                }

                {
                }
            }
        }

        private void WinTimer_Tick(object sender, object e)
        {
            this.winTickCount++;
        }

        private void Timer_Tick(object sender, object e)
        {
            var speedOfGame = 2;
            this.tickCount++;

            if (this.tickCount % speedOfGame == 0)
            {
                
                this.dotWaveManager.StartNorthWave();
                this.manageDotWave(NorthWave);
                
                if (this.winTickCount >= FiveSeconds)
                {
                    this.dotWaveManager.StartWestWave();
                    this.manageDotWave(WestWave);
                }

                if (this.winTickCount >= TenSeconds)
                {
                    this.dotWaveManager.StartSouthWave();
                    this.manageDotWave(SouthWave);
                }

                if (this.winTickCount >= FiftteenSeconds)
                {
                    this.dotWaveManager.StartEastWave();
                    this.manageDotWave(EastWave);
                }

                if (this.winTickCount >= TwentyfiveSeconds)
                {
                    this.timer.Stop();
                    this.winTimer.Stop();

                    this.displayWinEndMessage();
                }
            }
        }

        private void displayWinEndMessage()
        {
            var endMessage = (TextBlock)this.canvas.FindName("winMessage");
            if (endMessage != null)
            {
                endMessage.Visibility = Visibility.Visible;
            }
        }

        private void displayGameOverMessage()
        {
            var endMessage = (TextBlock)this.canvas.FindName("loseMessage");
            if (endMessage != null)
            {
                endMessage.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        ///     Initializes the game placing player in the game
        ///     Precondition: background != null
        ///     Postcondition: Game is initialized and ready for play.
        /// </summary>
        /// <param name="background">The background canvas.</param>
        public void InitializeGame(Canvas background)
        {
            this.canvas = background ?? throw new ArgumentNullException(nameof(background));
            this.dotWaveManager = new DotWaveManager(background);
            this.createAndPlacePlayer(background);
            
            
        }

        private void createAndPlacePlayer(Canvas background)
        {
            this.player = new Player();
            background.Children.Add(this.player.Sprite);

            this.placePlayerCenteredInGameArena();
        }

        private void manageDotWave(int index)
        {
            IList<EnemyDot> toRemove = new List<EnemyDot>();
            foreach (var currentDot in this.dotWaveManager.waves[index].dots)
            {
                this.moveDotWave(index, currentDot);
                this.checkForNorthWaveForCollision(index);
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
                this.dotWaveManager.waves[index].dots.Remove(currentEnemyDot);
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
                        this.canvas.Children.Remove(currentDot.Sprite);
                        remove = true;
                    }

                    break;
                }
                case WestWave:
                {
                    if (currentDot.X > towardsPositiveBorder)
                    {
                        this.canvas.Children.Remove(currentDot.Sprite);
                        remove = true;
                    }

                    break;
                }
                case SouthWave:
                {
                    if (currentDot.Y < towardsNegativeBorder)
                    {
                        this.canvas.Children.Remove(currentDot.Sprite);
                        remove = true;
                    }

                    break;
                }
                case EastWave:
                {
                    if (currentDot.X < towardsNegativeBorder)
                    {
                        this.canvas.Children.Remove(currentDot.Sprite);
                        remove = true;
                    }

                    break;
                }
            }

            return remove;
        }

        private void moveDotWave(int index, EnemyDot currentDot)
        {
            if (index == NorthWave)
            {
                currentDot.MoveDown();
            }
            else if (index == WestWave)
            {
                currentDot.MoveRight();
            }
            else if (index == SouthWave)
            {
                currentDot.MoveUp();
            }
            else
            {
                currentDot.MoveLeft();
            }
        }

        private void placePlayerCenteredInGameArena()
        {
            this.player.X = this.backgroundWidth / 2 - this.player.Width / 2.0;
            this.player.Y = this.backgroundHeight / 2 - this.player.Height / 2.0;
        }

        /// <summary>
        ///     Moves the player to the left.
        ///     Precondition: none
        ///     Postcondition: The player has moved left.
        /// </summary>
        public void MovePlayerLeft()
        {
            var leftBorder = 0;
            if (this.player.X > leftBorder)
            {
                this.player.MoveLeft();
            }
        }

        /// <summary>
        ///     Moves the player to the right.
        ///     Precondition: none
        ///     Postcondition: The player has moved right.
        /// </summary>
        public void MovePlayerRight()
        {
            if (this.player.X < this.backgroundWidth - this.player.Width)
            {
                this.player.MoveRight();
            }
        }

        /// <summary>
        ///     Moves the player up
        ///     Precondition: none
        ///     Postcondition: The player has moved up.
        /// </summary>
        public void MovePlayerUp()
        {
            var topBorder = 0;
            if (this.player.Y > topBorder)
            {
                this.player.MoveUp();
            }
        }

        /// <summary>
        ///     Moves the player down
        ///     Precondition: none
        ///     Postcondition: The player has moved down.
        /// </summary>
        public void MovePlayerDown()
        {
            if (this.player.Y < this.backgroundHeight - this.player.Height)
            {
                this.player.MoveDown();
            }
        }

        #endregion
    }
}