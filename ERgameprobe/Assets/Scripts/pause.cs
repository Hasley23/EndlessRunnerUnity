using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    [SerializeField] private Button pauseBtn;
    [SerializeField] private GameObject pauseScreen;
    
    public void OnPause()
    {
        Time.timeScale = 0;
        pauseBtn.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(true);
    }

    public void OnContinue()
    {
        pauseBtn.gameObject.SetActive(true);
        pauseScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
