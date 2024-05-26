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
using ForwardTestEngine.Wpf.Other;

namespace ForwardTestEngine.Wpf
{
    internal class ForwardTestEngineViewModel : INotifyPropertyChanged
    {
        private ForwardTestEngineModel _forwardTestEngineModel = new ForwardTestEngineModel();

        public ForwardTestEngineViewModel()
        {
            Log.MessageLogged += (sender, message) =>
            {
                LogMessages += $"{message}\n";
            };

            _enginesList.Add(new CombustionEngine());
            _testStandsList.Add(new TestStand(new EngineSimulation(new CombustionEngine())));
        }

        public IEngine SelectedEngine
        {
            get => _selectedEngine;
            set
            {
                _selectedEngine = value;
                OnPropertyChanged(nameof(SelectedEngine));
            }
        }
        private IEngine _selectedEngine;

        public TestStand SelectedTestStand
        {
            get => _selectedTestStand;
            set
            {
                _selectedTestStand = value;
                OnPropertyChanged(nameof(SelectedTestStand));
            }
        }
        private TestStand _selectedTestStand;

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
            async param => await StartTestAsync(),
            param => (SelectedTestStand != null && SelectedEngine != null)
        );

        async private Task StartTestAsync()
        {
            await _forwardTestEngineModel.StartTest(SelectedTestStand);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
