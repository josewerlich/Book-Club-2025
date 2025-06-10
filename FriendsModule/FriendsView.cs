
using Book_Club_2025.ConsoleApp.Shared;


namespace Book_Club_2025.FriendsModule
{
    class FriendsView : BaseView
    {

        public FriendsView(FriendsRepository friendsRepository)
        : base("Friends", friendsRepository) { }
        

        public override void AddRegister()
        {
            ShowHeader();

            Console.WriteLine($"Register of {entityName}");

            Console.WriteLine();

            FriendsControl newRegister = (FriendsControl)GetData();

            string errors = newRegister.Validate();

            if (errors.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errors);
                Console.ResetColor();

                Console.Write("\nType ENTER to continue...");
                Console.ReadLine();

                AddRegister();

                return;
            }

            BaseEntity[] register = repository.SelectRegister();

            for (int i = 0; i < register.Length; i++)
            {
                FriendsControl friendRegistered = (FriendsControl)register[i];

                if (friendRegistered == null)
                    continue;

                if (friendRegistered.name == newRegister.name || friendRegistered.phone == newRegister.phone)
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You already have a friend with the same name!");
                    Console.ResetColor();

                    Console.Write("\nPress ENTER to continue...");
                    Console.ReadLine();

                    AddRegister();
                    return;
                }
            }

            repository.AddRegister(newRegister);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{entityName} friend registered!");
            Console.ResetColor();

            Console.ReadLine();
        }

        public override void EditRegister()
        {
            ShowHeader();

            Console.WriteLine($"Edit {entityName}");

            Console.WriteLine();

            ViewRegister(false);

            Console.Write("Type the ID you want to update: ");
            int idSelected = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            FriendsControl registerUpdated = (FriendsControl)GetData();

            string erros = registerUpdated.Validate();

            if (erros.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();

                Console.Write("\nPress ENTER to continue...");
                Console.ReadLine();

                EditRegister();

                return;
            }

            BaseEntity[] register = repository.SelectRegister();

            for (int i = 0; i < register.Length; i++)
            {
                FriendsControl friendRegistered = (FriendsControl)register[i];

                if (friendRegistered == null)
                    continue;

                if (
                    friendRegistered.id != idSelected &&
                    (friendRegistered.name == registerUpdated.name ||
                    friendRegistered.phone == registerUpdated.phone)
                )
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You already have a friend with the same name!");
                    Console.ResetColor();

                    Console.Write("\nType ENTER to continue...");
                    Console.ReadLine();

                    EditRegister();

                    return;
                }
            }

            repository.EditRegister(idSelected, registerUpdated);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{entityName} updated!");
            Console.ResetColor();

            Console.ReadLine();
        }
        public override void ViewRegister(bool showHeader)
        {
            if (showHeader == true)
                ShowHeader();

            Console.WriteLine("Friends View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                "Id", "Name", "Responsible", "Phone"
            );

            BaseEntity[] friendsControl = repository.SelectRegister();

            for (int i = 0; i < friendsControl.Length; i++)
            {
                FriendsControl f = (FriendsControl)friendsControl[i];

                if (f == null)
                    continue;

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                    f.id, f.name, f.responsible, f.phone
                );
            }

            Console.ReadLine();
        }
        protected override FriendsControl GetData()
        {
            Console.Write("Type the Name: ");
            string name = Console.ReadLine();

            Console.Write("Type the Responsible: ");
            string responsible = Console.ReadLine();

            Console.Write("Type the phone number: ");
            string phone = Console.ReadLine();

            FriendsControl friendsControl = new FriendsControl(name, responsible, phone);

            return friendsControl;
        }
    }
    
    
}
