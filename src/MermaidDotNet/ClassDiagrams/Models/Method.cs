using System.Reflection;

namespace MermaidDotNet.ClassDiagrams.Models;

/// <summary>
/// Represent a method in a class
/// </summary>
public class Method
{
    /// <summary>
    /// Name of method
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// String list of parameters of method
    /// </summary>
    public List<string> Parameters { get; }
    
    /// <summary>
    /// Current visibility of method
    /// </summary>
    public Visibility Visibility { get; }
    
    /// <summary>
    /// Base method infos
    /// </summary>
    public MethodInfo BaseInfo { get; }

    public System.Type Type { get; }

    private readonly string _output;

    /// <summary>
    /// Create a method from <see cref="MethodInfo"/>
    /// </summary>
    /// <param name="methodInfo"></param>
    public Method(MethodInfo methodInfo)
    {
        BaseInfo = methodInfo;
        Type = methodInfo.ReturnType;
        Name = methodInfo.Name.StartsWith("get_") || methodInfo.Name.StartsWith("set_")
            ? methodInfo.Name.Remove(0, 4) : methodInfo.Name;
        Parameters = methodInfo.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}").ToList();
        var returnType = methodInfo.ReturnType.Name;
        Visibility = GetVisibility(methodInfo);
        
        if (returnType == "Void") returnType = string.Empty;
        
        _output = $"{(char) Visibility} {Name}({string.Join(", ", Parameters)}) {returnType}";
    }

    private static Visibility GetVisibility(MethodInfo methodInfo)
    {
        return methodInfo switch
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