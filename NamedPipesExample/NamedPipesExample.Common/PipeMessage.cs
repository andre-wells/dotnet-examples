namespace NamedPipesExample.Common;

[Serializable]
public class PipeMessage
{
    public PipeMessage()
    {
        Id = Guid.NewGuid();
        Text = string.Empty;
    }

    public Guid Id { get; set; }
    public ActionType Action { get; set; }
    public string Text { get; set; }
} 