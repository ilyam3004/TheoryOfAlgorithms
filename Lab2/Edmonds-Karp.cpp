#include <bits/stdc++.h>
#include <thread>

using namespace std;

const int INF = 1e9;

struct edge
{
    int from;
    int to;
    int f;
    int c;
    edge(int from = 0, int to = 0, int f = 0, int c = 0) : from(from), to(to), f(f), c(c) {}
    int c1()
    {
        return c - f;
    }
};
vector<edge> edges;
vector<vector<int>> gr;
void add(int u, int v, int c)
{
    gr[u].push_back(edges.size());
    edges.push_back(edge(u, v, 0, c));
    gr[v].push_back(edges.size());
    edges.push_back(edge(v, u, 0, 0));
}
void push(int i, int f)
{
    edges[i].f += f;
    edges[i ^ 1].f -= f;
}

int n = 11;
int ans = 0;
bool bfs(int n)
{
    vector<int> dist(n, INF);
    vector<int> p(n, -1);
    dist[0] = 0;
    queue<int> q;
    q.push(0);
    while (!q.empty())
    {
        int v = q.front();
        q.pop();
        for (auto &i : gr[v])
        {
            edge e = edges[i];
            if (dist[e.to] > dist[v] + 1 && e.c1() > 0)
            {
                dist[e.to] = dist[v] + 1;
                q.push(e.to);
                p[e.to] = i;
            }
        }
    }
    if (dist[n - 1] == INF)
    {
        return false;
    }
    int v = n - 1;
    int f = INF;
    while (v != 0)
    {
        f = min(f, edges[p[v]].c1());
        v = edges[p[v]].from;
    }
    ans += f;
    v = n - 1;
    while (v != 0)
    {
        push(p[v], f);
        v = edges[p[v]].from;
    }
    return true;
}
int main()
{

    int m = 17;
    gr.resize(n);
    add(7 - 1, 1 - 1, 3200);
    add(1 - 1, 9 - 1, 2400);
    add(1 - 1, 4 - 1, 2400);
    add(4 - 1, 2 - 1, 1600);
    add(4 - 1, 9 - 1, 1600);
    add(4 - 1, 8 - 1, 800);
    add(2 - 1, 3 - 1, 400);
    add(2 - 1, 9 - 1, 1600);
    add(2 - 1, 11 - 1, 800);
    add(9 - 1, 3 - 1, 1600);
    add(9 - 1, 5 - 1, 400);
    add(5 - 1, 3 - 1, 800);
    add(8 - 1, 5 - 1, 3200);
    add(8 - 1, 10 - 1, 3200);
    add(5 - 1, 10 - 1, 3200);
    add(10 - 1, 6 - 1, 1600);
    add(6 - 1, 11 - 1, 800);
    while (bfs(n))
    {
        
    }
    cout << "Max flow: " << ans << "\n";
}