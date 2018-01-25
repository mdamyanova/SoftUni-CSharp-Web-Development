using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

    public static void Main()
    {
        ReadTree();
        var result = GetRootNode();

        // 01.Root Node 
        //Console.WriteLine($"Root node: {result.Value}");

        // 02.Print Tree
        //result.Print();

        // 03.Leaf Node
        //var leafeNodesValues = GetLeafeNodesValues();
        //Console.WriteLine($"Leaf nodes: {string.Join(" ", leafeNodesValues)}");

        // 04.Middle Node
        //var middleNodesValues = GetMiddleNodesValues();
        //Console.WriteLine($"Middle nodes: {string.Join(" ", middleNodesValues)}");

        // 05.Deepest Node

    }

    private static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }

        return nodeByValue[value];
    }

    private static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetTreeNodeByValue(parent);
        Tree<int> childNode = GetTreeNodeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

    private static void ReadTree()
    {
        var nodeCount = int.Parse(Console.ReadLine());

        for (int i = 1; i < nodeCount; i++)
        {
            var edge = Console.ReadLine().Split(' ');
            AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
        }
    }

    private static Tree<int> GetRootNode()
    {
        return 
            nodeByValue
            .Values
            .FirstOrDefault(x => x.Parent == null);
    }

    private static List<Tree<int>> GetLeafNodes()
    {
        return
            nodeByValue
            .Values
            .Where(x => x.Children.Count == 0)
            .ToList();
    }

    private static List<int> GetLeafeNodesValues()
    {
        var leafes = GetLeafNodes();

        return leafes
            .Select(n => n.Value)
            .OrderBy(n => n)
            .ToList();
    }

    private static List<Tree<int>> GetMiddleNodes()
    {
        return
            nodeByValue
            .Values
            .Where(x => x.Parent != null && x.Children.Count != 0)
            .ToList();
    }

    private static List<int> GetMiddleNodesValues()
    {
        var middleNodes = GetMiddleNodes();

        return
            middleNodes
            .Select(n => n.Value)
            .OrderBy(n => n)
            .ToList();
    }
}