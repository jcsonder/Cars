using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Threading;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NHibernate;
using Cars.Persistence.Helper;

namespace Cars
{
    public partial class MainWindow : Window
    {
        // todo: Reduce code behind!

        // todo: Load data from SQlite via service

        public MainWindow()
        {
            ISessionFactory sessionFactory = NHibernateHelper.CreateSessionFactory();

            _domainService = new DomainService();
            InitializeComponent();
        }

        private readonly DomainService _domainService;

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "button1 clicked";

            string labelData = await _domainService.GetDataAsync();
            label.Content = string.Format("Data received: {0}", labelData);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "button2 clicked";

            IObservable<long> dataObservable = _domainService.LoadDataAsync();
            // todo: dispose the disposable
            IDisposable disposable = dataObservable
                .ObserveOnDispatcher()
                .Subscribe(
                    (d) => label.Content = string.Format("OnNext: {0}", d),
                    (ex) => label.Content = string.Format("OnException: {0}", ex.Message),
                    () => label.Content = "OnCompleted");
        }
    }
}
