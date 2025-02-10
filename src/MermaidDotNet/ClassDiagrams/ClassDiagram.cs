using System.Reflection;
using MermaidDotNet.ClassDiagrams.Models;
using Type = System.Type;

namespace MermaidDotNet.ClassDiagrams;

/// <summary>
/// Create a class diagram for Mermaid
/// </summary>
public class ClassDiagram
{
    private readonly Dictionary<Type, Class> _classes;
    private readonly string? _title;
    private readonly List<Relation> _relations;
    
    /// <summary>
    /// Build a new Mermaid class diagram 
    /// </summary>
    /// <param name="entryPoint"></param>
    /// <param name="title"></param>
    public ClassDiagram(Type entryPoint, string? title = null)
    {
        _title = title;
        _relations = [];
        _classes = new Dictionary<Type, Class>();

        // Get all classes of assembly
        entryPoint.Assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false })
            .Distinct()
            .ToList()
            .ForEach(t => _classes.Add(t, ClassFromType(t)));
        
        BuildRelations();
    }
    
    private void BuildRelations()
    {
        foreach (var c in _classes.Values)
        {
            foreach (var relatable in _classes.Values)
            {
                if (relatable.Type == c.Type) continue;
                //if (relatable.Type.IsSubclassOf(c.Type)) _relations.Add(new Relation(RelationTypes.Aggregation, c, CardinalityTypes.One, relatable, CardinalityTypes.One));
                if (relatable.Type.IsAssignableFrom(c.Type)) _relations.Add(new Relation(RelationTypes.Inheritance, c, CardinalityTypes.One, relatable, CardinalityTypes.One));
            }
            
            foreach (var prop in c.Properties)
            {
                // TODO if list
                if (_classes.TryGetValue(prop.Type, out var propClass))
                {
                    _relations.Add(new Relation(RelationTypes.Composition, c, CardinalityTypes.One, propClass, CardinalityTypes.One));
                }
            }

            foreach (var method in c.Methods)
            {
                // TODO if list
                if (_classes.TryGetValue(method.Type, out var methodClass))
                {
                    _relations.Add(new Relation(RelationTypes.Dependency, c, CardinalityTypes.One, methodClass, CardinalityTypes.One));
                }
            }
        }
    }
    
    private static Class ClassFromType(Type type)
    {
        var mermaidClass = new Class(type)
        {
            Methods = []
        };

        // Build method of class
        type.GetMethods(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(m => !m.IsSpecialName
                        || !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_"))
            .ToList()
            .ForEach(m => mermaidClass.Methods.Add(new Method(m)));

        // Build property class
        type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
            .ToList()
            .ForEach(p => mermaidClass.Properties.Add(new Property(p)));

        return mermaidClass;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var output = _title is null ? string.Empty : 
            $"""
             ---
             title: {_title}
             ---
             
             """;
        
        output += "classDiagram";

        foreach (var c in _classes.Values)
        {
            output += "\n" + c;
        }
        
        foreach (var r in _relations)
        {
            output += "\n" + r;
        }

        return output;
    }
}