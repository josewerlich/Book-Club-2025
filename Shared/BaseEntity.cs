namespace Book_Club_2025.ConsoleApp.Shared;

public abstract class BaseEntity
{
    public int id;

    public abstract void UpdateRegister(BaseEntity registerUpdated);
    public abstract string Validate();
}
