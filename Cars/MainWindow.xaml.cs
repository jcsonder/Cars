using Cars.Domain;
using Cars.Persistence;
using Cars.Persistence.Helper;
using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Windows;

namespace Cars
{
    public partial class MainWindow : Window
    {
        // todo: Reduce code behind!
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncRepository<ICar> _carRepository;
        private readonly ICarService _carService;
        private readonly SerialDisposable _disposable;

        public MainWindow()
        {
            _unitOfWork = new UnitOfWork();
            _carRepository = new CarRepository(_unitOfWork);
            _carService = new CarService(_carRepository);
            _disposable = new SerialDisposable();
            InitializeComponent();

            Debug.WriteLine("MainWindow initialized on threadId={0}", Thread.CurrentThread.ManagedThreadId);
        }

        private async void buttonCreateCars_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "buttonCreateCars clicked";
            await _carService.CreateDummyDataAsync();
            label.Content = "CreateCars complete";
        }

        private void buttonGetCars_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("buttonGetCars_Click on threadId={0}", Thread.CurrentThread.ManagedThreadId);

            label.Content = "buttonGetCars clicked";
            listboxCars.Items.Clear();

            IObservable<ICar> dataObservable = _carService.GetAll();

            _disposable.Disposable = dataObservable
                .ObserveOnDispatcher()  // use ISchedulerProvider
                .Subscribe(
                    d => 
                        {
                            Debug.WriteLine("OnNext on threadId={0}", Thread.CurrentThread.ManagedThreadId);
                            Thread.Sleep(1000);
                            listboxCars.Items.Add(d);
                        },
                    ex => label.Content = string.Format("OnException: {0}", ex.Message),
                    () => label.Content = "OnCompleted");
        }

        protected override void OnClosed(EventArgs e)
        {
            _disposable.Dispose();
        }
    }
}
