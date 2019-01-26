using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{

    private Text teamScoreField;
    private Dictionary<int, Text> playerScores = new Dictionary<int, Text>();

    // Start is called before the first frame update
    void Start()
    {
        teamScoreField = GameObject.Find("teamScoreField").GetComponent<Text>();
        playerScores.Add(1, GameObject.Find("playerScore1").GetComponent<Text>());
        playerScores.Add(2, GameObject.Find("playerScore2").GetComponent<Text>());
        playerScores.Add(3, GameObject.Find("playerScore3").GetComponent<Text>());
        playerScores.Add(4, GameObject.Find("playerScore4").GetComponent<Text>());
        NewGame();
        EventBus.OnPlayerScored += AddPlayerPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        foreach(Text text in playerScores.Values)
        {
            text.text = "0";
        }
        teamScoreField.text = "0";
    }

    
    public void AddPlayerPoints(PlayerController player, int points)
    {
        Text textField = playerScores.First(x => x.Key == player.id).Value;
        textField.text = (Convert.ToInt32(textField.text) + points).ToString();
        AddTeamPoints(points);

    }
    public void AddTeamPoints(int points)
    {
        teamScoreField.text = (Convert.ToInt32(teamScoreField.text) + points).ToString();
    }
}
