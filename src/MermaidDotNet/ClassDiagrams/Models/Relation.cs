namespace MermaidDotNet.ClassDiagrams.Models;

/// <summary>
/// Represent a relation in a class diagram
/// </summary>
public class Relation
{
    /// <summary>
    /// From / Input class name
    /// </summary>
    public string From { get; set; }
    
    /// <summary>
    /// To / Destination class name
    /// </summary>
    public string To { get; set; }
    
    /// <summary>
    /// Type of relation between From and To
    /// </summary>
    public RelationTypes RelationType { get; set; }
    
    /// <summary>
    /// Opt. Relation's label
    /// </summary>
    public string? Label { get; set; }

    private string _output;
    private Cardinality _cardinality;
    
    public Relation(RelationTypes relation,
        Class inputClass,
        CardinalityTypes inCardinality,
        Class outputClass,
        CardinalityTypes outCardinality,
        string? label = null)
    {
        RelationType = relation;
        _cardinality = new Cardinality(inCardinality, outCardinality);
        
        _output = relation switch
        {
            RelationTypes.Inheritance => "--|>",
            RelationTypes.Composition => "--*",
            RelationTypes.Aggregation => "--o",
            RelationTypes.Association => "-->",
            RelationTypes.Link => "--",
            RelationTypes.DashedLink => "..",
            RelationTypes.Dependency => "",
            RelationTypes.Realization => "..|>",
            _ => throw new ArgumentOutOfRangeException()
        };
        
        _output = $"{inputClass.Name} \"{_cardinality.GetIn()}\" {_output} \"{_cardinality.GetOut()}\" {outputClass.Name}";
        if (label != null) _output = $"{_output} : {label}";
    }

    public override string ToString()
    {
        return _output;
    }

    public string ToString(System.Type self, System.Type destination)
    {
        return ToString(self.Name, destination.Name);
    }

    public string ToString(string self, string destination)
    {
        var inCardinality = Cardinality.Get(_cardinality.In);
        var outCardinality = Cardinality.Get(_cardinality.Out);
        var label = Label != null ? " : " + Label : string.Empty;
        
        return $"{self} {inCardinality} {outCardinality} {destination}{label}";
    }
}