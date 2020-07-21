using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameGuide : MonoBehaviour
{
    [SerializeField]
    private Canvas gameGuideCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        gameGuideCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            gameGuideCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
