using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour {


    float t = 0;
    int index = 0;
    int direction = 1;
    List<Vector3> points = new List<Vector3>();
    List<int> indices = new List<int>();
    int[] path = new int[4]; 

    void Start () {
        points.Add(GameObject.Find("p1").transform.position);
        points.Add(GameObject.Find("p2").transform.position);
        points.Add(GameObject.Find("p3").transform.position);
        points.Add(GameObject.Find("p4").transform.position);
        points.Add(GameObject.Find("p5").transform.position);
        points.Add(GameObject.Find("p6").transform.position);

        GeneratePath();
        
    }
	
	void Update () {
        
        t += 0.01f;
        transform.position = Vector3.Lerp(points[path[index]], points[path[index+1]], t);
        if(t > 1)
        {
            t = 0;
            index++;
        }
        if(index == path.Length -1) 
        {
            GeneratePath();
            index = 0;
        }

        
	}

    void GeneratePath() 
    {

        Array.Clear(path, 0, path.Length);  
        for (int runs = 0; runs < 4; runs++) 
        {
            int rndNumber = UnityEngine.Random.Range(1, 6);
         
            if(rndNumber != path[0] && rndNumber != path[1] && rndNumber != path[2] && rndNumber != path[3])
            {
                path[runs] = rndNumber;
            }
        }
        Debug.Log(path);
    }
}
