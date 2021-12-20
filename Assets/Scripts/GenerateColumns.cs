using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateColumns : MonoBehaviour
{
    // Start is called before the first frame update
    public int columnAmountToPool = 10;
    private List<GameObject> columnPool;
    public GameObject columnToPool;
    private float columnYPositionMin = 4f;
    private float columnYPositionMax = 5f;
    private float columnXPosition = 12f;
    private Vector2 initPosition = new Vector2(-12f, -9f);
    private float timeSinceLastGenerated;
    private float generateRate = 3f; 
    private int currentColumn = 0;
    void Start()
    {
        columnPool = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < columnAmountToPool; ++i) {
            temp = Instantiate(columnToPool, initPosition, Quaternion.identity);
            columnPool.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastGenerated += Time.deltaTime;
        if (timeSinceLastGenerated >= generateRate) 
        {    
            timeSinceLastGenerated = 0f;
            
            float columnYPosition = Random.Range(columnYPositionMin, columnYPositionMax);
            
            columnPool[currentColumn].transform.position = new Vector2(columnXPosition, columnYPosition);
            
            currentColumn += 1;
            //print(currentColumn);
            if (currentColumn >= columnAmountToPool) 
            {
                currentColumn = 0;
            }
        }
    }
}