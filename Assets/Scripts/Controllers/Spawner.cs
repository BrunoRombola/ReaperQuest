using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[5];
    //public GameObject prefab;
    public float time = 0,limit = 2;
    public float leftPos, rightPos, topPos;
    
    // Start is called before the first frame update
    void Start()
    {
        leftPos = GameObject.Find("LeftBar").GetComponent<Transform>().position.x+10;
        rightPos = GameObject.Find("RightBar").GetComponent<Transform>().position.x-10;
        topPos = GameObject.Find("TopLimit").GetComponent<Transform>().position.y;

    }
    void Update()
    {
      time += Time.deltaTime;
        if (time > limit)
        {
            DropBall();
            time = 0;
        }
    }
    void DropBall()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], NewPosition(), Quaternion.identity);

    }
    Vector3 NewPosition()
    {
        
        return new Vector3(Random.Range(leftPos,rightPos),topPos,2);
    }
}
