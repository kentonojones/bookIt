namespace bookIt.Application.Dtos
{
    public class CreateBusinessDto
    {
        public string Name { get; set; }
        public int OwnerId { get; set; }
    }

    public class UpdateBusinessDto
    {
        public string Name { get; set; }
    }
}