namespace MermaidDotNet.ClassDiagrams.Models;

/// <summary>
/// Represent a (pair) of cardinality in a <see cref="Relation"/>
/// </summary>
/// <param name="in">Subject's cardinality</param>
/// <param name="out">Destination's cardinality</param>
public class Cardinality(CardinalityTypes @in, CardinalityTypes @out)
{
    /// <summary>
    /// Subject's cardinality
    /// </summary>
    public CardinalityTypes In { get; } = @in;
    
    /// <summary>
    /// Destination's cardinality
    /// </summary>
    public CardinalityTypes Out { get; } = @out;

    public string GetIn() => Get(In);
    public string GetOut() => Get(In);

    /// <summary>
    /// Convert a <see cref="CardinalityTypes"/> as a string for class diagram
    /// </summary>
    /// <param name="cardinality"></param>
    /// <returns>Converted string</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string Get(CardinalityTypes cardinality)
    {
        return cardinality switch
        {
            CardinalityTypes.One => "1",
            CardinalityTypes.ZeroOrOne => "0..1",
            CardinalityTypes.Many => "*",
            CardinalityTypes.N => "n",
            CardinalityTypes.ZeroToN => "0..n",
            CardinalityTypes.OneToN => "1..n",
            CardinalityTypes.None => string.Empty,
            _ => throw new ArgumentOutOfRangeException(nameof(cardinality), cardinality, null)
        };
    }
}