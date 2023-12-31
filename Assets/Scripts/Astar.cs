using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2Int position;
    public bool isWalkable; // 이동 가능한지
    public int gCost;
    public int hCost;
    public Node parent;

    public Node(Vector2Int position, bool isWalkable)
    {
        this.position = position;
        this.isWalkable = isWalkable;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }
}

public class AStar
{
    public static List<Vector2Int> FindPath(Node[,] grid, Vector2Int start, Vector2Int target)
    {
        List<Vector2Int> path = new List<Vector2Int>();

        Node startNode = grid[start.x, start.y];
        Node targetNode = grid[target.x, target.y];

        List<Node> openSet = new List<Node>(); // 열린노드 
        HashSet<Node> closedSet = new HashSet<Node>(); // 닫힌노드

        openSet.Add(startNode);
   
        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode.position ==  targetNode.position)
            {
                path = RetracePath(startNode, targetNode);
                break;
            }

            // 이웃 노드 탐색
            foreach (Node neighbor in GetNeighbors(grid, currentNode))
            {
                if (!closedSet.Contains(neighbor))
                {
                    int newCostToNeighbor = currentNode.gCost +1;
                    if (newCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                    {
                        neighbor.gCost = newCostToNeighbor;
                        neighbor.hCost = GetDistance(neighbor, targetNode);
                        neighbor.parent = currentNode;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }
        }
        return path;
    }

    static List<Vector2Int> RetracePath(Node startNode, Node endNode)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Node currentNode = endNode;

        while (currentNode != null)
        {
            path.Add(currentNode.position);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }

    // 비용 계산 모든 비용 동일
    static int GetDistance(Node nodeA, Node nodeB)
    {
        int dx = Mathf.Abs(nodeA.position.x - nodeB.position.x);
        int dy = Mathf.Abs(nodeA.position.y - nodeB.position.y);

        // 대각선 이동에 대한 추가 비용 부여
        int diagonalCost = 14; // 대각선 이동 비용
        int straightCost = 10; // 직선 이동 비용

        return straightCost * (dx + dy) + (diagonalCost - 2 * straightCost) * Mathf.Min(dx, dy);
    }

    static List<Node> GetNeighbors(Node[,] grid, Node node)
    {
        List<Node> neighbors = new List<Node>();

        int[,] directions;

        if (node.position.y % 2 == 0)
        {
            directions = new int[,] { { 0, -1 }, { 1, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 }, { -1, -1 } };
        }
        else
        {
            directions = new int[,] { { 0, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 } };
        }

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            int[] dir = { directions[i, 0], directions[i, 1] };
            Vector2Int neighborPos = node.position + new Vector2Int(dir[0], dir[1]);

            if (neighborPos.x >= 0 && neighborPos.x < grid.GetLength(0) &&
                neighborPos.y >= 0 && neighborPos.y < grid.GetLength(1))
            {
               if(grid[neighborPos.x,neighborPos.y].isWalkable)
                neighbors.Add(grid[neighborPos.x, neighborPos.y]);
            }
        }

        return neighbors;
    }
}