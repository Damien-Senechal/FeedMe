using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fish : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    private int spawnNumber = -1;

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
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        rb.AddForce(new Vector3(0, 6, 1 * speed), ForceMode.Impulse);
        spawner.isActive[spawnNumber] = false;
    }

    public void setSpawnNumber(int n)
    {
        spawnNumber = n;
    }

    public void changeColor(string c)
    {
        if (c == "fish")
        {
            mr.material = fishMat;
        }
        else if (c == "bomb")
        {
            mr.material = bombMat;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CAT")
        {
            manager.addTime(.5f);
            manager.addScore(1);
            //Debug.Log("MES GROSSES COUILLES");
            Destroy(gameObject);
        }
    }
}