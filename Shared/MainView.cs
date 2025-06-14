﻿
using Book_Club_2025.BorrowModule;
using Book_Club_2025.FriendsModule;
using Book_Club_2025.MagazinesModule;
using Book_Club_2025.ShelfsModule;

namespace Book_Club_2025.ConsoleApp.Shared;

public class MainView
{
    private char userOption;

    private ShelfsRepository shelfsRepository;
    private ShelfsView shelfsView;

    private FriendsRepository friendsRepository;
    private FriendsView friendsView;    

    private MagazineRepository magazineRepository;
    private MagazineView magazineView;

    private BorrowRepository borrowRepository;
    private BorrowView borrowView;
    
 

    public MainView()
    {
        magazineRepository = new MagazineRepository();
        borrowRepository = new BorrowRepository();
        friendsRepository = new FriendsRepository();
        shelfsRepository = new ShelfsRepository();


        shelfsView = new ShelfsView(shelfsRepository);
        friendsView = new FriendsView(friendsRepository);
        magazineView = new MagazineView(magazineRepository, shelfsRepository);
        borrowView = new BorrowView(borrowRepository, friendsRepository, magazineRepository);

        FriendsControl friend = new FriendsControl("Rodri", "Pepe", "49 99999-3333");
        friendsRepository.AddRegister(friend);

        ShelfsControl shelf = new ShelfsControl("Comedy", "Red");
        shelfsRepository.AddRegister(shelf);

        MagazineControl magazine = new MagazineControl("The Google", 2, 2020, shelf);
        magazineRepository.AddRegister(magazine);


    }
    public void ShowMainMenu()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|             Book Club 2025            |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Magazines Control");
        Console.WriteLine("2 - User Control");
        Console.WriteLine("3 - Shelfs Control");
        Console.WriteLine("4 - Borrowing Control");
        Console.WriteLine("E - Exit");

        Console.WriteLine();

        Console.Write("Select one option: ");
        userOption = Console.ReadLine()[0];
    }

    public BaseView GetView()
    {
        if (userOption == '1')
            return magazineView;

        if (userOption == '2')
            return friendsView;

        if (userOption == '3')
            return shelfsView;

        if (userOption == '4')
            return borrowView;

        return null;
    }
}
