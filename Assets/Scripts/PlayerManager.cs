using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

    public float Speed;
    public GameObject PlayerPrefab;
    public GameObject Camera;
    //public List<GameObject> players;

    // Use this for initialization
    void Start()
    {
        GameObject player = (GameObject)Instantiate(PlayerPrefab, new Vector3(0f, 1f, 0f), Quaternion.identity);
        GameObject bot1 = (GameObject) Instantiate(PlayerPrefab, new Vector3(10f, 1f, 10f), Quaternion.identity);
        player.AddComponent<Player>();
        player.GetComponent<Player>().Speed = 10;
        //players.Add(player);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
