using System.Reflection;
using MermaidDotNet.ClassDiagrams;
using MermaidDotNet.ClassDiagrams.Models;
using Type = System.Type;

namespace MermaidDotNet;

public class ClassDiagram
{
    public ClassDiagram(Type entryPoint)
    {
        var assembly = entryPoint.Assembly;
        // Récupérer tous les types définis dans l'assembly
        var types = assembly.GetTypes();

        // Filtrer pour obtenir uniquement les classes
        var classes = types.Where(t => t is { IsClass: true, IsAbstract: false });
        
        // Afficher les noms des classes
        foreach (var classe in classes)
        {
            Console.WriteLine($"Classe trouvée : {classe.FullName}");
        }
    }

    public Class ClassFromType(Type type)
    {
        var mermaidClass = new Class(type);
        mermaidClass.Methods = []; // on doit remplir ça
        // Remplir les méthodes
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        foreach (var methodInfo in methods)
        {
            if (methodInfo.IsSpecialName && (methodInfo.Name.StartsWith("get_") || methodInfo.Name.StartsWith("set_")))
            {
                if (methodInfo.ReturnType != typeof(void)) continue;
                mermaidClass.Properties.Add(new Property(methodInfo.Name.Remove(0, 4), methodInfo.ReturnType,
                    GetVisibility(methodInfo)));
                continue;
            }
            
            var method = new Method
            {
                Name = methodInfo.Name,
                Parameters = methodInfo.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}").ToList(),
                Return = methodInfo.ReturnType.Name,
                Visibility = GetVisibility(methodInfo)
            };

            mermaidClass.Methods.Add(method);
        }

        return mermaidClass;
    }
    
    private static Visibility GetVisibility(MethodInfo methodInfo)
    {
        if (methodInfo.IsPublic) return Visibility.Public;
        if (methodInfo.IsPrivate) return Visibility.Private;
        if (methodInfo.IsFamily) return Visibility.Protected;
        if (methodInfo.IsAssembly) return Visibility.Internal;
        if (methodInfo.IsFamilyOrAssembly) return Visibility.ProtectedInternal;
        if (methodInfo.IsFamilyAndAssembly) return Visibility.PrivateProtected;

        return Visibility.Private;
    }
}