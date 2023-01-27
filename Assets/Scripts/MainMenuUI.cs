using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown difficulityChoice;

    [SerializeField]
    private LevelData levelData;

    [SerializeField]
    private List<Difficulty> difficultiesList;

    private void Start()
    {
        levelData.difficulty = difficultiesList[levelData.difficultyNumber];
        difficulityChoice.value = levelData.difficultyNumber;
    }

    public void DropdownDifficulityChanged(int index)
    {
        levelData.difficultyNumber = index;
        levelData.difficulty = difficultiesList[index];
    }
}
