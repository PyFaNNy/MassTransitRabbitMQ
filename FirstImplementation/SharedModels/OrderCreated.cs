namespace SharedModels
{
    public interface OrderCreated
    {
        Guid Id { get; set; }
        string ProductName { get; set; }
        decimal Price { get; set; }
    }
}
