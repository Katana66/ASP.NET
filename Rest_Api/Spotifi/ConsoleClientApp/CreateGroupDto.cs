namespace ConsoleClientApp;

public class CreateGroupDto
{
    public required string Title { get; set; }
    public List<int>? Genres { get; set; }
}