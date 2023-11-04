using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateColumns : MonoBehaviour
{
    // Start is called before the first frame update
    public int columnAmountToPool = 10;
    public GameObject columnToPool;
    
    [SerializeField] private float columnYPositionMin = 4f;
    [SerializeField] private float columnYPositionMax = 5f;
    [SerializeField] private float secondsToGenerateAColumn = 2f;

    private float columnXPosition = 9f;
    private Vector2 initPosition = new Vector2(-12f, -12f);
    private float timeSinceLastGenerated;
    private int currentColumn = 0;
    private List<GameObject> columnPool;

    void Start()
    {
        columnPool = new List<GameObject>();

        for (int i = 0; i < columnAmountToPool; ++i) {
            GameObject temp = Instantiate(columnToPool, initPosition, Quaternion.identity);
            columnPool.Add(temp);
        }
    }

    void Update()
    {
        timeSinceLastGenerated += Time.deltaTime;
        if (timeSinceLastGenerated >= secondsToGenerateAColumn) 
        {    
            timeSinceLastGenerated = 0f;
            
            float columnYPosition = Random.Range(columnYPositionMin, columnYPositionMax);
            
            columnPool[currentColumn].transform.position = new Vector2(columnXPosition, columnYPosition);
            
            currentColumn += 1;

            if (currentColumn >= columnAmountToPool) 
            {
                currentColumn = 0;
            }
        }
    }
}