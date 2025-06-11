
using Book_Club_2025.ConsoleApp.Shared;
using Book_Club_2025.ShelfsModule;


namespace Book_Club_2025.MagazinesModule
{
    class MagazineView : BaseView
    {
        private MagazineRepository magazineRepository;
        private ShelfsRepository shelfsRepository;

        public MagazineView(MagazineRepository magazineRepository, ShelfsRepository shelfsRepository)
        : base("Magazine", magazineRepository)
        {
            this.magazineRepository = magazineRepository;
            this.shelfsRepository = shelfsRepository;   
        }
        public override void ViewRegister(bool showHeader)
        {
            if (showHeader == true)
                ShowHeader();

            Console.WriteLine("Magazines View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {4, -10 } | {5, -20}",
                "Id", "Title", "Editon", "Published Year", "Shelf", "Status"
            );

            BaseEntity[] magazineControl = magazineRepository.SelectRegister();

            for (int i = 0; i < magazineControl.Length; i++)
            {
                MagazineControl m = (MagazineControl)magazineControl[i];

                if (m == null)
                    continue;

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {4, -10} | {5, -20}",
                    m.id, m.Title, m.Edition, m.PublishedYear, m.ShelfsControl.label, m.Status
                );
            }

            Console.ReadLine();
        }
        protected override MagazineControl GetData()
        {
            Console.Write("Type the Title: ");
            string title = Console.ReadLine();

            Console.Write("Type the Edition: ");
            int edition = Convert.ToInt32(Console.ReadLine());

            Console.Write("Type the Year is was published: ");
            int publishedYear = Convert.ToInt32(Console.ReadLine());

            ViewRegister();

            Console.Write("\nType the ID of the shelf: ");
            int ShelfID = Convert.ToInt32(Console.ReadLine());

            ShelfsControl selectedShelf = (ShelfsControl)shelfsRepository.SelectRegisterID(ShelfID);

            MagazineControl magazine = new MagazineControl(title, edition, publishedYear, selectedShelf);

            return magazine;
        }
        private void ViewRegister()
        {
            Console.WriteLine();

            Console.WriteLine("Shelfs View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30} | {3, -30}",
                "Id", "Label", "Color", "Borrowing Days"
            );

            BaseEntity[] shelfs = shelfsRepository.SelectRegister();

            for (int i = 0; i < shelfs.Length; i++)
            {
                ShelfsControl s = (ShelfsControl)shelfs[i];

                if (s == null)
                    continue;

                Console.WriteLine(
                  "{0, -10} | {1, -30} | {2, -30} | {3, -30}",
                    s.id, s.label, s.color, s.borrowingDays
                );
            }
        }
    }

}

