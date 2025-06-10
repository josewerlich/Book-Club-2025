
using Book_Club_2025.ConsoleApp.Shared;
using Book_Club_2025.ShelfsModule;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Book_Club_2025.MagazinesModule;

public class MagazineControl : BaseEntity
{
    public int id;
    public string Title;
    public int Edition;
    public int PublishedYear;
    public ShelfsControl ShelfsControl;
    public string Status;

    public MagazineControl(string title, int edition, int publishedYear, ShelfsControl shelfsControl)
    {
        Title = title;
        Edition = edition;
        PublishedYear = publishedYear;
        ShelfsControl = shelfsControl;
        Status = "Available";
    }

    public override string Validate()
    {
        string errors = "";

        if (string.IsNullOrWhiteSpace(Title))
            errors += "The field \"Title\" is required.\n";

        else if (Title.Length < 3)
            errors += "The field \"Title\" needs at least 3 characters.\n";

        if (Edition < 1)
            errors += "The field \"Edition Year\" needs at least 1 number.\n";

        if (PublishedYear < DateTime.MinValue.Year || PublishedYear > DateTime.Now.Year)
            errors += "The field \"Published Year\" need to have an past year or this actual year.";

        if (ShelfsControl == null)
            errors += "The field \"Shelf\" is required.";

        return errors;
    }
    public override void UpdateRegister(BaseEntity registerUpdated)
    {
        MagazineControl magazineControl = (MagazineControl)registerUpdated;

        Title = magazineControl.Title;
        Edition = magazineControl.Edition;
        PublishedYear = magazineControl.PublishedYear;
        ShelfsControl = magazineControl.ShelfsControl;

    }

}
