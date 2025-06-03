using Book_Club_2025.ConsoleApp.Shared;
using Book_Club_2025.FriendsModule;
using Book_Club_2025.ShelfsModule;

namespace Book_Club_2025.BorrowModule
{
    public class BorrowControl : BaseEntity
    {
        public int id;
        public string friend;
        public string magazine;
        public string date;
        public string status;

        public BorrowControl(string friend, string magazine, string date, string status)
        {
            this.friend = friend;
            this.magazine = magazine;
            this.date = date;
            this.status = status;
        }

     

        public override string Validate()
        {
            string errors = "";

            if (string.IsNullOrWhiteSpace(friend))
                errors += "The field \"Friend\" is required.\n";

            else if (friend.Length < 3)
                errors += "The field \"Friend\" needs at least 3 characters.\n";

            if (magazine.Length < 3)
                errors += "The field \"Magazine\" needs at least 3 characters.\n";

            if (string.IsNullOrWhiteSpace(date))
                errors += "The field \"Date\" is required. \n";

            if (string.IsNullOrWhiteSpace(status))
                errors += "The field \"Status\" is required. \n";

            return errors;
        }
        public override void UpdateRegister(BaseEntity registerUpdated)
        {
            BorrowControl borrowControl = (BorrowControl)registerUpdated;

            this.friend = borrowControl.friend;
            this.magazine = borrowControl.magazine;
            this.date = borrowControl.date;
            this.status = borrowControl.status;
        
        }
    }
    
    
}
