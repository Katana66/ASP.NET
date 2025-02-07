using SpotifyP21.Entities;

namespace SpotifyP21.Dto;

public class CreateGroupDto
{
    public required string Title { get; set; }
    public List<int>? Genres { get; set; }
}