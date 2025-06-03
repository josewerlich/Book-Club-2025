using Book_Club_2025.ConsoleApp.Shared;


namespace Book_Club_2025.BorrowModule
{
    public class BorrowView : BaseView
    {
        private BorrowRepository borrowRepository;

        public BorrowView(BorrowRepository borrowRepository)
        : base("Borrow", borrowRepository)
        {
            this.borrowRepository = borrowRepository;
        }
        public override void ViewRegister(bool showHeader)
        {
            if (showHeader == true)
                ShowHeader();

            Console.WriteLine("Borrow View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                "Id", "Friend", "Date", "Status"
            );

            BaseEntity[] borrowControl = borrowRepository.SelectRegister();

            for (int i = 0; i < borrowControl.Length; i++)
            {
                BorrowControl b = (BorrowControl)borrowControl[i];

                if (b == null)
                    continue;

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {4, -20}",
                    b.id, b.friend, b.magazine, b.date, b.status
                );
            }

            Console.ReadLine();
        }
        protected override BorrowControl GetData()
        {
            Console.Write("Type the Friend: ");
            string friend = Console.ReadLine();

            Console.Write("Type the Magazine: ");
            string magazine = Console.ReadLine();

            Console.Write("Type the Date: ");
            string date = Console.ReadLine();

            Console.Write("Type the Stauts: ");
            string status = Console.ReadLine();

            BorrowControl borrowControl = new BorrowControl(friend,magazine, date, status);

            return borrowControl;
        }


    }
}
    
    

