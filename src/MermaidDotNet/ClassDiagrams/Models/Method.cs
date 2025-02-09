namespace MermaidDotNet.ClassDiagrams.Models;

public class Method
{
    public string Name { get; set; }
    public List<string> Parameters { get; set; }
    public Visibility Visibility { get; set; }
    public string Return { get; set; } = string.Empty;
    public List<string> Types { get; set; } = [];
    public override string ToString()
    {
        var types = Types.Count > 0 ? "~" + string.Join(", ", Types) + "~" : string.Empty;
        if (Return == "Void") Return = string.Empty;
        
        return $"{(char) Visibility} {Name}({string.Join(", ", Parameters)}){types} {Return}";
    }
}