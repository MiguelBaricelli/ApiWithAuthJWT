namespace ApiWithTokenJWT.Model;

//<T> tranforma em modelo genérico, pode retornar qualquer modelo
public class Response<T>
{
    public T? Dados { get; set; }

    public string Message { get; set; } = string.Empty;

    public bool Status { get; set; }
}