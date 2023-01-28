using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishMenuUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown difficulityChoice;

    [SerializeField]
    private TMP_Text attemptsText, scoreText;

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

    public void ShowInfo(int score)
    {
        attemptsText.SetText("Количество попыток: " + levelData.GetAtttempts());
        scoreText.SetText("Текущий рекорд: " + score);
    }
}
