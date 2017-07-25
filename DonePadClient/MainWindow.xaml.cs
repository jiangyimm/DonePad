﻿using ViewBase = DonePadClient.View.ViewBase;

namespace DonePadClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewBase.ShowView(nameof(LoginWindow));
        }
    }
}