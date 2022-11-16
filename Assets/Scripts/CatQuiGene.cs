using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatQuiGene : MonoBehaviour
{
    float timer = 0;
    bool goUp = true;
    private RectTransform rect;
    public int speed;
    private int cpt;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        timer = Random.Range(5, 10);
        GetComponent<Button>().enabled = false;
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

        //Debug.Log(cpt);
        
    }

    public void addClick()
    {
        GetComponent<Animator>().Play("damage");
        cpt += 1;
        if(cpt == 5)
        {
            FindObjectOfType<AudioManager>().Play("angrymeow2");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("painmeow");
        }
        
    }

    IEnumerator Movement()
    {
        if(rect.localPosition.y <= -2385 && !goUp)
        {
            timer = Random.Range(5, 10);
            goUp = true;
            cpt = 0;
            yield return null;
        }
        else if (!goUp && cpt == 5)
        {
            
            GetComponent<Button>().enabled = false;
            rect.localPosition += Vector3.down * speed * Time.deltaTime;
            yield return null;
        }
        else if (rect.localPosition.y >= -147 && goUp)
        {
            //yield return new WaitForSeconds(5f);
            GetComponent<Button>().enabled = true;
            goUp = false;
            yield return null;
        }
        else if (goUp)
        {
            rect.localPosition += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }
    }
}
