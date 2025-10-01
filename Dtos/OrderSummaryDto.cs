public record OrderSummaryDto
{
    public int OrderId { get; set; } = 0;
    public string CustomerName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal TotalCost { get; set; } = 0;
};