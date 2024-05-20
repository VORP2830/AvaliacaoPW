namespace AvaliacaoPW.Domain.Entities;

public class Employee : Person
{
    public string CompanyName { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateOnly HireDate { get; set; }
    public string HomePhone { get; set; }
    public string Extension { get; set; }
    protected Employee()
    {
        Active = true;
    }
}
