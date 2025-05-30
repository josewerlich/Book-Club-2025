
using Book_Club_2025.ShelfsModule;

namespace Book_Club_2025.ConsoleApp.Shared;

public class MainView
{
    private char userOption;

    private ShelfsRepository shelfsRepository;
   

    private ShelfsView shelfsView;
 

    public MainView()
    {
        shelfsRepository = new ShelfsRepository();
  

        shelfsView = new ShelfsView(shelfsRepository);

 
    }

    public void ShowMainMenu()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|             Book Club 2025            |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Magazines Control");
        Console.WriteLine("2 - User Control");
        Console.WriteLine("3 - Shelfs Control");
        Console.WriteLine("4 - Rental Control");
        Console.WriteLine("E - Exit");

        Console.WriteLine();

        Console.Write("Select one option: ");
        userOption = Console.ReadLine()[0];
    }

    public BaseView GetView()
    {
        if (userOption == '3')
            return shelfsView;

        return null;
    }
}
