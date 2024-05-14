namespace AvaliacaoPW.Domain.Entities;

public class User : Client
{
    public string Login { get; set; }
    public string Password { get; set; }
    protected User()
    {
        Active = true;
    }
    public void SetPassword(string password)
    {
        Password = password;
    }
}