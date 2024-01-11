using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeVM : INotifyPropertyChanged
    {
        private List<EmployeeModel> _EmployeesList;
        private List<string> _listTitle;
        private NorthwindContext context = new NorthwindContext();
        private DelegateCommand _saveCommand;
        private EmployeeModel _selectedEmployee;

        public List<EmployeeModel> EmployeesList
        {
            get
            {
                return _EmployeesList = _EmployeesList ?? loadEmployee();
            }
        }

        private List<EmployeeModel> loadEmployee()
        {
            List<EmployeeModel> localCollection = new List<EmployeeModel>();
            foreach (var item in context.Employees)
            {
                localCollection.Add(new EmployeeModel(item));
            }

            return localCollection;
        }

        public List<string> ListTitle
        {
            get { return _listTitle = _listTitle ?? LoadTitleOfCourtesy(); }

        }

        private List<string> LoadTitleOfCourtesy()
        {
            return context.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        }

        public DelegateCommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new DelegateCommand(SaveEmployee); }
        }

        private void SaveEmployee()
        {
            Employee verif = context.Employees.Where(e => e.EmployeeId == SelectedEmployee.MonEmployee.EmployeeId).SingleOrDefault();
            if (verif == null)
            {
                context.Employees.Add(SelectedEmployee.MonEmployee);
                context.SaveChanges();
                MessageBox.Show("Enregistrement en base de données fait");
            }

            MessageBox.Show("L'employé existe déjà");
        }

        public EmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value; OnPropertyChanged("OrdersList"); }
        }

        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }
    }
}
