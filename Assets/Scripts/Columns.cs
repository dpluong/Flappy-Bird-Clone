using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour
{
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (GameManager.Instance.IsGameStart())
        {
            ScrollColumns();
        }
    }

    private void ScrollColumns()
    {
        transform.Translate(new Vector2(-1, 0) * GameManager.Instance.scrollingSpeed * Time.deltaTime);
    }
}
