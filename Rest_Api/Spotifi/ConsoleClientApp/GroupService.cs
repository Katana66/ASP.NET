using System.Net.Http.Json;

namespace ConsoleClientApp;

public class GroupService(HttpClient httpClient)
{
    private const string AddressService = "https://localhost:7009/Group";
    
    public async Task<List<GroupDto>> GetAllAsync()
    {
        using var response = await httpClient.GetAsync(AddressService);
        response.EnsureSuccessStatusCode();

        string content = await response.Content.ReadAsStringAsync();
        var groups = GroupDtoDeserializer.Deserialize(content);

        return groups;
    }

    public async Task CreateAsync(CreateGroupDto createGroupDto)
    {
        var jsonNewGroup = JsonContent.Create(createGroupDto);
        var response = await httpClient.PostAsync(AddressService, jsonNewGroup);

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(UpdateGroupDto updateGroupDto)
    {
        var jsonUpdateGroup = JsonContent.Create(updateGroupDto);
        var response = await httpClient.PutAsync(AddressService, jsonUpdateGroup);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await httpClient.DeleteAsync($"{AddressService}/{id}");
        response.EnsureSuccessStatusCode();
    }
}