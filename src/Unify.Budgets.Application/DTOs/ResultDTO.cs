namespace Unify.Budgets.Application.DTOs
{
    public class ResultDTO <T>
    {
        public bool Success { get; set; }
        public string Mensagem { get; set; }
        public T Data { get; set; }
    }
}
