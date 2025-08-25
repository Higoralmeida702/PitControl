namespace PitControl.Application.Common
{
    public class Resposta<T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

        public Resposta(T dados, string mensagem, bool status = true)
        {
            Dados = dados;
            Mensagem = mensagem;
            Status = status;
        }
    }
}