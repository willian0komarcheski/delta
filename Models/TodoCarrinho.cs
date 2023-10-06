namespace TodoApi.Models;

public class TodoCarrinho
{
    public long Id { get; set; }
    private List<TodoItem> produtos = new List<TodoItem>();
    public decimal ValorTotal { get; set; }
    public TodoLogin login {get; set; }
    public List<TodoItem> Produtos
    {
        get { return produtos; }
        set { produtos = value; }
    }

     public void AddTodoItem(TodoItem produto)
    {
        produtos.Add(produto);
    }
}