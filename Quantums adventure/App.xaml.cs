using Quantums_adventure.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Quantums_adventure
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application

    {
        private void App_OnStartup(object sender, StartupEventArgs e)

        {

            var field = new GameField();

            var game = new Game(field);

            game.Start();

            var window = new MainWindow() { DataContext = field };

            window.ShowDialog();

            game.Stop();

        }

    }
}
