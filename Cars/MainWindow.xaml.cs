using Cars;
using Cars.Persistence;
using Cars.Persistence.Helper;
using Cars.Domain;
using Cars.DomainModel;
using Cars.Persistence;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Windows;

namespace Cars
{
    public partial class MainWindow : Window
    {
        // todo: Reduce code behind!
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncRepository<ICar> _carRepository;
        private readonly ICarService _carService;
        private readonly List<IDisposable> _disposables;

        public MainWindow()
        {
            _unitOfWork = new UnitOfWork();
            _carRepository = new CarRepository(_unitOfWork);
            _carService = new CarService(_carRepository);
            _disposables = new List<IDisposable>();
            InitializeComponent();
        }

        private async void buttonCreateCars_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "buttonCreateCars clicked";
            await _carService.CreateDummyDataAsync();
            label.Content = "CreateCars complete";
        }

        private void buttonGetCars_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "buttonGetCars clicked";
            listboxCars.Items.Clear();

            IObservable<ICar> dataObservable = _carService.GetAll();
            // todo: dispose the disposable

            _disposables.Add(dataObservable
                .ObserveOnDispatcher()
                .Subscribe(
                    (d) => listboxCars.Items.Add(d),
                    (ex) => label.Content = string.Format("OnException: {0}", ex.Message),
                    () => label.Content = "OnCompleted"));
        }

        protected override void OnClosed(EventArgs e)
        {
            _disposables.ForEach(d => d.Dispose());
        }
    }
}
