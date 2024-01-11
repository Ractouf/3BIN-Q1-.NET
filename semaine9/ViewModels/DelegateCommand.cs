﻿using System;
using System.Windows.Input;

namespace WpfEmployee.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private Action _executeMethod;

        public DelegateCommand(Action executeMethod) 
        {
            _executeMethod = executeMethod;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeMethod();
        }
    }
}
