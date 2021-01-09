using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    string hpstring;
    public Text text;
    public GameObject player;
    public PlayerMovement script;

    private void Start()
    {
        script = player.GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = script.hp.ToString();
       
    }

}
