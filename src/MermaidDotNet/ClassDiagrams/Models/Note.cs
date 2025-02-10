namespace MermaidDotNet.ClassDiagrams.Models;

/// <summary>
/// A simple note in a class diagram linked to a class
/// </summary>
/// <param name="text">Text to display</param>
/// <param name="parent">Linked class</param>
public class Note(string text, System.Type? parent = null)
{
    private readonly string? _className = parent != null ? new Type(parent).ToString() : null;

    /// <inheritdoc />
    public override string ToString()
    {
        return _className != null ? $"note for {_className}\"{text}\"" : $"note \"{text}\"";
    }
}