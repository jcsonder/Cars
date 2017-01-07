using Cars.Domain;
using Remotion.Linq.Collections;
using System.Windows.Input;

namespace Cars.Controls
{
    public interface ICarsViewModel
    {
        ObservableCollection<ICar> Cars { get; }

        string Status { get; }

        int Count { get; }

        ICommand LoadCarsCommand { get; }

        ICommand CreateCarsCommand { get; }
    }
}
