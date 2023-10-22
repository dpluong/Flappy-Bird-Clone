using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour
{
    private Vector2 startPosition;
    //[SerializeField] private float speed = 3f;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ScrollColumns();

    }
    private void ScrollColumns()
    {
        transform.Translate(new Vector2(-1, 0) * GameManager.gameManager.scrollingSpeed * Time.deltaTime);
    }
}
