using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_start : MonoBehaviour
{
    [SerializeField] private GameObject setting_screen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        setting_screen.SetActive(false);
    }
}
