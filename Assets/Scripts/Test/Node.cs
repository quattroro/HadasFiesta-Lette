using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeamItem<Node>
{

    public bool walkable; 
    public Vector3 worldPosition;  //포지션
    public int gridX;  
    public int gridY;

    public int gCost; 
    public int hCost;  
    public Node parent; 
    int heapIndex;

    public Node(bool _walkable, Vector3 _wordPos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _wordPos;
        gridX = _gridX;
        gridY = _gridY;

    }

    public int fCost  
    {
        get
        {
            return gCost + hCost;
        }
    }


    //인터페이스

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }

    public int CompareTo(Node nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost); 
        if (compare == 0) 
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare; 
    }

}

