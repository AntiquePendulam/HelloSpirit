using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MessagePack;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace HelloSpirit
{
    public static class Messanger
    {
        public static string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ProjectATR\HelloSpirit";
        public static readonly string FILEPATH = PATH + @"\data.json";

        private static readonly ObservableCollection<SpiritListViewModel> defaultList = new ObservableCollection<SpiritListViewModel>()
        {
            new SpiritListViewModel(){ListTitle = "ToDo"},
            new SpiritListViewModel(){ListTitle = "Working"},
            new SpiritListViewModel(){ListTitle = "Complate"}
        };
        private static readonly MainWindowViewModel defaultViewModel = new MainWindowViewModel() { Lists = defaultList };

        public static void Read()
        {
            if (!File.Exists(FILEPATH))
            {
                MainWindow.MainViewModel = defaultViewModel;
            }
            else
            {
                var json = File.ReadAllBytes(FILEPATH);
                MainWindow.MainViewModel = MessagePackSerializer.Deserialize<MainWindowViewModel>(json);

                if (MainWindow.MainViewModel == null) MainWindow.MainViewModel = defaultViewModel;
            }
            MainWindow.MainViewModel.Lists.ObserveElementPropertyChanged().Subscribe(_ => Write());
            MainWindow.MainViewModel.Lists.CollectionChanged += (a, e) => Write();
        }

        public static void Write()
        {
            var bytes = MessagePackSerializer.Serialize(MainWindow.MainViewModel);
            if (!Directory.Exists(PATH)) Directory.CreateDirectory(PATH);
            File.WriteAllBytes(FILEPATH, bytes);
        }
    }
}
