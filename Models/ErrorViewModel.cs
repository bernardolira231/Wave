namespace Wave.Models;

public class ErrorViewModel
{
    //Prueba de comentario
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
