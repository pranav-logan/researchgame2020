using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBlockBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject disableIndicator;
    void Start()
    {
        Instantiate(disableIndicator, gameObject.transform.position, gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
