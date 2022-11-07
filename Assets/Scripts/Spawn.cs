using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject fish;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //Instantiate(fish, new Vector3(this.transform.position.x, this.transform.position.y+.5f, this.transform.position.z), Quaternion.identity);
    }
}
