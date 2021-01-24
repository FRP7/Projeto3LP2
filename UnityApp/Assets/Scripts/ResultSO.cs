using UnityEngine;

/// <summary>
/// Class where the ScriptableObject keeps the player's color.
/// </summary>
[CreateAssetMenu(menuName = "ResultSpec")]
public class ResultSO : ScriptableObject
{
    /// <summary>
    /// Gets and sets whether the player is white.
    /// </summary>
    public bool HasPlayerWon { get; set; }
}
