namespace MermaidDotNet.ClassDiagrams.Models;

public class Property(string name, System.Type type, Visibility visibility)
{
    public string Name { get; } = name;
    public Visibility Visibility { get; } = visibility;
    public string Type { get; set; } = new Type(type).ToString();

    public override string ToString()
    {
        if (Type == "Void") Type = "";
        return $"{(char) Visibility}{Type} {Name}";
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Visibility, Type);
    }
}