using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{

    public int difficulty;
    public GameObject[] enemyVariant;
    public Transform[] spawnPoints;
    public UnityEvent onComplete;

    public Text rewardText;

    private float spawnDelay;
    private int enemyToBeSpawned;
    private int enemySpawned;
    private int dieCount;
    private int reward;
    private int goldVariable;

    public GameObject[] platforms;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = new LegacyManager().GetDifficulty();
        enemyToBeSpawned = 5 + (difficulty * (difficulty - 1));
        enemySpawned = 0;
        spawnDelay = 2f - (difficulty * 1.5f / 10);
        dieCount = 0;

        platforms[CombatAgent.Instance.level].SetActive(true);

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        yield return new WaitForSeconds(spawnDelay);

        int randEnemy = Random.Range(0, enemyVariant.Length);
        int randSpawn = Random.Range(0, spawnPoints.Length);

        GameObject enemy = Instantiate(enemyVariant[randEnemy], spawnPoints[randSpawn].position, spawnPoints[randSpawn].rotation);

        Damagable enemyDamagable = enemy.GetComponent<Damagable>();
        enemyDamagable.onDie.AddListener(()=>CountDie(randEnemy));

        enemySpawned += 1;

        if (enemySpawned >= enemyToBeSpawned)
        {
            // Finish
        }
        else {
            StartCoroutine(SpawnEnemy());
        }
    }

    void CountDie(int enemyScore) {
        dieCount++;

        goldVariable += enemyScore;

        if (dieCount >= enemyToBeSpawned) {

            reward = (goldVariable * 17) + (enemySpawned * 5) + Random.Range(0, 10);
            rewardText.text = reward + "x";

            onComplete.Invoke();

        }
    }

    public void ClaimReward() {
        CombatAgent.Instance.OnBattleDone();

        LegacyManager lm = new LegacyManager();
        lm.SetCoin(lm.GetCoin()+reward);

        GetComponent<SceneLoader>().RemoveScene("Combat Chapter 1");
    }
}
