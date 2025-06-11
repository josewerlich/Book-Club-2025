using Book_Club_2025.ConsoleApp.Shared;
using Book_Club_2025.FriendsModule;
using Book_Club_2025.MagazinesModule;


namespace Book_Club_2025.BorrowModule
{
    public class BorrowView : BaseView
    {
        private BorrowRepository borrowRepository;
        private FriendsRepository friendsRepository;
        private MagazineRepository magazineRepository;

     

        public BorrowView(BorrowRepository repository, FriendsRepository friendsRepository, MagazineRepository magazineRepository)
            : base("Borrowing", repository)
        {
            borrowRepository = repository;
            this.friendsRepository = friendsRepository;
            this.magazineRepository = magazineRepository;
        }

        public override char ShowMenu()
        {
            ShowHeader();

            Console.WriteLine($"1 - Register of  {entityName}");
            Console.WriteLine($"2 - Return of {entityName}");
            Console.WriteLine($"3 - View {entityName}s");
            Console.WriteLine($"E - Exit");

            Console.WriteLine();

            Console.Write("Type an option: ");
            char option = Console.ReadLine().ToUpper()[0];

            return option;
        }

        public void BorrowingRegister()
        {
            ShowHeader();

            Console.WriteLine($"Registed of {entityName}");

            Console.WriteLine();

            BorrowControl newRegister = (BorrowControl)GetData();

            string errors = newRegister.Validate();

            if (errors.Length > 0)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errors);
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                AddRegister();

                return;
            }

            BorrowControl[] activeBorrowings = borrowRepository.SelectActiveBorrowing();

            for (int i = 0; i < activeBorrowings.Length; i++)
            {
                BorrowControl activeBorrowing = activeBorrowings[i];

                if (newRegister.FriendsControl.id == activeBorrowing.FriendsControl.id)
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The friend you select already have an active borrowing!");
                    Console.ResetColor();

                    Console.Write("\nPress ENTER to continue...");
                    Console.ReadLine();

                    return;
                }
            }

            newRegister.MagazineControl.Status = "Borrowed";

            repository.AddRegister(newRegister);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{entityName} registered!");
            Console.ResetColor();

            Console.ReadLine();
        }

        public void ReturnMagazine()
        {
            ShowHeader();

            Console.WriteLine($"Return of {entityName}");

            Console.WriteLine();

            ViewActiveBorrowing();

            Console.Write("Type the Borrowing ID you want to return: ");
            int idBorrowing = Convert.ToInt32(Console.ReadLine());

            BorrowControl selectBorrowing = (BorrowControl)repository.SelectRegisterID(idBorrowing);

            if (selectBorrowing == null)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The borrowing you select does not exist!");
                Console.ResetColor();

                Console.Write("\nPress ENTER to continue...");
                Console.ReadLine();

                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nDo you confirm the return? This action cannot be overturned. (Y/N): ");
            Console.ResetColor();

            string answer = Console.ReadLine()!;

            if (answer.ToUpper() != "Y")
                return;

            selectBorrowing.Status = "Returned";
            selectBorrowing.MagazineControl.Status = "Available";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{entityName} returned!");
            Console.ResetColor();

            Console.ReadLine();
        }

        public override void ViewRegister(bool showHeader)
        {
            if (showHeader == true)
                ShowHeader();

            Console.WriteLine("Borrowing View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15}",
                "Id", "Friend", "Magazine", "Borrowing Date", "Return Date", "Status"
            );

            BaseEntity[] borrowing = repository.SelectRegister();

            for (int i = 0; i < borrowing.Length; i++)
            {
                BorrowControl e = (BorrowControl)borrowing[i];

                if (e == null)
                    continue;

                if (e.Status == "Late")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(
                 "{0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15}",
                    e.id, e.FriendsControl.name, e.MagazineControl.Title, e.BorrowingDate.ToShortDateString(), e.ReturningDate.ToShortDateString(), e.Status
                );

                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"\nPress ENTER to continue...");
            Console.ResetColor();

            Console.ReadLine();
        }

        protected override BaseEntity GetData()
        {
            ViewFriends();

            Console.Write("Type the ID of the friend that will get the magazine: ");
            int friendID = Convert.ToInt32(Console.ReadLine());

            FriendsControl selectedFriend = (FriendsControl)friendsRepository.SelectRegisterID(friendID);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nFriend selected!");
            Console.ResetColor();

            ViewAvailableMagazines();

            Console.Write("Type the ID of the magazine: ");
            int magazineID = Convert.ToInt32(Console.ReadLine());

            MagazineControl selectedMagazine = (MagazineControl)magazineRepository.SelectRegisterID(magazineID);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nMagazine selected!");
            Console.ResetColor();

            BorrowControl borrowing = new BorrowControl(selectedFriend, selectedMagazine);

            return borrowing;
        }

        private void ViewActiveBorrowing()
        {
            Console.WriteLine("Active Borrowing");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15}",
                "Id", "Friend", "Magazine", "Borrowing Date", "Return Date", "Status"
            );

            BaseEntity[] borrowing = repository.SelectRegister();

            for (int i = 0; i < borrowing.Length; i++)
            {
                BorrowControl b = (BorrowControl)borrowing[i];

                if (b == null)
                    continue;

                if (b.Status == "Late")
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(
                 "{0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15}",
                    b.id, b.FriendsControl.name, b.MagazineControl.Title, b.BorrowingDate.ToShortDateString(), b.ReturningDate.ToShortDateString(), b.Status
                );

                Console.ResetColor();
            }

            Console.WriteLine();
        }

        private void ViewFriends()
        {
            Console.WriteLine("Friends View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -30} | {2, -30} | {3, -20}",
                "Id", "Name", "Responsible", "Phone"
            );

            BaseEntity[] friends = friendsRepository.SelectRegister();

            for (int i = 0; i < friends.Length; i++)
            {
                FriendsControl f = (FriendsControl)friends[i];

                if (f == null)
                    continue;

                Console.WriteLine(
                  "{0, -5} | {1, -30} | {2, -30} | {3, -20}",
                    f.id, f.name, f.responsible, f.phone
                );
            }

            Console.WriteLine();
        }

        private void ViewAvailableMagazines()
        {
            Console.WriteLine();

            Console.WriteLine("Magazines View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -15} | {5, -15}",
                "Id", "Title", "Edition", "Published Year", "Shelf", "Status"
            );

            BaseEntity[] activeMagazines = magazineRepository.SelectActiveMagazines();

            for (int i = 0; i < activeMagazines.Length; i++)
            {
                MagazineControl m = (MagazineControl)activeMagazines[i];

                if (m == null)
                    continue;

                Console.WriteLine(
                "{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -15} | {5, -15}",
                    m.id, m.Title, m.Edition, m.PublishedYear, m.ShelfsControl.label, m.Status
                );
            }

            Console.WriteLine();
        }
    }
}


