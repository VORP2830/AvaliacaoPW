namespace AvaliacaoPW.Domain.Entities;

public class Employee : Person
{
    public string CompanyName { get; set; }
    public string BirthDate { get; set; }
    public string HireDate { get; set; }
    public string HomePhone { get; set; }
    public string Extension { get; set; }
    protected Employee()
    {
        Active = true;
    }
}
