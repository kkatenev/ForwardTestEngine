using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using ForwardTestEngine.Engines;
using ForwardTestEngine.Interfaces;
using ForwardTestEngine.TestSimulation;
using ForwardTestEngine.TestStands;

namespace ForwardTestEngine.Wpf
{
    internal class ForwardTestEngineViewModel : INotifyPropertyChanged
    {
        private ForwardTestEngineModel _forwardTestEngineModel = new ForwardTestEngineModel();

        public ForwardTestEngineViewModel()
        {
            _enginesList.Add(new CombustionEngine());
            _testStandsList.Add(new TestStand(new EngineSimulation(_enginesList[0])));
        }

        public List<IEngine> EnginesList
        {
            get => _enginesList;
            set
            {
                _enginesList = value;
                OnPropertyChanged(nameof(EnginesList));
            }
        }
        private List<IEngine> _enginesList = new List<IEngine>();

        public List<TestStand> TestStandsList
        {
            get => _testStandsList;
            set
            {
                _testStandsList = value;
                OnPropertyChanged(nameof(TestStandsList));
            }
        }
        private List<TestStand> _testStandsList = new List<TestStand>();

        private string _logMessages = string.Empty;
        public string LogMessages
        {
            get => _logMessages;
            set
            {
                _logMessages = value;
                OnPropertyChanged(nameof(LogMessages));
            }
        }

        public ICommand StartTestCommand => new RelayCommand(
            param => StartTestAsync(),
            param => true
        );

        private void StartTestAsync()
        {
            _forwardTestEngineModel.StartTest(_testStandsList[0]);
        }

        private void Model_LogMessageAdded(object sender, string message)
        {
            LogMessages += $"{message}\n";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
