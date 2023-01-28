using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNodesGenerator : MonoBehaviour
{
    public enum Direction
    {
        topRight = 0,
        topLeft = 1,
        bottomRight = 2,
        bottomLeft = 3
    }


    private Direction direction;

    



    [SerializeField]
    private int roomNum;
    // distance between 2 nodes
    [SerializeField]
    //all offsets must be set as positive numbers
    private float minxOffset;
    [SerializeField]
    private float minyOffset;
    [SerializeField]
    private float maxxOffset;
    [SerializeField]
    private float maxyOffset;

    public Transform spawnPos;
    public GameObject baseNode;

    // list of all room nodes
    public List<Node> roomNodeList = new List<Node>();


    
    // Start is called before the first frame update
    void Start()
    {
        createMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // return xoffset, yoffset
    private float randomizeXoffset()
    {
        return UnityEngine.Random.Range(minxOffset, maxxOffset);
    }
    private float randomizeYoffset()
    {
        return UnityEngine.Random.Range(minyOffset, maxyOffset);
    }

    //generate map with nodes
    private void createMap()
    {
        for (int i = 0; i < roomNum; i++)
        {
            createNode(baseNode, spawnPos.position);
            randomizeNode();
        }
    }

    // generate node object (used in mapGeneration) & add to roomNode list
    private void createNode(GameObject roomNode, Vector3 pos)
    {
        GameObject obj = Instantiate(roomNode, pos, Quaternion.identity);
        roomNodeList.Add(obj.GetComponent<Node>());
        
    }
    // determines next nodes generation direction
    void randomizeNode()
    {
        direction = (Direction)UnityEngine.Random.Range(0, 4);

        switch (direction)
        {
            case Direction.topRight:
                spawnPos.position += new Vector3(randomizeXoffset(), randomizeYoffset(), 0);
                break;
            case Direction.topLeft:
                spawnPos.position += new Vector3(-randomizeXoffset(), randomizeYoffset(), 0);
                break;
            case Direction.bottomRight:
                spawnPos.position += new Vector3(randomizeXoffset(), -randomizeYoffset(), 0);
                break;
            case Direction.bottomLeft:
                spawnPos.position += new Vector3(-randomizeXoffset(), -randomizeYoffset(), 0);
                break;
        }
    }
}
