namespace ConsoleClientApp;

public class GroupDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }

    public override string ToString() =>
        $"Id: {Id}, Title: {Title}";
}