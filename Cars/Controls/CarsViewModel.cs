using Cars.Domain;
using Cars.Persistence;
using Cars.Persistence.Helper;
using Remotion.Linq.Collections;
using System.Linq;
using System.Windows.Input;

namespace Cars.Controls
{
    public class CarsViewModel : BaseViewModel
    {
        // todo: Make UI responsive*

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ICar> _carRepository;
        private readonly ICarService _carService;
        private readonly ObservableCollection<ICar> _cars;

        private string _status;
        private int _count;
        private ICommand _doLoadCars;
        private ICommand _doCreateCars;

        public CarsViewModel()
        {
            // todo: Introduce DI
            _unitOfWork = new UnitOfWork();
            _carRepository = new CarRepository(_unitOfWork);
            _carService = new CarService(_carRepository);
            
            _cars = new ObservableCollection<ICar>();
            Status = "Ready";
        }

        public ObservableCollection<ICar> Cars
        {
            get { return _cars; }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                NotifyPropertyChanged(nameof(Status));
            }
        }

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                NotifyPropertyChanged(nameof(Count));
            }
        }

        public ICommand LoadCarsCommand
        {
            get
            {
                if (_doLoadCars == null)
                {
                    _doLoadCars = new RelayCommand(
                        p => true,
                        p => LoadCars());
                }
                return _doLoadCars;
            }
        }

        public ICommand CreateCarsCommand
        {
            get
            {
                if (_doCreateCars == null)
                {
                    _doCreateCars = new RelayCommand(
                        p => true,
                        p => CreateCars());
                }
                return _doCreateCars;
            }
        }

        private void LoadCars()
        {
            Status = "Loading...";
            _cars.Clear();
            var cars = _carService.GetAll().ToList();
            cars.ForEach(x => _cars.Add(x));
            Count = cars.Count();
            Status = "Ready";
        }

        private void CreateCars()
        {
            Status = "Creating...";
            _carService.CreateDummyData();
            Status = "Ready";
        }
    }
}
