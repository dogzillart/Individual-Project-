using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource musicSource;


    // Start is called before the first frame update
    void Start()
    {
        musicSource.PlayDelayed(12);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
