using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour {


    float t = 0;
    int index = 0;
    List<Vector3> points = new List<Vector3>();
    int[] path = new int[] { };
    Vector2 mousePosition;
    int nearestPoint;

    int[,] graph = new int[,]
    {
            {0, 1, 1, 0, 0, 0 },
            {1, 0, 0, 0, 1, 1 },
            {1, 0, 0, 1, 1, 0 },
            {0, 0, 1, 0, 1, 1 },
            {0, 1, 1, 1, 0, 1 },
            {0, 1, 0, 1, 1, 0 }
    };


    //List<int> path;
    List<int> path2;
    void Start () {
        path2 = PathFinding.Disjkstra(graph, 0, 5);
        

        points.Add(GameObject.Find("p0").transform.position); 
        points.Add(GameObject.Find("p1").transform.position); 
        points.Add(GameObject.Find("p2").transform.position); 
        points.Add(GameObject.Find("p3").transform.position);  
        points.Add(GameObject.Find("p4").transform.position); 
        points.Add(GameObject.Find("p5").transform.position); 
        
    }
	
	void Update () {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //Debug.Log(mousePosition);
        nearestPoint = getNearestPoint(mousePosition);

        Debug.Log(nearestPoint);

        t += 0.01f;
        transform.position = Vector3.Lerp(points[path2[index]], points[path2[index+1]], t);
        if(t > 1)
        { 
            t = 0;
            index++;
        }
        if(index == path2.Count -1) 
        {
            index = 0;
        }
       
	}

    int getNearestPoint(Vector3 mPosition) 
    {
        float distance;
        int nearest = -1;
        float currentDistance;
        int idx = 0;
        foreach (Vector3 i in points)
        {
            idx++;
            currentDistance = Vector3.Distance(mPosition , i);
            distance = currentDistance;
            if(currentDistance < distance)
            {
                nearest = idx;
            }
        }
        return nearest; 
    } 

}
