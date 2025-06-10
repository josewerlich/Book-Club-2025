
using Book_Club_2025.ConsoleApp.Shared;
using Microsoft.Win32;

namespace Book_Club_2025.MagazinesModule;

   public class MagazineRepository : BaseRepository
    {
    public MagazineControl[] SelectActiveMagazines()
    {
        int activeMagazinesCounter = 0;

        for (int i = 0; i < register.Length; i++)
        {
            MagazineControl actualMagazine = (MagazineControl)register[i];

            if (actualMagazine == null)
                continue;

            if (actualMagazine.Status == "Available")
                activeMagazinesCounter++;
        }

        MagazineControl[] availableMagazines = new MagazineControl[activeMagazinesCounter];

        int anotherCounter = 0;

        for (int i = 0; i < register.Length; i++)
        {
            MagazineControl actualMagazine = (MagazineControl)register[i];

            if (actualMagazine == null)
                continue;

            if (actualMagazine.Status == "Available")
            {
                availableMagazines[anotherCounter++] = (MagazineControl)register[i];
            }
        }

        return availableMagazines;
    }
}
    
    
