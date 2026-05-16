public class LRUCache {
    private int capacity;
    private Dictionary<int,Node> dict;
    private Node dummyHead;
    private Node dummyTail;

    private class Node{
        public int Key;
        public int Value;
        public Node Prev;
        public Node Next;
    }

    public LRUCache(int capacity) {
        this.capacity = capacity;
        dict = new Dictionary<int, Node>();
        dummyHead = new Node();
        dummyTail = new Node();

        dummyHead.Next = dummyTail;
        dummyTail.Prev = dummyHead;
    }
    
    private void AddToHead(Node node){
       node.Prev = dummyHead;
       node.Next = dummyHead.Next;
       dummyHead.Next.Prev = node;
       dummyHead.Next = node;
    }

     private void RemoveNode(Node node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }

    public int Get(int key) {
        if(!dict.TryGetValue(key, out var node)) return -1;

        RemoveNode(node);
        AddToHead(node);

        return node.Value;
    }
    
    public void Put(int key, int value) {
        // A: existing, need to remove and move to head
        if(dict.TryGetValue(key, out var existing))
        {
            existing.Value = value;
            RemoveNode(existing);
            AddToHead(existing);
            return;
        }

        // B: not existing, need to create remvoe the last tail 
        // and create a new node to add to Head
        if(dict.Count >= capacity)
        {
            var tail  = dummyTail.Prev;
            dict.Remove(tail.Key);
            RemoveNode(tail);
        }

        var node = new Node{Key = key, Value = value};
        dict[key] = node;
        AddToHead(node);
    }
}
