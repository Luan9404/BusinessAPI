namespace Api.Models.Response;

public class Response<T>
{

  public string Message { get; set; }
  public T Data { get; set; }
  public Response(T data)
  {
    Data = data;
    Message = null;
  }
  public Response(string message)
  {
    Data = default;
    Message = message;
  }
  public Response(T data, string message)
  {
    Data = data;
    Message = message;
  }
}