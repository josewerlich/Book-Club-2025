
using Book_Club_2025.ConsoleApp.Shared;

namespace Book_Club_2025.BorrowModule;

public class BorrowRepository : BaseRepository
{
    public BorrowControl[] SelectActiveBorrowing()
    {
        int registerCounter = 0;

        for (int i = 0; i < register.Length; i++)  
        {
            BorrowControl actualBorrowing = (BorrowControl)register[i];

            if (actualBorrowing == null)
                continue;

            if (actualBorrowing.Status == "Open" || actualBorrowing.Status == "Delayed")
                registerCounter++;
        }

        BorrowControl[] activeBorrowing = new BorrowControl[registerCounter];

        int anotherCounter = 0;

        for (int i = 0; i < register.Length; i++)
        {
            BorrowControl actualBorrowing = (BorrowControl)register[i];

            if (actualBorrowing == null)
                continue;

            if (actualBorrowing.Status == "Open" || actualBorrowing.Status == "Delayed")
            {
                activeBorrowing[anotherCounter++] = (BorrowControl)register[i];
            }
        }

        return activeBorrowing;
    }
}

    
    

