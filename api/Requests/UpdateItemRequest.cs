namespace api.Requests;

public class UpdateItemRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
