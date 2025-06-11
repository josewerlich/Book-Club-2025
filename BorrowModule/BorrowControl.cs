using Book_Club_2025.ConsoleApp.Shared;
using Book_Club_2025.FriendsModule;
using Book_Club_2025.MagazinesModule;


namespace Book_Club_2025.BorrowModule
{
    public class BorrowControl : BaseEntity
    {
        public FriendsControl FriendsControl;
        public MagazineControl MagazineControl;
        public DateTime BorrowingDate;
        public DateTime ReturningDate;
        public string Status;

        public BorrowControl(FriendsControl friendsControl, MagazineControl magazineControl)
        {
            FriendsControl = friendsControl;
            MagazineControl = magazineControl;
            BorrowingDate = DateTime.Now;
            ReturningDate = BorrowingDate.AddDays(MagazineControl.ShelfsControl.borrowingDays);
            Status = "Open";
        }
        public override void UpdateRegister(BaseEntity registerUpdated)
        {
            Status = "Completed";
        }
        public override string Validate()
        {
            string errors = string.Empty;

            if (FriendsControl == null)
                errors += "The field \"Friend\" is required.";

            if (MagazineControl == null)
                errors += "The field \"Magazine\" is required.";

            return errors;
        }
        
    }
    
}
