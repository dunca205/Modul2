using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadixTree
{
    public class RadixNode<TValue>
    {
        private TValue value;
        private List<RadixNode<TValue>> children;
        public RadixNode(TValue value)
        {
            this.value = value;
            bool isWord = false; // se face true dupa insertie
            children = new List<RadixNode<TValue>> ();
        }
        public List<RadixNode<TValue>> Children { get { return children; } }
        
        public bool HasChildren { get { return children != null; } }
        public TValue Value { get => this.value; set => this.value = value; }
        public bool IsWord { get; set; }
        public void AddChildren(RadixNode<TValue> node)
        {
            
        }
        
    }
}
