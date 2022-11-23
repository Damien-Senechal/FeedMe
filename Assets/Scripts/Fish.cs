using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

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
    public Material fishMat2;
    public Material fishMat3;

    private Vector3 torque;
    public Animator anim;
    public AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawner = FindObjectOfType<Spawner>();
        manager = FindObjectOfType<UIManager>();
        mr = GetComponent<MeshRenderer>();
        audio = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        else
        {
            audio.Play("splash2");

            anim.Play("fishtouch", 0, 0.0f);
            torque.x = Random.Range(-200, 200);
            torque.y = Random.Range(-200, 200);
            torque.z = Random.Range(-200, 200);
            GetComponent<ConstantForce>().torque = torque;
            rb.AddForce(new Vector3(0, 5, 1 * speed), ForceMode.Impulse);
            spawner.isActive[spawnNumber] = false;
        }
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
        else if(c == "fish2")
        {
            mr.material = fishMat2;
        }
        else if(c == "fish3")
        {
            mr.material = fishMat3;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CAT")
        {
            int rand2 = Random.Range(0, 100);
            if (rand2 <= 25)
            {
                int rand = Random.Range(0, 5);
                if (rand == 0)
                {
                    audio.Play("meow1");
                }
                if (rand == 1)
                {
                    audio.Play("meow2");
                }
                if (rand == 2)
                {
                    audio.Play("meow3");
                }
                if (rand == 3)
                {
                    audio.Play("meow4");
                }
                if (rand == 4)
                {
                    audio.Play("meow5");
                }
            }
            manager.addTime(.5f);
            manager.addScore(1);
            //Debug.Log("MES GROSSES COUILLES");
            Destroy(gameObject);
        }
    }
}
