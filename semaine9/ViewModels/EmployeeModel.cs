﻿using System;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeModel
    {
        private readonly Employee _monEmployee;

        public Employee MonEmployee
        {
            get { return _monEmployee; }
        }

        public EmployeeModel(Employee current)
        {
            this._monEmployee = current;
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", _monEmployee.FirstName, _monEmployee.LastName).Trim();
            }
        }

        public string DisplayBirthDate
        {
            get
            {
                if (_monEmployee.BirthDate.HasValue)
                {
                    return _monEmployee.BirthDate.Value.ToShortDateString();
                }

                return "";
            }
        }

        public string LastName
        {
            get { return _monEmployee.LastName; }
            set { _monEmployee.LastName = value; }
        }

        public string FirstName 
        { 
            get { return _monEmployee.FirstName; }
            set { _monEmployee.FirstName = value; }
        }

        public DateTime? BirthDate 
        { 
            get { return _monEmployee.BirthDate; }
            set { _monEmployee.BirthDate = value; }
        }

        public DateTime? HireDate
        {
            get { return _monEmployee.HireDate; }
            set { _monEmployee.HireDate = value; }
        }

        public string TitleOfCourtesy
        {
            get { return _monEmployee.TitleOfCourtesy; }
            set { _monEmployee.TitleOfCourtesy = value; }
        }
    }
}
