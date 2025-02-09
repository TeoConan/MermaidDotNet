namespace MermaidDotNet.ClassDiagrams.Models;

public class Relation
{
    private string _name;
    private Cardinality _cardinality;
    private RelationTypes _relationType;
    private bool _dashed;
    
    public Relation(RelationTypes relation, CardinalityTypes inCardinality, CardinalityTypes outCardinality, string? label = null, bool dashed = false)
    {
        _relationType = relation;
        _dashed = dashed;
        _cardinality = new Cardinality(inCardinality, outCardinality, label);
    }

    public override string ToString()
    {
        var relation = _relationType switch
        {
            RelationTypes.Inheritance => "--/>",
            RelationTypes.Composition => "--*",
            RelationTypes.Aggregation => "--o",
            RelationTypes.Association => "-->",
            RelationTypes.Link => "--",
            RelationTypes.Dependency => "",
            RelationTypes.Realization => "</--",
            _ => throw new ArgumentOutOfRangeException()
        };
        
        if (_dashed) relation = relation.Replace("--", "..");
        return relation;
    }

    public string ToString(System.Type self, System.Type destination)
    {
        return ToString(self.Name, destination.Name);
    }

    public string ToString(string self, string destination)
    {
        var inCardinality = Cardinality.Get(_cardinality.In);
        var outCardinality = Cardinality.Get(_cardinality.Out);
        var label = _cardinality.Label != null ? " : " + _cardinality.Label : string.Empty;
        
        return $"{self} {inCardinality} {outCardinality} {destination}{label}";
    }
}