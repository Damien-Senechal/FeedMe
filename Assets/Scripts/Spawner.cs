using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public List<Spawn> spawn;
    private float timer = 0f;
    public float timerLenght;
    private int rand = 0;
    public List<bool> isActive;
    private int isBomb = 0;

    public Fish fish;
    public Bomb bomb;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawn.Count; i++)
        {
            isActive.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            rand = Random.Range(0, spawn.Count);
            isBomb = Random.Range(0, 100);
            //Debug.Log(isBomb);
            if (isActive[rand] == false)
            {
                if(isBomb < 30)
                {
                    Bomb temp = Instantiate(bomb,
                                            new Vector3(spawn[rand].transform.position.x,
                                                        spawn[rand].transform.position.y + 1,
                                                        spawn[rand].transform.position.z),
                                            Quaternion.identity
                                            );
                    temp.setSpawnNumber(rand);
                    int mat = Random.Range(0, 100);
                    //Debug.Log(mat);
                    if(mat <= 15)
                    {
                        temp.changeColor("fish");
                    }
                    else
                    {
                        temp.changeColor("bomb");
                    }
                    isActive[rand] = true;
                }
                else
                {
                    Fish temp = Instantiate(fish,
                                            new Vector3(spawn[rand].transform.position.x,
                                                spawn[rand].transform.position.y + .5f,
                                                spawn[rand].transform.position.z),
                                            Quaternion.identity
                                            );
                    temp.setSpawnNumber(rand);
                    int mat = Random.Range(0, 100);
                    if (mat <= 15)
                    {
                        temp.changeColor("bomb");
                    }
                    else
                    {
                        temp.changeColor("fish");
                    }
                    isActive[rand] = true;
                }
            }
            timer = timerLenght;
        }
    }
}
