using GalaSoft.MvvmLight;
using System.Collections.Generic;

using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Kwisspel.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        Model.MyContext context;
       
        public ObservableCollection<VragenVM> Vragen { get; set; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            context = new Model.MyContext();

            IEnumerable<Model.Vraag> result = context.Vragen.ToList();


            Vragen = new ObservableCollection<VragenVM>();
        }
    }
}