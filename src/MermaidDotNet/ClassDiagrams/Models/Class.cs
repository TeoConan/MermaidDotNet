namespace MermaidDotNet.ClassDiagrams.Models;

/// <summary>
/// 
/// </summary>
/// <param name="inputClass"></param>
public class Class(System.Type inputClass)
{
    /// <summary>
    /// Base's type of Class
    /// </summary>
    public System.Type Type { get; } = inputClass;
    public string Name { get; } = new Type(inputClass).ToString();
    /// <summary>
    /// 
    /// </summary>
    public List<Property> Properties { get; } = [];
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