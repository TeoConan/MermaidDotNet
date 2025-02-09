namespace MermaidDotNet.ClassDiagrams.Models;

/// <summary>
/// 
/// </summary>
/// <param name="text"></param>
/// <param name="parent"></param>
public class Note(string text, System.Type parent)
{
    private readonly string? _className = new Type(parent).ToString();

    /// <inheritdoc />
    public override string ToString()
    {
        return _className != null ? $"note for {_className}\"{text}\"" : $"note \"{text}\"";
    }
}