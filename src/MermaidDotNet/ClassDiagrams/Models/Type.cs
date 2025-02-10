namespace MermaidDotNet.ClassDiagrams.Models;

/// <summary>
/// 
/// </summary>
/// <param name="type"></param>
public class Type(System.Type type)
{
    private readonly string _type = GetTypeName(type);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string GetTypeName(System.Type type)
    {
        if (!type.IsGenericType)
        {
            return type.Name;
        }

        // Get the generic type definition (e.g., Dictionary<,>)
        string genericTypeName = type.GetGenericTypeDefinition().Name;

        // Remove the backtick and the number of generic arguments
        int backtickIndex = genericTypeName.IndexOf('`');
        if (backtickIndex > 0)
        {
            genericTypeName = genericTypeName.Substring(0, backtickIndex);
        }

        // Get the generic arguments
        System.Type[] genericArguments = type.GetGenericArguments();
        string[] argumentNames = new string[genericArguments.Length];

        for (int i = 0; i < genericArguments.Length; i++)
        {
            argumentNames[i] = GetTypeName(genericArguments[i]);
        }

        // Combine the generic type name with the argument names
        return $"{genericTypeName}~{string.Join(", ", argumentNames)}~";
    }

    public override string ToString()
    {
        return _type;
    }
}