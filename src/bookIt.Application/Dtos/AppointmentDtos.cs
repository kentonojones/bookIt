namespace bookIt.Application.Dtos;

public class AppointmentDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int ClientId { get; set; }
    public int ServiceId { get; set; }
    public int StaffMemberId { get; set; }
    public string Status { get; set; }
}

public class CreateAppointmentDto
{
    public DateTime StartTime { get; set; }
    public int ServiceId { get; set; }
    public int StaffMemberId { get; set; }
    // ClientId will be taken from the authenticated user's token
}