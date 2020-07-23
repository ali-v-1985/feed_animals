using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private const float SpamRate = 0.5f;
    private bool _spamPreventer;
    public GameObject dogPrefab;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ( _spamPreventer == false ) {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                Invoke("ResetSpamPreventer",SpamRate);
                _spamPreventer = true;
            }
        }
    }
    
    void ResetSpamPreventer(){
        _spamPreventer = false;
    }
}
