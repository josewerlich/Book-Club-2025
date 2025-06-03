
using Book_Club_2025.ConsoleApp.Shared;
using Book_Club_2025.ShelfsModule;

namespace Book_Club_2025.FriendsModule
{
    class FriendsView : BaseView
    {
        private FriendsRepository friendsRepository;

        public FriendsView(FriendsRepository friendsRepository)
        : base("Friends", friendsRepository)
        {
            this.friendsRepository = friendsRepository;
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

            BaseEntity[] friendsControl = friendsRepository.SelectRegister();

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
