namespace bookIt.Application.Dtos;

public class ServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }
    public int CategoryId { get; set; }
}

public class CreateServiceDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int DurationMinutes { get; set; }
    public int CategoryId { get; set; }
    public int BusinessId { get; set; } // Needed to associate with the correct business
}