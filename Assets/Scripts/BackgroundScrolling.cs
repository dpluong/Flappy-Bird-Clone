using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
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
        ScrollBackground();
    }

    private void ScrollBackground()
    {
        transform.Translate(new Vector2(-1, 0) * GameManager.gameManager.scrollingSpeed * Time.deltaTime);

        if (transform.position.x < -10.5f)
        {
            transform.position = startPosition;
        }
    }
}
