namespace Book_Club_2025.ConsoleApp.Shared;

public abstract class BaseRepository
{
    private BaseEntity[] registros = new BaseEntity[100];
    private int contadorRegistros = 0;

    public void CadastrarRegistro(BaseEntity novoRegistro)
    {
        registros[contadorRegistros] = novoRegistro;

        contadorRegistros++;
    }

    public bool EditarRegistro(int idSelecionado, BaseEntity registroAtualizado)
    {
        BaseEntity registroSelecionado = SelecionarRegistroPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        registroSelecionado.UpdateRegister(registroAtualizado);

        return true;
    }

    public bool ExcluirRegistro(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
                continue;

            else if (registros[i].id == idSelecionado)
            {
                registros[i] = null;

                return true;
            }
        }

        return false;
    }

    public BaseEntity[] SelecionarRegistros()
    {
        return registros;
    }

    public BaseEntity SelecionarRegistroPorId(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            BaseEntity registro = registros[i];

            if (registro == null)
                continue;

            if (registro.id == idSelecionado)
                return registro;
        }

        return null;
    }
}
