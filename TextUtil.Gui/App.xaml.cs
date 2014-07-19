﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TextUtil.Gui.ViewModels;
using TextUtil.Gui.Views;

namespace TextUtil.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow();

            var viewModel = new MainWindowViewModel();

            window.DataContext = viewModel;

            window.Show();
        }
    }
}
