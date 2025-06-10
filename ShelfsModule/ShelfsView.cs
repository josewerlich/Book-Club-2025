
using Book_Club_2025.ConsoleApp.Shared;

namespace Book_Club_2025.ShelfsModule
{
   public class ShelfsView : BaseView
    {
        private ShelfsRepository shelfsRepository;

        public ShelfsView(ShelfsRepository shelfsRepository)
        : base("Shelf", shelfsRepository)
        {
            this.shelfsRepository = shelfsRepository;
        }
        public override void ViewRegister(bool showHeader)
        {
            if (showHeader == true)
                ShowHeader();

            Console.WriteLine("Shelfs View");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                "Id", "Label", "Color", "Borrowing Days"
            );

            BaseEntity[] shelfsControl = shelfsRepository.SelectRegister();

            for (int i = 0; i < shelfsControl.Length; i++)
            {
                ShelfsControl s = (ShelfsControl)shelfsControl[i];

                if (s == null)
                    continue;

                Console.WriteLine(
                   "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                    s.id, s.label, s.color, s.borrowingDays
                );
            }

            Console.ReadLine();
        }
        protected override ShelfsControl GetData()
        {
            Console.Write("Type the Label: ");
            string label = Console.ReadLine();

            Console.Write("Type the Color: ");
            string color = Console.ReadLine();

            Console.Write("Type the quantity of borrowing days (optional): ");
            bool conversion = int.TryParse(Console.ReadLine(), out int borrowingDays);


            ShelfsControl shelfsControl;

            if (conversion)
                shelfsControl = new ShelfsControl(label, color, borrowingDays);
            else
                shelfsControl = new ShelfsControl(label, color);

                return shelfsControl;
        }
    }


}
