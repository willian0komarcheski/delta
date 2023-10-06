namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string Tipo { get; set; }
    public long Quantidade {get; set; }
    public decimal Preco {get; set; }
}