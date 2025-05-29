

namespace Book_Club_2025.ConsoleApp.Shared;

public abstract class BaseView
{
    protected string entityName;
    protected BaseRepository repository;

    protected BaseView(string entityName, BaseRepository repository)
    {
        this.entityName = entityName;
        this.repository = repository;
    }

    public char ShowMeny()
    {
        ShowHeader();

        Console.WriteLine($"1 - Add {entityName}");
        Console.WriteLine($"2 - Check {entityName}s");
        Console.WriteLine($"3 - Edit {entityName}");
        Console.WriteLine($"4 - Delete {entityName}");
        Console.WriteLine($"S - Exit");

        Console.WriteLine();

        Console.Write("Select an option: ");
        char selectedOption = Console.ReadLine().ToUpper()[0];

        return selectedOption;
    }

    public void AddRegister()
    {
        ShowHeader();

        Console.WriteLine($"Register of {entityName}");

        Console.WriteLine();

        BaseEntity newRegister = GetData();

        string erros = newRegister.Validate();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erros);
            Console.ResetColor();

            Console.Write("\nPress Enter to continue...");
            Console.ReadLine();

            AddRegister();

            return;
        }

       repository.AddRegister(newRegister);

        Console.WriteLine($"\n{entityName} success!");
        Console.ReadLine();
    }

    public void EditRegister()
    {
        ShowHeader();

        Console.WriteLine($"Edit {entityName}");

        Console.WriteLine();

        RegisterView(false);

        Console.Write("Type the ID you want to edit: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        BaseEntity registroAtualizado = GetData();

        repository.EditRegister(idSelecionado, registroAtualizado);

        Console.WriteLine($"\n{entityName} editado com sucesso!");
        Console.ReadLine();
    }

    public void ExcluirRegistro()
    {
        ShowHeader();

        Console.WriteLine($"Exclusão de {entityName}");

        Console.WriteLine();

        RegisterView(false);

        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        repository.DeleteRegister(idSelecionado);

        Console.WriteLine($"\n{entityName} deleted!");
        Console.ReadLine();
    }

    public abstract void RegisterView(bool showHeader);

    protected void ShowHeader()
    {
        Console.Clear();
        Console.WriteLine($"Control of {entityName}s");
        Console.WriteLine();
    }

    protected abstract BaseEntity GetData();
}