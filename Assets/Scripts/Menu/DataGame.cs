using System.Collections;
using UnityEngine;

public class DataGame : MonoBehaviour
{

    private static DataGame _inctance;

    public bool IsDead { get; set; }
    public bool StopGame { get; set; }

    public bool IsOver { get; set; }

    private void Awake()
    {
        _inctance = this;
    }

    public static DataGame GetInctance()
    {
        return _inctance;
    }

    private void Update()
    {
        
    }
}
