using Ores;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    private OreUnit[] ores;
    
    private void Start()
    {
        ores = Resources.LoadAll<OreUnit>("Ores");
    }
    
    public void Mine()
    {
        Debug.Log("Player is mining ores.");
    }
}