using System;
using System.Collections.Generic;
using System.Linq;

namespace implementations
{
    public class GraphAdjacentLists<TValueType> where TValueType : struct
    {
        private Dictionary<TValueType, HashSet<TValueType>> _content = new Dictionary<TValueType, HashSet<TValueType>>();

        public DirectedGraphEnum DirectedGraph { get; }

        public enum DirectedGraphEnum
        {
            Directed,
            Undirected
        }

        public TValueType? FirstVertex { get; private set; }

        public IEnumerable<TValueType> GetAdjacentVertices(TValueType vertexId)
        {
            return _content.ContainsKey(vertexId) ? _content[vertexId] : Enumerable.Empty<TValueType>();
        }
        

        public GraphAdjacentLists(DirectedGraphEnum directedGraph)
        {
            DirectedGraph = directedGraph;
        }

        public IEnumerable<TValueType> Vertices => _content.Keys;

        
        public void AddVertex(TValueType id)
        {
            if (!FirstVertex.HasValue)
                FirstVertex = id;
            
            if (_content.ContainsKey(id))
                return;
            
            _content.Add(id, new HashSet<TValueType>());
        }

        public int NumberOfVertices => _content.Count;
        public int NumberOfEdges 
        {
            get
            {
                var numberOfEdges = 0;
                
                foreach (var row in _content)
                {
                    numberOfEdges += row.Value.Count;
                }

                return numberOfEdges;
            }
        }

        public void AddEdge(TValueType from, TValueType to)
        {
            if (!HasVertex(from) || !HasVertex(to))
                return;
                
            _content[from].Add(to);
            if(DirectedGraph == DirectedGraphEnum.Undirected)
                _content[to].Add(from);
        }

        public bool HasVertex(TValueType id)
        {
            return _content.ContainsKey(id);
        }

        public bool HasEdge(TValueType from, TValueType to)
        {
            return HasVertex(from) && HasVertex(to) && _content[from].Contains(to);
        }
    }
}