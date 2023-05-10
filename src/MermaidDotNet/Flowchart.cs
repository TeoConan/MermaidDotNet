﻿using MermaidDotNet.Models;
using System.Text;

namespace MermaidDotNet;

public class Flowchart
{
    public string Direction { get; set; }
    public List<Node> Nodes { get; set; }
    public List<Link> Links { get; set; }

    public Flowchart(string direction, List<Node> nodes, List<Link> links)
    {
        if (direction != "LR" && direction != "TD")
        {
            throw new Exception("Direction " + direction + " is currently unsupported");
        }
        else
        {
            Direction = direction;
        }
        Nodes = nodes;
        Links = links;
    }

    public string CalculateFlowchart()
    {
        StringBuilder sb = new();
        sb.Append("flowchart " + Direction + Environment.NewLine);

        //Add nodes
        foreach (Node node in Nodes)
        {
            sb.Append("    ");
            sb.Append(node.Name);
            sb.Append("[");
            sb.Append(node.Text);
            sb.Append("]");
            sb.Append(Environment.NewLine);
        }

        //Add links
        foreach (Link link in Links)
        {
            Node? sourceNode = Nodes.Where(n => n.Name == link.SourceNode).FirstOrDefault();
            Node? destinationNode = Nodes.Where(n => n.Name == link.DestinationNode).FirstOrDefault();
            if (sourceNode == null || destinationNode == null)
            {
                throw new Exception("Nodes in link connection (" + link.SourceNode + "-->" + link.DestinationNode + ") not found");
            }
            sb.Append("    ");
            sb.Append(sourceNode.Name);
            sb.Append("--");
            if (string.IsNullOrEmpty(link.Text) == false)
            {
                sb.Append(link.Text);
                sb.Append("--");
            }
            sb.Append(">");
            sb.Append(destinationNode.Name);
            sb.Append(Environment.NewLine);
        }
        return sb.ToString();
    }

    private static string OpenShape()
    {
        if (Shape)
        return "";
    }

    private static string CloseShape()
    {
        return "";
    }

}
