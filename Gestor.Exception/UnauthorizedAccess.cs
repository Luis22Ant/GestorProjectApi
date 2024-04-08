namespace Gestor.Exception;

public class UnauthorizedAccess : GestorException
{
    public UnauthorizedAccess(string message) : base(message)
    {
    }
}
