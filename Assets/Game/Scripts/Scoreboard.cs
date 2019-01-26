using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    /// <summary>
    /// The score which is shared between all players by moving the van to objectives.
    /// </summary>
    private int teamScore;

    /// <summary>
    /// The scores for each individual player for completing their own objectives inside the van.
    /// </summary>
    private Dictionary<PlayerController, int> playerScores = new Dictionary<PlayerController, int>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Reset the scoreboard for a new game. Players can be added with <c>AddNewPlayer.</c>
    /// </summary>
    public void NewGame()
    {
        teamScore = 0;
        playerScores.Clear();
    }

    /// <summary>
    /// Reset the scoreboard for a new game and set the new players.
    /// </summary>
    /// <param name="player">The players that will play the new game.</param>
    public void AddNewPlayer(PlayerController player)
    {
        playerScores.Add(player, 0);
    }
         
    /// <summary>
    /// Add a player to the scoreboard for the current game.
    /// </summary>
    /// <param name="players">The player which needs to be added.</param>
    public void NewGame(List<PlayerController> players)
    {
        NewGame();
        foreach(var player in players)
        {
            AddNewPlayer(player);
        }
    }

    /// <summary>
    /// Add some points to the teamscore for reaching an objective with the van
    /// </summary>
    /// <param name="points">The amount of scored points</param>
    public void AddTeamPoints(int points)
    {
        teamScore = teamScore + points;
        //TODO: update ui
    }

    /// <summary>
    /// Add some points to a single player for reaching an objective within the van
    /// </summary>
    /// <param name="player">The player which reached the objective</param>
    /// <param name="points">The amount of points</param>
    public void AddPlayerPoints(PlayerController player, int points)
    {
        if (playerScores.ContainsKey(player) && playerScores.TryGetValue(player, out int value))
        {
            playerScores[player] = value + points;
            //TODO: update ui
        }
    }
}
