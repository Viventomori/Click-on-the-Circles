using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Circle : MonoBehaviour
{
    [SerializeField] private float _minSize;
    [SerializeField] private float _maxSize;
    
    private Circle _circle;
    
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<Renderer>().material.color = Random.ColorHSV();
        transform.localScale = Vector2.one * Random.Range(_minSize, _maxSize);
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);  
        ISceneManager.instance.ScorePlus();
    }
}
