

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

    public virtual char ShowMenu()
    {
        ShowHeader();

        Console.WriteLine($"1 - Add {entityName}");
        Console.WriteLine($"2 - Check {entityName}s");
        Console.WriteLine($"3 - Edit {entityName}");
        Console.WriteLine($"4 - Delete {entityName}");
        Console.WriteLine($"E - Exit");

        Console.WriteLine();

        Console.Write("Select an option: ");
        char selectedOption = Console.ReadLine().ToUpper()[0];

        return selectedOption;
    }

    public virtual void AddRegister()
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

        Console.WriteLine($"\n{entityName} registered with success!");
        Console.ReadLine();
    }

    public virtual void EditRegister()
    {
        ShowHeader();

        Console.WriteLine($"Edited register of the {entityName}");

        Console.WriteLine();

        ViewRegister(false);

        Console.Write("Type the ID you want to edit: ");
        int selectedID = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        BaseEntity updatedRegister = GetData();

        repository.EditRegister(selectedID, updatedRegister);

        Console.WriteLine($"\n{entityName} updated!");
        Console.ReadLine();
    }

    public void DeleteRegister()
    {
        ShowHeader();

        Console.WriteLine($"Delete {entityName}");

        Console.WriteLine();

        ViewRegister(false);

        Console.Write("Type the ID you want to delete: ");
        int selectedID = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        repository.DeleteRegister(selectedID);

        Console.WriteLine($"\n{entityName} deleted!");
        Console.ReadLine();
    }

    public abstract void ViewRegister(bool showHeader);

    protected void ShowHeader()
    {
        Console.Clear();
        Console.WriteLine($"Control of {entityName}s");
        Console.WriteLine();
    }

    protected abstract BaseEntity GetData();
}