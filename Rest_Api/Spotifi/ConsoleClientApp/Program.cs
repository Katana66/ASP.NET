using ConsoleClientApp;
using System.Net.Http.Json;

var groupService = new GroupService(new());

foreach(var group in await groupService.GetAllAsync())
{
    Console.WriteLine(group);
}

Console.WriteLine();

await groupService.CreateAsync(new CreateGroupDto
{ 
    Title = "Bob Dylan"
});

foreach (var group in await groupService.GetAllAsync())
{
    Console.WriteLine(group);
}

Console.WriteLine();


await groupService.UpdateAsync(new UpdateGroupDto
{
    Id = 9,
    Title = "Michael Jackson"
});

foreach (var group in await groupService.GetAllAsync())
{
    Console.WriteLine(group);
}

Console.WriteLine();

await groupService.DeleteAsync(9);

foreach (var group in await groupService.GetAllAsync())
{
    Console.WriteLine(group);
}

Console.WriteLine();

Console.ReadLine();