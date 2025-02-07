namespace SpotifyP21.Dto;

public class UpdateGroupDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public ICollection<int>? Genres { get; set; }
    public ICollection<int>? Albums { get; set; }
}