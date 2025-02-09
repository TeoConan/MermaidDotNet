using MermaidDotNet.ClassDiagrams.Models;
using Type = System.Type;

namespace MermaidDotNet.ClassDiagrams;

public class Relatable : IRelatable
{
    /// <summary>
    /// 
    /// </summary>
    public List<Relation> Relations { get; } = new List<Relation>();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="inCardinality"></param>
    /// <param name="outCardinality"></param>
    public void InheritsFrom(Type type, CardinalityTypes inCardinality = CardinalityTypes.None, CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        Relations.Add(new Relation(RelationTypes.Inheritance, inCardinality, outCardinality));
    }

    public void IsInheritedBy(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }

    public void Composes(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }

    public void IsComposedBy(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }

    public void Aggregates(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }

    public void IsAggregatedBy(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }

    public void AssociatesWith(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }

    public void IsAssociatedWith(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }

    public void DependsOn(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }

    public void IsDependedOnBy(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }

    public void Realizes(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }

    public void IsRealizedBy(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None)
    {
        throw new NotImplementedException();
    }
}