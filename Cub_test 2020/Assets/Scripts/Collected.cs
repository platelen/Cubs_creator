using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    private bool isCollected;
    private int index;
    private Color nutralColor = Color.grey;

    public Collector collector;

    void Start()
    {
        isCollected = false;
    }

    void Update()
    {
        if (isCollected == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("FFFF");
            collector.RemoveCubs();
            transform.parent = null;
            gameObject.GetComponentInChildren<Renderer>().material.color = nutralColor;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject,2);
        }
    }
    public bool GetCollected()
    {
        return isCollected;
    }

    public void Joint()
    {
        isCollected = true;
    }

    public void IndexCubs(int index)
    {
        this.index = index;
       
    }
}
