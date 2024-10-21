using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class HuffmanNode
{
    public string Symbol { get; set; }
    // how many times the symbol appears in the text
    public int Frequency { get; set; }
    public HuffmanNode Left { get; set; }
    public HuffmanNode Right { get; set; }
}

public class HuffmanComparator : IComparer<HuffmanNode>
{
    public int Compare(HuffmanNode x, HuffmanNode y)
    {
        return x.Frequency - y.Frequency;
    }
}

public class HuffmanCoding
{
    // last processed list of words
    // used to write a dictionary for restoring
    static string[] lastWords;
    static Dictionary<string, string> lastCodes;
    public static string[] LastWords
    {
        get
        {
            return lastWords;
        }
        set
        {
            lastWords = value;
            lastCodes = null;
        }
    }
    public static Dictionary<string, string> LastCodes
    {
        get
        {
            return lastCodes;
        }
        set
        {
            lastCodes = value;
        }
    }
    public static Dictionary<string, string> Encode(string[] words)
    {
        LastWords = words;
        // Calculate frequencies of each word
        Dictionary<string, int> freq = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (freq.ContainsKey(word))
                freq[word]++;
            else
                freq[word] = 1;
        }

        // Create Huffman nodes for each word
        var nodes = freq.Select(x => new HuffmanNode { Symbol = x.Key, Frequency = x.Value }).ToList();
        // codes generated from the tree
        Dictionary<string, string> codes = new Dictionary<string, string>();

        // to optimize dictionary will consist only from one match
        // and there's no need to build a tree
        if (nodes.Count == 1)
        {
            codes[nodes[0].Symbol] = "0";
            LastCodes = codes;
            return codes;
        }
        // Build Huffman tree
        while (nodes.Count > 1)
        {
            nodes = nodes.OrderBy(node => node.Frequency).ToList();

            // Take two nodes with lowest frequency
            HuffmanNode left = nodes[0];
            HuffmanNode right = nodes[1];

            // Create parent node with combined frequency
            HuffmanNode parent = new HuffmanNode
            {
                Symbol = left.Symbol + right.Symbol,
                Frequency = left.Frequency + right.Frequency,
                Left = left,
                Right = right
            };

            // Remove the processed nodes and add the parent node
            nodes.Remove(left);
            nodes.Remove(right);
            nodes.Add(parent);
        }

        // Generate codes from the tree
        GenerateCodes(nodes[0], "", codes);

        // update last codes
        LastCodes = codes;

        return codes;
    }

    // for each node set code based on Huffman algorithm
    private static void GenerateCodes(HuffmanNode node, string code, Dictionary<string, string> codes)
    {
        if (node.Left == null && node.Right == null)
        {
            codes[node.Symbol] = code;
            return;
        }

        GenerateCodes(node.Left, code + "0", codes);
        GenerateCodes(node.Right, code + "1", codes);
    }
}