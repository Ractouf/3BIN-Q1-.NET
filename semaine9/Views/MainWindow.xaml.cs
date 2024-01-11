﻿using System.Windows;
using System.Windows.Controls;
using WpfEmployee.ViewModels;

namespace WpfEmployee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new EmployeeVM();
        }
    }
}
