using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Editing;

public class VbNetToCSharpConverter
{
    public static string ConvertVbToCSharp(string vbCode)
    {
        var tree = VisualBasicSyntaxTree.ParseText(vbCode);
        var root = tree.GetRoot();

        var workspace = new AdhocWorkspace();
        var options = workspace.Options.WithChangedOption(FormattingOptions.NewLine, LanguageNames.CSharp, "\n");
        
        var converter = new Microsoft.CodeAnalysis.VisualBasic.CSharpConverter();
        var csharpNode = converter.ConvertCompilationTree(root);
        
        var formattedCode = Formatter.Format(csharpNode, workspace, options);
        return formattedCode.ToFullString();
    }

    public static void Main()
    {
        string vbCode = @"""
        Module Module1
            Sub Main()
                Dim x As Integer = 10
                Console.WriteLine("Hello, World!")
            End Sub
        End Module
        """;

        string csharpCode = ConvertVbToCSharp(vbCode);
        Console.WriteLine(csharpCode);
    }
}
