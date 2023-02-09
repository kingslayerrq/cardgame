using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RoomNodeGenerator : MonoBehaviour
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
    [SerializeField]
    private float minGeneralOffset;
    [SerializeField]
    private float xBound;
    [SerializeField]
    private float yBound;


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

    // return randomized xoffset, yoffset for next spawnPos
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
            do
            {
                randomizeNode();
            } while (checkRoomGap(spawnPos.position, roomNodeList) == false);
            Debug.Log(spawnPos.position.x < -xBound);
            
        }
    }

    // generate node object (used in mapGeneration) & add to roomNode list
    private void createNode(GameObject roomNode, Vector3 pos)
    {
        GameObject obj = Instantiate(roomNode, pos, Quaternion.identity);
        roomNodeList.Add(obj.GetComponent<Node>());

        
        
    }
    private bool checkRoomGap(Vector3 x, List<Node> nodeList) // check two nodes x,y distance, if pos applicable return true, otherwise return false
    {
        int count = nodeList.Count;
        for (int i = 0; i < count; i++)
        {
            Node y = nodeList[i];
            // make sure two rooms have distance > minGenralOffset
            if (distance(x, y.transform) < minGeneralOffset)
            { 
                return false;
            }
            // make sure rooms don't go out of bounds
            if (x.x < -xBound)
            {
                spawnPos.position = new Vector3 (0, spawnPos.position.y, 0);
                return false;
            }
            if (x.x > xBound)
            {
                spawnPos.position = new Vector3(0, spawnPos.position.y, 0);
                return false;
            }
            if (x.y < -yBound)
            {
                spawnPos.position = new Vector3(spawnPos.position.x, 0, 0);
                return false;
            }
            if (x.y > yBound)
            {
                spawnPos.position = new Vector3(spawnPos.position.x, 0, 0);
                return false;
            }
        }

        return true;
    }
    // determines next nodes generation direction, using randomized x,y offset, next node builds on the previous spawnPos
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

    // returns distance between a vector3 to another object's position
    private float distance(Vector3 x, Transform y)
    {

        return (float)math.sqrt(math.pow(x.x - y.position.x, 2) + math.pow(x.y - y.position.y, 2));
    }
}
