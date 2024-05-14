namespace AvaliacaoPW.Domain.Exceptions;
public class AvaliacaoPWException : Exception
{
    public AvaliacaoPWException(string message) : base(message) { }
    public static void When(bool hasError, string error)
    {
        if (hasError)
        {
            throw new AvaliacaoPWException(error);
        }
    }
}