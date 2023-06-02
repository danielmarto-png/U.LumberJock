using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class UpgradeAreaManager : MonoBehaviour
{

    public TMP_Text upgradeAreaCostText;
    public Tree vtree;
    public Animator transition;
    public float transitionTime = 1f;
    // public int upgradeWood;
    private int upgradeMultiplier = 1;

    void Start()
    {
        vtree = FindAnyObjectByType<Tree>();
    }

    public void FixedUpdate()
    {
        upgradeAreaCostText.text = "Price: " + CalculateUpgradeCost();
    }

    public void UpgradeAreaBuy()
    {

        if (vtree.wood >= CalculateUpgradeCost())
        {
            vtree.wood -= CalculateUpgradeCost();

            upgradeMultiplier++;

            LoadNextLevel(1);

            upgradeAreaCostText.text = "Price: " + CalculateUpgradeCost();
        }
        Debug.Log("Quantidade de Madeiras: " + vtree.GetWoodCount());
        // Faça as ações necessárias para o upgrade
    }
    private int CalculateUpgradeCost()
    {
        int baseCost = 1;
        return baseCost * upgradeMultiplier;
    }
    public void LoadNextLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex)); 
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}