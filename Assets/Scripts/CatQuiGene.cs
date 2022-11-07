using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatQuiGene : MonoBehaviour
{
    float timer = 0;
    bool goUp = true;
    private RectTransform rect;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        timer = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            StartCoroutine(Movement());
        }
        
    }

    IEnumerator Movement()
    {
        if(rect.localPosition.y <= -2385 && !goUp)
        {
            timer = Random.Range(5, 10);
            goUp = true;
            yield return null;
        }
        else if (!goUp)
        {
            rect.localPosition += Vector3.down * speed * Time.deltaTime;
            yield return null;
        }
        else if (rect.localPosition.y >= -147 && goUp)
        {
            yield return new WaitForSeconds(5f);
            goUp = false;
        }
        else if (goUp)
        {
            rect.localPosition += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }
    }
}
