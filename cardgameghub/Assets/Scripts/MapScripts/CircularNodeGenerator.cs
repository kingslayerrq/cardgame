using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

public class CircularNodeGenerator : MonoBehaviour
{

    [SerializeField]
    private int endRoomNum;
    [SerializeField]
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
    private float maxRadius;

    
    public Transform centerPos;
    [SerializeField]
    private Transform spawnPos;
    public GameObject baseNode;

    
    
    

    [SerializeField]
    private double angleRad;
    
   

    // list of all room nodes
    public List<Node> roomNodeList = new List<Node>();
    // list of endRoom nodes
    public List<Node> endRoomNodeList = new List<Node>();

    // Start is called before the first frame update
    void Start()
    {
        angleRad = (double)(UnityEngine.Random.Range(0, 361) * MathF.PI) / 180;
        float x = (float)(centerPos.position.x + maxRadius * math.cos(angleRad));
        float y = (float)(centerPos.position.y + maxRadius * math.sin(angleRad));
        spawnPos.position = new Vector3(x, y, 0f);
        for (int i = 0; i < endRoomNum; i++)
        {
            createEndNode(baseNode, spawnPos.position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    

    

    private void updateSpawnPos() //update spawnPos for endRoom node (currently)
    {
        do
        {
            double angleRad = (UnityEngine.Random.Range(0, 361) * MathF.PI) / 180; // angle in radian
            float x = (float)(centerPos.position.x + maxRadius * math.cos(angleRad));
            float y = (float)(centerPos.position.y + maxRadius * math.sin(angleRad));
            spawnPos.position = new Vector3(x, y, 0f);
        }while (checkRoomGap(spawnPos.position, endRoomNodeList) == false); // keep randomizing until within range of x,y offsets

        
    }

    private bool checkRoomGap(Vector3 x, List<Node> nodeList) // check two nodes x,y distance, if pos applicable return true, otherwise return false
    {
        int count = nodeList.Count;
        for (int i = 0; i < count; i++)
        {
            Node y = nodeList[i];
            if (xdistance(x, y.transform) < minxOffset ^ 
            ydistance(x, y.transform) < minyOffset ^
            xdistance(x, y.transform) > maxxOffset ^
            ydistance(x, y.transform) > maxyOffset ^
            distance(x, y.transform) < minGeneralOffset)
            {
                return false;
            }
            continue;
        }
        
        return true;
    }
    private void createEndNode(GameObject roomNode, Vector3 pos)
    {
        GameObject obj = Instantiate(roomNode, pos, Quaternion.identity);
        endRoomNodeList.Add(obj.GetComponent<Node>());
        updateSpawnPos();
    }
    private void createNode(GameObject roomNode, Vector3 pos)
    {
        GameObject obj = Instantiate(roomNode, pos, Quaternion.identity);
        roomNodeList.Add(obj.GetComponent<Node>());
    }



    private float xdistance(Vector3 x, Transform y)
    {
        return math.abs(x.x - y.position.x);
    }
    private float ydistance(Vector3 x, Transform y)
    {
        return math.abs(x.y - y.position.y);
    }
    private float distance(Vector3 x, Transform y)
    {

        return (float)math.sqrt(math.pow(x.x - y.position.x, 2) + math.pow(x.y - y.position.y, 2));
    }

}
