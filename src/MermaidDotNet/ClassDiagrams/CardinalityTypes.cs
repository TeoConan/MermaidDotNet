using System.ComponentModel;
using System.Reflection;

namespace MermaidDotNet.ClassDiagrams;

/// <summary>
/// Provides a set of predefined cardinality types used to specify the multiplicity
/// of relationships between classes in UML diagrams. Each cardinality type represents
/// a specific constraint on the number of instances that can participate in a relationship.
/// </summary>
public enum CardinalityTypes
{
    /// <summary>
    /// No cardinality specified.
    /// </summary>
    None,
    
    /// <summary>
    /// Exactly one.
    /// </summary>
    One,

    /// <summary>
    /// Zero or one.
    /// </summary>
    ZeroOrOne,

    /// <summary>
    /// Zero or more (unlimited).
    /// </summary>
    Many,

    /// <summary>
    /// Exactly n.
    /// </summary>
    N,

    /// <summary>
    /// Zero to n.
    /// </summary>
    ZeroToN,

    /// <summary>
    /// One to n.
    /// </summary>
    OneToN
}