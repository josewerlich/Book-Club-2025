
using Book_Club_2025.ConsoleApp.Shared;


namespace Book_Club_2025.MagazinesModule
{
    class MagazineView : BaseView      
    {
        private MagazineRepository magazineRepository;

        public MagazineView(MagazineRepository magazineRepository)
        : base("Magazine", magazineRepository)
        {
            this.magazineRepository = magazineRepository;
        }
        public override void ViewRegister(bool showHeader)
        {
            if (showHeader == true)
                ShowHeader();

            Console.WriteLine("Magazines View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {4, -10 }",
                "Id", "Title", "Editon Year", "Borrowing Status", "Shelf ID"
            );

            BaseEntity[] magazineControl = magazineRepository.SelectRegister();

            for (int i = 0; i < magazineControl.Length; i++)
            {
                MagazineControl m = (MagazineControl)magazineControl[i];

                if (m == null)
                    continue;

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -30} | {3, -16} | {4, -10}",
                    m.id, m.title, m.editionYear, m.borrowingStatus, m.shelfID
                );
            }

            Console.ReadLine();
        }
        protected override MagazineControl GetData()
        {
            Console.Write("Type the Title: ");
            string title = Console.ReadLine();

            Console.Write("Type the Edition Year: ");
            string editionYear = Console.ReadLine();

            Console.Write("Type the status -borrowed- or -available-: ");
            string borrowingStatus = Console.ReadLine();

            Console.Write("Type the ID of the shelf: ");
            string shelfID = Console.ReadLine();

            MagazineControl magazineControl = new MagazineControl(title, editionYear, borrowingStatus, shelfID);

            return magazineControl;
        }
    }
}

