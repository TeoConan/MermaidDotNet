namespace MermaidDotNet.ClassDiagrams.Models;

/// <summary>
/// 
/// </summary>
/// <param name="inputClass"></param>
public class Class(System.Type inputClass)
{
    private string Name { get; set; } = new Type(inputClass).ToString();
    public List<Property> Properties { get; set; } = [];
    /// <summary>
    /// 
    /// </summary>
    public List<Method> Methods { get; set; } = [];

    /// <inheritdoc />
    public override string ToString()
    {
        var methods = string.Join("\n   ", Methods);
        var properties = string.Join("\n    ", Properties.Distinct().OrderBy(x => x.Name));
        
        return $"""
                class {Name} {"{"}
                    {properties}
                    {methods}
                {"}"}
                """;
    }
}