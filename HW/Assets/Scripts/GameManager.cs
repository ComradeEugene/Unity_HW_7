using JetBrains.Annotations;
using Mono.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    const float productCycleTime = 5f;
    const float payCycleTime = 15f;
    const float raidCycleTime = 30f;
    const int winValue = 200;
	const float workerConstructTime = 3f;
	const float soldierConstructTime = 3f;

    private int round;
    private int enemiesDestroyeds;
    private int totalIncome;
    private int moneyCount;
    private int raidPower;

	[SerializeField] private int workerCost;
	[SerializeField] private int soldierCost;
	[SerializeField] private int money;
	[SerializeField] private int workersCount;
	[SerializeField] private int soldiersCount;
    [SerializeField] private int moneyPerWorker;
    [SerializeField] private int moneyToSoldier;

    [SerializeField] CycleTimer productionTimer;
    [SerializeField] CycleTimer payTimer;
    [SerializeField] CycleTimer raidTimer;
    [SerializeField] Timer workerTimer;
    [SerializeField] Timer soldierTimer;
    [SerializeField] GameObject finalResult;

    [SerializeField] private Text workersText;
    [SerializeField] private Text soldiersText;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text statisticsText;
    [SerializeField] private Text finalText;

    [SerializeField] private Button workerButton;
    [SerializeField] private Button soldierButton;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        TimersMechanics();

        CheckButton(workerButton, workerTimer, workerCost);
        CheckButton(soldierButton, soldierTimer, soldierCost);
        CheckResult();

        UpdateText();
    }
    public void StartGame()
    {
        productionTimer.maxTime = productCycleTime;
        payTimer.maxTime = payCycleTime;
        raidTimer.maxTime = raidCycleTime;
		workerTimer.count = workersCount;
		soldierTimer.count = soldiersCount;
        round = 1;
        raidPower = 0;
        enemiesDestroyeds = 0;
        moneyCount = money;
        totalIncome = money;
		UpdateText();
	}

    public void CreateWorker()
    {
        moneyCount -= workerCost;
        workerTimer.StartTimer(workerConstructTime);
    }

    public void CreateSoldier()
    {
		moneyCount -= soldierCost;
		soldierTimer.StartTimer(soldierConstructTime);
	}

    private void CheckButton(Button button, Timer timer, int cost)
    {
        if (timer.tick || moneyCount < cost)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
	private void TimersMechanics()
    {
		if (productionTimer.tick)
		{
			moneyCount += workerTimer.count * moneyPerWorker;
			totalIncome += workerTimer.count * moneyPerWorker;
		}
		if (payTimer.tick)
		{
			moneyCount -= soldierTimer.count * moneyToSoldier;
		}
		if (raidTimer.tick)
        {
            soldierTimer.count -= raidPower;
            enemiesDestroyeds += raidPower;
            raidPower += 2;
            round++;
        }
    }

    private void CheckResult() 
    {
        if (moneyCount >= winValue)
        {
            finalResult.SetActive(true);
            finalText.text = "Victory!!!";
            
        }
        else if (soldierTimer.count < 0)
        {
            finalResult.SetActive(true);
            finalText.text = "Gameover";
        }
    }
    private void UpdateText()
    {
        workersText.text = workerTimer.count.ToString();
        soldiersText.text = soldierTimer.count.ToString();
        moneyText.text= moneyCount.ToString();
        statisticsText.text = round + "\n" + raidPower + "\n" + enemiesDestroyeds + "\n" + totalIncome;
    }
}
