#include <iostream>
#include <fstream>
#include <string>

using namespace std;

const int MAX_E = (int)1e6;
const int MAX_V = (int)1e3;
const int INF = (int)1e9;

int numOfVertex = 11, numOfEdge = 17, sourceVertex = 7, destinationVertex = 11;
int capacity[MAX_E], onEnd[MAX_E], nextEdge[MAX_E], edgeCount;
int firstEdge[MAX_V], visited[MAX_V];

void addEdge(int u, int v, int cap)
{

    onEnd[edgeCount] = v;
    nextEdge[edgeCount] = firstEdge[u];
    firstEdge[u] = edgeCount;
    capacity[edgeCount++] = cap;

    onEnd[edgeCount] = u;
    nextEdge[edgeCount] = firstEdge[v];
    firstEdge[v] = edgeCount;
    capacity[edgeCount++] = 0;
}

int findFlow(int u, int flow)
{
    if (u == destinationVertex)
        return flow;
    visited[u] = true;
    for (int edge = firstEdge[u]; edge != -1; edge = nextEdge[edge])
    {
        int to = onEnd[edge];
        if (!visited[to] && capacity[edge] > 0)
        {
            int minResult = findFlow(to, min(flow, capacity[edge]));
            if (minResult > 0)
            {
                capacity[edge] -= minResult;
                capacity[edge ^ 1] += minResult;
                return minResult;
            }
        }
    }
    return 0;
}

int main()
{
    fill(firstEdge, firstEdge + MAX_V, -1);
    addEdge(7, 1, 3200);
    addEdge(1, 9, 2400);
    addEdge(1, 4, 2400);
    addEdge(4, 2, 1600);
    addEdge(4, 9, 1600);
    addEdge(4, 8, 800);
    addEdge(2, 3, 400);
    addEdge(2, 9, 1600);
    addEdge(2, 11, 800);
    addEdge(9, 3, 1600);
    addEdge(9, 5, 400);
    addEdge(5, 3, 800);
    addEdge(8, 5, 3200);
    addEdge(8, 10, 3200);
    addEdge(5, 10, 3200);
    addEdge(10, 6, 1600);
    addEdge(6, 11, 800);

    int maxFlow = 0;
    int iterationResult = 0;
    while ((iterationResult = findFlow(sourceVertex, INF)) > 0)
    {
        fill(visited, visited + MAX_V, false);
        maxFlow += iterationResult;
    }

    cout << "Max flow: " << maxFlow << "\n";
    return 0;
}