using Book_Club_2025.ConsoleApp.Shared;
using Book_Club_2025.MagazinesModule;

namespace Book_Club_2025.FriendsModule
{
    public class FriendsControl : BaseEntity
    {

        public int id;
        public string name;
        public string responsible;
        public string phone;


        public FriendsControl(string name, string responsible, string phone)
        {
            this.name = name;
            this.responsible = responsible;
            this.phone = phone;
        }

        public override string Validate()
        {
            string errors = "";

            if (string.IsNullOrWhiteSpace(name))
                errors += "The field \"Name\" is required.\n";

            else if (name.Length < 3)
                errors += "The field \"Name\" needs at least 3 characters.\n";

            if (responsible.Length < 3)
                errors += "The field \"Responsible\" needs at least 3 characters.\n";

            return errors;
        }
        public override void UpdateRegister(BaseEntity registerUpdated)
        {
           FriendsControl friendsControl = (FriendsControl)registerUpdated;

            this.name = friendsControl.name;
            this.responsible = friendsControl.responsible;
            this.phone = friendsControl.phone;
            
        }
    }
}
