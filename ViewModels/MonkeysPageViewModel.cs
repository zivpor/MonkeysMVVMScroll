using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkeysMVVM.ViewModels
{
    public class MonkeysPageViewModel:ViewModel
    {
        private bool isRefreshing;
        public ObservableCollection<Monkey> Monkeys { get; set; }
        public ICommand LoadMonkeysCommand {  get; set; }
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public MonkeysPageViewModel() 
        {
            Monkeys = new ObservableCollection<Monkey>();
            LoadMonkeysCommand = new Command(async () => await LoadMonkeys());
        }
        public async Task LoadMonkeys()
        {
            IsRefreshing= true;
            MonkeysService service = new MonkeysService();
            var list = await service.GetMonkeys();
            Monkeys.Clear();
            foreach(var monkey in list)
            {
                Monkeys.Add(monkey);
            }
            IsRefreshing = false;
        }
    }
}
