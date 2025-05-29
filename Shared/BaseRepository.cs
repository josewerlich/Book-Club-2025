namespace Book_Club_2025.ConsoleApp.Shared;

public abstract class BaseRepository
{
    private BaseEntity[] register = new BaseEntity[100];
    private int registerCounter = 0;

    public void DataRegister(BaseEntity newRegister)
    {
        register[registerCounter] = newRegister;

        registerCounter++;
    }

    public bool EditRegister(int idSelected, BaseEntity registerUpdate)
    {
        BaseEntity selectedRegister = SelectRegisterID(idSelected);

        if (selectedRegister == null)
            return false;

        selectedRegister.UpdateRegister(registerUpdate);

        return true;
    }

    public bool DeleteRegister(int idSelecionado)
    {
        for (int i = 0; i < register.Length; i++)
        {
            if (register[i] == null)
                continue;

            else if (register[i].id == idSelecionado)
            {
                register[i] = null;

                return true;
            }
        }

        return false;
    }

    public BaseEntity[] SelectRegister()
    {
        return register;
    }

    public BaseEntity SelectRegisterID(int idSelected)
    {
        for (int i = 0; i < register.Length; i++)
        {
            BaseEntity Register = register[i];

            if (Register == null)
                continue;

            if (Register.id == idSelected)
                return Register;
        }

        return null;
    }
}
