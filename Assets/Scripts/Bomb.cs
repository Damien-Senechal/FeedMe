using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Bomb : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    private int spawnNumber = -1;
    private float timer = 1.25f;
    private bool isActive = false;
    public GameObject explosion;

    public Spawner spawner;
    public UIManager manager;
    public MeshRenderer mr;

    public Material bombMat;
    public Material fishMat;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawner = FindObjectOfType<Spawner>();
        manager = FindObjectOfType<UIManager>();
        //mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0 && isActive == false)
        {
            Destroy(gameObject);
            spawner.isActive[spawnNumber] = false;
        }
    }

    private void OnMouseDown()
    {
        isActive = true;
        rb.AddForce(new Vector3(0, 6, 1 * speed), ForceMode.Impulse);
        spawner.isActive[spawnNumber] = false;
    }

    public void setSpawnNumber(int n)
    {
        spawnNumber = n;
    }

    public void changeColor(string c)
    {
        if(c == "fish")
        {
            mr.material = fishMat;
        }
        else if(c == "bomb")
        {
            mr.material = bombMat;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CAT")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            //Debug.Log("MES GROSSES COUILLES");
            if (manager.getScore() > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", manager.getScore());
            }
            StartCoroutine(Wait(1f));
            
        }
    }

    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(0);
    }
}
