namespace AvaliacaoPW.Application.Dtos;

public class EmployeeDto : PersonDto
{
    public string CompanyName { get; set; }
    public string BirthDate { get; set; }
    public string HireDate { get; set; }
    public string HomePhone { get; set; }
    public string Extension { get; set; }
}
