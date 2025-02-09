using MermaidDotNet.ClassDiagrams.Models;

namespace MermaidDotNet.ClassDiagrams;

using System;

public interface IRelatable
{
    List<Relation> Relations { get; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="inCardinality"></param>
    /// <param name="outCardinality"></param>
    public void InheritsFrom(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);
    void IsInheritedBy(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);

    // Composition
    void Composes(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);
    void IsComposedBy(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);

    // Aggregation
    void Aggregates(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);
    void IsAggregatedBy(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);

    // Association
    void AssociatesWith(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);
    void IsAssociatedWith(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);

    // Dependency
    void DependsOn(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);
    void IsDependedOnBy(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);

    // Realization
    void Realizes(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);
    void IsRealizedBy(Type type, CardinalityTypes inCardinality = CardinalityTypes.None,
        CardinalityTypes outCardinality = CardinalityTypes.None);
}
