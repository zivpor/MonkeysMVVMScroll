using MonkeysMVVM.Views;

namespace MonkeysMVVM;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("monkeys", typeof(MonkeysPage));
        Routing.RegisterRoute("find by location", typeof(FindMonkeyByLocationPage));
        Routing.RegisterRoute("Show monkey", typeof(ShowMonkeyView));
    }
}
