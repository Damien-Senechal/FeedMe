using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatQuiGene : MonoBehaviour
{
    float timer = 0;
    bool goUp = false;
    private RectTransform rect;
    public int speed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        timer = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            goUp = true;
        }

        if (goUp)
        {
            rect.localPosition += Vector3.up * speed * Time.deltaTime;
            //goUp = false;
            //timer = Random.Range(1, 5);
        }
        
    }
}
