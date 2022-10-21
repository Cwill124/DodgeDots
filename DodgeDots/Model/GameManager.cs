using System;
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
        private const int NorthBlitzWave = 5;
        private const int SouthBlitzWave = 4;
        private const int FiveSeconds = 5;
        private const int TenSeconds = 10;
        private const int FiftteenSeconds = 15;
        private const int TwentySeconds = 20;
        private const int TwentyfiveSeconds = 25;
        private readonly double backgroundHeight;
        private readonly double backgroundWidth;
        private int amountOfTime = 24;
        private int endMessegeNumber;


        /// <summary>Gets the player.</summary>
        /// <value>The player.</value>
        public Player Player { get; set; }

        private readonly DispatcherTimer timer;

        private readonly DispatcherTimer winTimer;

        /// <summary>Gets the canvas.</summary>
        /// <value>The canvas.</value>
        public Canvas Canvas { get; private set; }

        private DotWaveManager dotWaveManager;

        private int tickCount;

        private int winTickCount;

        /// <summary>
        ///   <br />
        /// </summary>
        /// <param name="count">The count.</param>
        public delegate void CountDownTimerHandler(int count);

        /// <summary>Occurs when [count down timer count updated].</summary>
        public event CountDownTimerHandler CountDownTimerCountUpdated;

        /// <summary>
        ///   <br />
        /// </summary>
        /// <param name="count">The count.</param>
        public delegate void EndGameMessegeHandler(int count);

        /// <summary>Occurs when [end game messege updated].</summary>
        public event EndGameMessegeHandler EndGameMessegeUpdated;

        private void onEndGameMessegeUpdated()
        {
            this.EndGameMessegeUpdated?.Invoke(this.endMessegeNumber);
        }

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

            this.Canvas = null;
            
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

        private void WinTimer_Tick(object sender, object e)
        {
            this.onCountDownTimerCountUpdated();
            this.winTickCount++;
            this.amountOfTime--;
        }

        /// <summary>
        ///     Checks for collision. does not work i Could not figure out to work correctly
        /// </summary>
        /// <param name="index">The index.</param>
        private void checkForCollision(int index)
        {
            foreach (var dot in this.dotWaveManager.Waves[index].Dots)
            {
                if (this.Player.Sprite.IsTouching(this.Player.Sprite, dot.Sprite))
                {
                    this.endMessegeNumber = 1;
                    this.onEndGameMessegeUpdated();
                    this.timer.Stop();
                    this.winTimer.Stop();
                }
            }
        }

        private void Timer_Tick(object sender, object e)
        {
            var speedOfGame = 2;
            this.tickCount++;
            if (this.tickCount % speedOfGame == 0)
            {
                this.dotWaveManager.StartNorthWave();
                this.dotWaveManager.ManageDotWave(NorthWave);
                this.checkForCollision(NorthWave);

                if (this.winTickCount >= FiveSeconds)
                {
                    this.dotWaveManager.StartWestWave();
                    this.dotWaveManager.ManageDotWave(WestWave);
                    this.checkForCollision(WestWave);
                }

                if (this.winTickCount >= TenSeconds)
                {
                    this.dotWaveManager.StartSouthWave();
                    this.dotWaveManager.ManageDotWave(SouthWave);
                    this.checkForCollision(SouthWave);
                }

                if (this.winTickCount >= FiftteenSeconds)
                {
                    this.dotWaveManager.StartEastWave();
                    this.dotWaveManager.ManageDotWave(EastWave);
                    this.checkForCollision(EastWave);
                }

                if (this.winTickCount >= TwentySeconds)
                {
                    this.dotWaveManager.StartNorthBlitzWave();
                    this.dotWaveManager.StartSouthBlitzWave();
                    this.dotWaveManager.ManageDotWave(SouthBlitzWave);
                    this.dotWaveManager.ManageDotWave(NorthBlitzWave);
                }

                if (this.winTickCount >= TwentyfiveSeconds)
                {
                    this.timer.Stop();
                    this.winTimer.Stop();

                    this.endMessegeNumber = 0;
                    this.onEndGameMessegeUpdated();
                }
            }
        }

        /// <summary>
        ///     Initializes the game placing Player in the game
        ///     Precondition: background != null
        ///     Postcondition: Game is initialized and ready for play.
        /// </summary>
        /// <param name="background">The background canvas.</param>
        public void InitializeGame(Canvas background)
        {
            this.Canvas = background ?? throw new ArgumentNullException(nameof(background));
            this.dotWaveManager = new DotWaveManager(background);
            this.createAndPlacePlayer(background);
        }

        private void onCountDownTimerCountUpdated()
        {
            this.CountDownTimerCountUpdated?.Invoke(this.amountOfTime);
        }

        private void createAndPlacePlayer(Canvas background)
        {
            this.Player = new Player(this.backgroundWidth, this.backgroundHeight);
            background.Children.Add(this.Player.Sprite);

            this.placePlayerCenteredInGameArena();
        }

        private void placePlayerCenteredInGameArena()
        {
            this.Player.X = this.backgroundWidth / 2 - this.Player.Width / 2.0;
            this.Player.Y = this.backgroundHeight / 2 - this.Player.Height / 2.0;
        }

        #endregion
    }
}