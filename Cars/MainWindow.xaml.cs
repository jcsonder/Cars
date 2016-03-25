using Cars.DomainModel;
using System;
using System.Reactive.Linq;
using System.Windows;

namespace Cars
{
    public partial class MainWindow : Window
    {
        // todo: Reduce code behind!
        private readonly DomainService _domainService;

        public MainWindow()
        {
            _domainService = new DomainService();
            InitializeComponent();
        }

        private async void buttonCreateCars_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "buttonCreateCars clicked";
            await _domainService.CreateCarsAsync();
            label.Content = "CreateCars complete";
        }

        private void buttonGetCars_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "buttonGetCars clicked";
            listboxCars.Items.Clear();

            IObservable<Car> dataObservable = _domainService.GetCars();
            // todo: dispose the disposable
            IDisposable disposable = dataObservable
                .ObserveOnDispatcher()
                .Subscribe(
                    (d) => listboxCars.Items.Add(d),
                    (ex) => label.Content = string.Format("OnException: {0}", ex.Message),
                    () => label.Content = "OnCompleted");
        }
    }
}
