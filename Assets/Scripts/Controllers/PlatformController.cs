using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] List <GameObject> platforms;
    public float timer;
    int j;
    void Start()
    {
        timer = 0;
        PlatformTaker();
        ShutDownPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {

            ShutDownPlatforms();
            ActivateSomePlatforms();
            timer = 5;
        }

    }
    void PlatformTaker() 
    {
        Collider2D[] colliders2D = Physics2D.OverlapAreaAll(new Vector2(-70, 70f), new Vector2(50f, -25f));
        foreach ( var collider in colliders2D)
        {
            if (collider.tag == "Land")
                platforms.Add(collider.gameObject);
        }
        platforms.Sort((a,b)=>a.name.CompareTo(b.name));
    }
    void ShutDownPlatforms()
    {
        foreach(var platform in platforms)
        {
            platform.SetActive(false);
        }
    }

    void ActivateSomePlatforms()
    {
        int i, j;
        i = Random.Range(0, platforms.Count - 1);
        platforms[i].SetActive(true);
        switch (i)
        {
            case 2:
                j = Random.Range(0, 1);
                platforms[j].SetActive(true);
                break;
            case 3:
                j = 2;
                platforms[j].SetActive(true);
                platforms[j-(Random.Range(1,2))].SetActive(true);
                break;
            case 4:
                j = 2;
                platforms[j].SetActive(true);
                platforms[j - (Random.Range(1, 2))].SetActive(true);
                break;
            default:
                j = 2;
                platforms[j].SetActive(true);
                platforms[j + (Random.Range(1, 2))].SetActive(true);

                break;

        }
    }
}
