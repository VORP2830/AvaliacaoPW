namespace AvaliacaoPW.Application.Dtos;

public class UserDto : ClientDto
{
    public string Login { get; set; }
    public string? Password { get; set; }
}
