
using Book_Club_2025.ConsoleApp.Shared;
using Book_Club_2025.ShelfsModule;

namespace Book_Club_2025.MagazinesModule;

public class MagazineControl : BaseEntity
{
    public int id;
    public string title;
    public string editionYear;
    public string borrowingStatus;
    public string shelfID;

    public MagazineControl(string title, string editionYear, string borrowingStatus, string shelfID)
    {
        this.title = title;
        this.editionYear = editionYear;
        this.borrowingStatus = borrowingStatus;
        this.shelfID = shelfID;
    }

    public override string Validate()
    {
        string errors = "";

        if (string.IsNullOrWhiteSpace(title))
            errors += "The field \"Title\" is required.\n";

        else if (title.Length < 3)
            errors += "The field \"Title\" needs at least 3 characters.\n";

        if (editionYear.Length < 3)
            errors += "The field \"Edition Year\" needs at least 3 characters.\n";

        return errors;
    }
    public override void UpdateRegister(BaseEntity registerUpdated)
    {
        MagazineControl magazineControl = (MagazineControl)registerUpdated;

        this.title = magazineControl.title;
        this.editionYear = magazineControl.editionYear;
        this.borrowingStatus = magazineControl.borrowingStatus;
        this.shelfID=  magazineControl.shelfID;
    }
    public string Borrow()
    {
        if (borrowingStatus == "Borrowed")
        {
            return $"The magazine \"{title}\" is already borrowed.";
        }

        borrowingStatus = "Borrowed";
        return $"The magazine \"{title}\" has been successfully borrowed.";
    }

    public string Return()
    {
        if (borrowingStatus == "Available")
        {
            return $"The magazine \"{title}\" is already available.";
        }

        borrowingStatus = "Available";
        return $"The magazine \"{title}\" has been successfully returned.";
    }
}



