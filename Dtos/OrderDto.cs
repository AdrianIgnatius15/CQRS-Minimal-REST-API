public record OrderDto
{
    public int Id { get; init; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public decimal TotalCost { get; init; }
}