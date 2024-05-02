using System.Runtime.CompilerServices;

Graph g = new Graph(8);
g.addEdge(0, 1);
g.addEdge(1, 2);
g.addEdge(2, 3);
g.addEdge(3, 4);
g.addEdge(4, 5);
g.addEdge(5, 2);
g.addEdge(0, 6);
g.addEdge(6, 7);
g.addEdge(6, 1);

Console.WriteLine("Graph's SCCs:");
g.SCC();
Console.ReadKey();
class Graph
{
    private int V; //pocet vrcholu
    private int Time; //poradi navstevy
    private List<int>[] adj; //list cest

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<int>();
        }
        Time = 0;
    }

    public void addEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    private void SCCUtil(int u, int[] low, int[] time, bool[] stackMember, Stack<int> st)
    {
        time[u] = Time;
        low[u] = Time;
        Time += 1;
        stackMember[u] = true;
        st.Push(u);

        int n;

        foreach(int i in adj[u])
        {
            n = i;

            if (time[n] == -1)
            {
                SCCUtil(n, low, time, stackMember, st);
                low[u] = Math.Min(low[u], low[n]);
            }
            else if (stackMember[n] == true)
            {
                low[u] = Math.Min(low[u], time[n]);
            }
        }

        int w = -1;
        if (low[u] == time[u])
        {
            while (w != u)
            {
                w = st.Pop();
                Console.Write(w + " ");
                stackMember[w] = false;
            }
            Console.WriteLine();
        }
    }

    public void SCC()
    {
        int[] time = new int[V];
        int[] low = new int[V];
        for(int i = 0; i < V; i++)
        {
            time[i] = -1;
            low[i] = -1;
        }

        bool[] stackMember = new bool[V];
        Stack<int> st = new Stack<int>();
        for (int i = 0;i < V; i++)
        {
            if (time[i] == -1)
            {
                SCCUtil(i, low, time, stackMember, st);
            }
        }
    }
}