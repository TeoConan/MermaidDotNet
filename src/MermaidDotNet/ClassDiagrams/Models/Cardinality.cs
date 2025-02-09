namespace MermaidDotNet.ClassDiagrams.Models;

/// <summary>
/// 
/// </summary>
/// <param name="in"></param>
/// <param name="out"></param>
/// <param name="label"></param>
public class Cardinality(CardinalityTypes @in, CardinalityTypes @out, string? label = null)
{
    /// <summary>
    /// 
    /// </summary>
    public CardinalityTypes In { get; set; } = @in;
    
    /// <summary>
    /// 
    /// </summary>
    public CardinalityTypes Out { get; set; } = @out;
    
    /// <summary>
    /// 
    /// </summary>
    public string? Label { get; set; } = label;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="cardinality"></param>
    /// <returns></returns>
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