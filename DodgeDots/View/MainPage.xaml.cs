
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using DodgeDots.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DodgeDots.View
{
    /// <summary>
    /// The main page for the game.
    /// </summary>
    public sealed partial class MainPage
    {
        /// <summary>
        ///     The application height
        /// </summary>
        public const double ApplicationHeight = 400;

        /// <summary>
        ///     The application width
        /// </summary>
        public const double ApplicationWidth = 400;

        private readonly GameManager gameManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size { Width = ApplicationWidth, Height = ApplicationHeight };
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));

            Window.Current.CoreWindow.KeyDown += this.coreWindowOnKeyDown;
            ApplicationView.GetForCurrentView().Title = "Dodge Dots by Williams Iteration 2";
            this.gameManager = new GameManager(ApplicationHeight, ApplicationWidth);
            this.gameManager.InitializeGame(this.canvas);
            this.gameManager.CountDownTimerCountUpdated += this.GameManager_CountDownTimerCountUpdated;
            this.gameManager.EndGameMessegeUpdated += this.GameManager_EndGameMessegeUpdated;
        }

        private void GameManager_EndGameMessegeUpdated(int count)
        {
            if (count == 0)
            {
                this.winMessage.Visibility = Visibility.Visible;
            }
            else
            {
                this.loseMessage.Visibility = Visibility.Visible;
            }
        }

        private void GameManager_CountDownTimerCountUpdated(int count)
        {
            this.timer.Text = count.ToString();
        }

        private void coreWindowOnKeyDown(CoreWindow sender, KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:
                    this.gameManager.Player.MovePlayerLeft();
                    break;
                case VirtualKey.Right:
                    this.gameManager.Player.MovePlayerRight();
                    break;
                case VirtualKey.Up:
                    this.gameManager.Player.MovePlayerUp();
                    break;
                case VirtualKey.Down:
                    this.gameManager.Player.MovePlayerDown();
                    break;
                case VirtualKey.Space:
                    this.gameManager.Player.SwapColor();
                    break;
            }
        }
    }
}