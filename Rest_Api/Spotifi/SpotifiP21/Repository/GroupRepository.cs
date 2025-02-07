using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpotifyP21.Data;
using SpotifyP21.Dto;
using SpotifyP21.Entities;
using SpotifyP21.Repository.Interfaces;

namespace SpotifyP21.Repository;

public class GroupRepository(SpotifyContext spotifyContext) : IGroupRepository
{
    public async Task<List<GroupDto>> GetAllAsync() =>
         await spotifyContext.Groups.Select(
             group =>
                 new GroupDto
                 {
                     Id = group.Id,
                     Title = group.Title
                 })
             .ToListAsync();


    public async Task<GroupDetailsDto> GetDetailByIdAsync(int id) =>
        await spotifyContext.Groups
        .Include(group => group.Albums)
        .Select(
            group =>
                new GroupDetailsDto
                {
                    Id = group.Id,
                    Title = group.Title,
                    Albums = group.Albums
                    .Select(album => new AlbumDto
                    {
                        Id = album.Id,
                        Title = album.Title,
                        Photo = album.Photo
                    }).ToList()
                })
        .SingleAsync(group => group.Id == id);

    public async Task DeleteByIdAsync(int id)
    {
        var group = await spotifyContext.Groups.SingleAsync(group => group.Id == id);
        spotifyContext.Groups.Remove(group);

        await spotifyContext.SaveChangesAsync();
    }

    public async Task UpdateAsync([FromBody] UpdateGroupDto updateClientDto)
    {
        var group = await spotifyContext.Groups
            .Include(group => group.Genres)
            .Include(group => group.Albums)
            .SingleAsync(group => group.Id == updateClientDto.Id);

        group.Title = updateClientDto.Title;

        var genres = await spotifyContext.Genres
            .Where(genre => updateClientDto.Genres.Contains(genre.Id))
            .ToListAsync();

        var albums = await spotifyContext.Albums
            .Where(album => updateClientDto.Albums.Contains(album.Id))
            .ToListAsync();

        group.Genres.Clear();
        group.Albums.Clear();

        group.Genres = genres;
        group.Albums = albums;

        await spotifyContext.SaveChangesAsync();
    }

    public async Task CreateAsync(CreateGroupDto createGroupDto)
    {
        var genres = await spotifyContext.Genres
            .Where(genre => createGroupDto.Genres.Contains(genre.Id))
            .ToListAsync();

        var group = new Group
        {
            Title = createGroupDto.Title,
            Genres = genres
        };

        spotifyContext.Groups.Add(group);
        await spotifyContext.SaveChangesAsync();
    }
}
