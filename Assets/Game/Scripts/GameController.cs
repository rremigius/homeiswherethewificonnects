using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int numberOfPlayers = 4;
    private Color[] PlayerColors = { Color.green, Color.magenta, Color.yellow, Color.blue };
    private Vector3[] StartPositions = { new Vector3(0, 1, 0), new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, -1, 0) };
    //allows you to put a ref to player prefab in the gamecontroller
    public GameObject PlayerCharacterPrefab;


    void Start()
    {
        for (int p = 0; p < numberOfPlayers; p++)
        {
            GameObject PlayerCharacter = Instantiate(PlayerCharacterPrefab);
            PlayerCharacter.GetComponent<PlayerController>().PlayerColor = PlayerColors[p];
            //PlayerCharacter.transform.position = StartPositions[p];
        }
    }


    void Update()
    {
       
    }


    
}
