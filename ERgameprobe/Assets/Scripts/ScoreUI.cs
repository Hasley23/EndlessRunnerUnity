using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text scoreUI;

    private void Update() 
    {
        scoreUI.text = "Score: " + ((int)(player.position.z / 2)).ToString();     
    }
}
