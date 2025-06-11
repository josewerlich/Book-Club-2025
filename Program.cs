using Book_Club_2025.BorrowModule;
using Book_Club_2025.ConsoleApp.Shared;

namespace Book_Club_2025
{
    class Program
    {
        static void Main(string[] args)
        {
            MainView mainView = new MainView();

            while (true)
            {
                mainView.ShowMainMenu();

                BaseView selectedView = mainView.GetView();

                if (selectedView == null)
                    break;

                char selectedOption = selectedView.ShowMenu();

                if (selectedOption == 'S')
                    break;

                if (selectedView is BorrowView)
                {
                    BorrowView borrowView = (BorrowView)selectedView;

                    switch (selectedOption)
                    {
                        case '1':
                            borrowView.BorrowingRegister();
                            break;

                        case '2':
                            borrowView.ReturnMagazine();
                            break;

                        case '3':
                            borrowView.ViewRegister(true);
                            break;
                    }
                }
                else
                {

                    switch (selectedOption)
                    {
                        case '1':
                            selectedView.AddRegister();
                            break;

                        case '2':
                            selectedView.ViewRegister(true);
                            break;

                        case '3':
                            selectedView.EditRegister();
                            break;

                        case '4':
                            selectedView.DeleteRegister();
                            break;

                    }
                }
            }
        }
    }
}
