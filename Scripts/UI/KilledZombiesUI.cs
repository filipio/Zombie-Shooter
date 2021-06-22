using UnityEngine;
using TMPro;
using System;

public class KilledZombiesUI : MonoBehaviour
{
    public int KilledZombies { get; private set; }

    private TextMeshProUGUI tmproText;
    private int zombiesToBeKilled;
    private Spawner[] spawners;

    public event Action PlayerKilledAllZombies = delegate { };

    private void Awake()
    {
        KilledZombies = 0;
        tmproText = GetComponent<TextMeshProUGUI>();
        ZombieDeath.OnZombieDied += ZombieDie_OnZombieDied;
        spawners = Resources.FindObjectsOfTypeAll<Spawner>();
        PrintSpawners(spawners);
        zombiesToBeKilled = CountZombies(spawners);
        Debug.Log(zombiesToBeKilled);
    }

    private int CountZombies(Spawner[] spawners)
    {
        int zombies = 0;
        foreach (var spawner in spawners)
        {
            zombies += spawner.ZombiesToSpawn;
        }
        return zombies;
    }

    private void PrintSpawners(Spawner[] spawners)
    {
        foreach (var spawner in spawners)
        {
            Debug.Log(spawner.gameObject.name);
        }
    }

    private void ZombieDie_OnZombieDied()
    {
        KilledZombies++;
        if(NoZombiesLeft(KilledZombies))
        {
            PlayerKilledAllZombies();
        }
        tmproText.text = KilledZombies.ToString();
    }

    private bool NoZombiesLeft(int killedZombies)
    {
        Debug.Log(killedZombies);
        return killedZombies >= zombiesToBeKilled;
    }
}
