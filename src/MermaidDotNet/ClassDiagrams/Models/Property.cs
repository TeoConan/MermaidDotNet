using System.Reflection;

namespace MermaidDotNet.ClassDiagrams.Models;

/// <summary>
/// Represent a property in a class
/// </summary>
public class Property
{
    /// <summary>
    /// Name of property
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Type of property as string
    /// </summary>
    public System.Type Type { get; }
    
    /// <summary>
    /// Maximum visibility of property in class
    /// </summary>
    public Visibility Visibility { get; set; }

    private readonly string _output;

    /// <summary>
    /// Create a property usable in a Mermaid class diagram
    /// </summary>
    /// <param name="property"></param>
    public Property(PropertyInfo property)
    {
        Type = property.PropertyType;
        Name = property.Name;
        Visibility = GetVisibility(property);
        
        var type = Models.Type.GetTypeName(Type);
        if (type == "Void") type = "";
        _output = $"{(char) Visibility}{type} {Name}";
    }
    
    private static Visibility GetVisibility(PropertyInfo propertyInfo)
    {
        var method = propertyInfo.GetMethod ?? propertyInfo.SetMethod;
        if (method == null) return Visibility.Private;

        return method switch
        {
            { IsPublic: true } => Visibility.Public,
            { IsPrivate: true } => Visibility.Private,
            { IsFamily: true } => Visibility.Protected,
            { IsAssembly: true } => Visibility.Internal,
            { IsFamilyOrAssembly: true } => Visibility.ProtectedInternal,
            { IsFamilyAndAssembly: true } => Visibility.PrivateProtected,
            _ => Visibility.Private
        };
    }

    /// <inheritdoc />
    public override string ToString() => _output;
}