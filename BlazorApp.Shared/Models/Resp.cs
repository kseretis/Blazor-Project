namespace BlazorApp.Shared.Models;

public record Resp
{
    public string id { get; set; }
    public string name { get; set; }
    public object data { get; set; }
}