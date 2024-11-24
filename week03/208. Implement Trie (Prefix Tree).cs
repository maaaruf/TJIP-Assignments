public class TrieNode
{
    public bool IsWord {get; set;}
    public Dictionary<char, TrieNode> Children {get; } = new Dictionary<char, TrieNode>();
}

public class Trie {
    private readonly TrieNode _root;

    public Trie() {
        _root = new TrieNode();
    }
    
    public void Insert(string word) {
        var node = _root;
        foreach(char chr in word){
            if(!node.Children.ContainsKey(chr))
                node.Children[chr] = new TrieNode();
            
            node = node.Children[chr];
        }

        node.IsWord = true;
    }
    
    public bool Search(string word) {
        var lastNode = FindLastNode(word);
        return lastNode?.IsWord == true;
    }
    
    public bool StartsWith(string prefix) {
        var lastNode = FindLastNode(prefix);
        return lastNode != null;
    }

    public TrieNode? FindLastNode(string word)
    {
        var node = _root;
        foreach(var chr in word){
            if(!node.Children.ContainsKey(chr)) return null;
            node = node.Children[chr];
        }

        return node;
    } 
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
