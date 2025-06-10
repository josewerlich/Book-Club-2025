
using Book_Club_2025.ConsoleApp.Shared;

namespace Book_Club_2025.ShelfsModule;

public class ShelfsControl : BaseEntity
{
    public int id;
    public string label;
    public string color;
    public int borrowingDays;

    public ShelfsControl(string label, string color)
    {
        this.label = label;
        this.color = color;
        this.borrowingDays = 7;
    }
    public ShelfsControl(string label, string color, int borrowingDays)
    {
        this.label = label;
        this.color = color;
        this.borrowingDays = borrowingDays;
    }

    public override string Validate()
    {
        string errors = "";

        if (string.IsNullOrWhiteSpace(label))
            errors += "The field \"Label\" is required.\n";

        else if (label.Length < 3)
            errors += "The field \"Label\" needs at least 3 characters.\n";

        if (color.Length < 3)
            errors += "The field \"Color\" needs at least 3 characters.\n";

        return errors;
    }
    public override void UpdateRegister(BaseEntity registerUpdated)
    {
        ShelfsControl shelfsControl = (ShelfsControl)registerUpdated;

        this.label = shelfsControl.label;
        this.color = shelfsControl.color;
        this.borrowingDays = shelfsControl.borrowingDays;
    }
}

