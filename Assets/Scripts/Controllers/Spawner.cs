using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] ball = new GameObject[5];
    private GameObject createdBall;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void CreateBall(int i)
    {
        position.x = Random.Range(-31.02f, 58.61f);
        position.y = Random.Range(-28.12f, 28.15f);
        position.z = -1;
        createdBall = Instantiate(ball[i], position ,Quaternion.identity) as GameObject;
    }

}
