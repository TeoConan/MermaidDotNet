namespace MermaidDotNet.ClassDiagrams;

/// <summary>
/// Type of relation in class diagram
/// <see cref="https://mermaid.js.org/syntax/classDiagram.html#defining-relationship"/>
/// </summary>
public enum RelationTypes
{
    /// <summary>
    /// Inheritance relation 
    /// </summary>
    Inheritance,
    
    /// <summary>
    /// Composition relation
    /// </summary>
    Composition,
    
    /// <summary>
    /// Aggregation relation
    /// </summary>
    Aggregation,
    
    /// <summary>
    /// Association relation
    /// </summary>
    Association,
    
    /// <summary>
    /// Simple link
    /// </summary>
    Link,
    
    /// <summary>
    /// Simple link but dashed
    /// </summary>
    DashedLink,
    
    /// <summary>
    /// Dependency relation
    /// </summary>
    Dependency,
    
    /// <summary>
    /// Realization relation
    /// </summary>
    Realization,
}