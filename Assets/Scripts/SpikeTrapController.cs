using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
    public GameObject spikes;
    public float downTime,upTime,startTime;

    private float time;
    private bool active;
    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider=GetComponent<BoxCollider>();
        spikes.SetActive(false);
        boxCollider.enabled=false;
        time=startTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if (active==false && time >=downTime)
        {
            time=0;
            spikes.SetActive(true);
            boxCollider.enabled=true;
            active=true;
        }

        if (active==true && time >=upTime)
        {
            time=0;
            spikes.SetActive(false);
            boxCollider.enabled=false;
            active=false;
        }
        
    }
}
