
namespace Book_Club_2025.ConsoleApp.Shared;

public class MainView
{
    private char userOption;

    //private RepositorioFabricante repositorioFabricante;
    //private RepositorioEquipamento repositorioEquipamento;
    //private RepositorioChamado repositorioChamado;

    //private TelaFabricante telaFabricante;
    //private TelaEquipamento telaEquipamento;
    //private TelaChamado telaChamado;

    public MainView()
    {
        //repositorioFabricante = new RepositorioFabricante();
        //repositorioEquipamento = new RepositorioEquipamento();
        //repositorioChamado = new RepositorioChamado();

        //telaFabricante = new TelaFabricante(repositorioFabricante);

        //telaEquipamento = new TelaEquipamento(
          //repositorioEquipamento,
          //repositorioFabricante
      //);

      //telaChamado = new TelaChamado(repositorioChamado, repositorioEquipamento);
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
        Console.WriteLine("E - Exit");

        Console.WriteLine();

        Console.Write("Select one option: ");
        userOption = Console.ReadLine()[0];
    }

    //public BaseView GetView()
    //{
    //    if (userOption == '1')
    //        return magazineView;

    //    else if (userOption == '2')
    //        return userView;

    //    else if (userOption == '3')
    //        return shelfsView;

    //    return null;
    //}
}
