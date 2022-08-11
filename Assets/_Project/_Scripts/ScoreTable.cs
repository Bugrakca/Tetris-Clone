using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTable : MonoBehaviour
{
    public TextMeshProUGUI user_1;
    public TextMeshProUGUI user_2;
    public TextMeshProUGUI user_3;
    public TextMeshProUGUI user_4;



    // Start is called before the first frame update
    void Start()
    {
        BestScores();
    }

    public void BestScores()
    {
        user_1.text = $"1. {GameManager.Instance.score1.ToString()}";
        user_2.text = $"2. {GameManager.Instance.score2.ToString()}";
        user_3.text = $"3. {GameManager.Instance.score3.ToString()}";
        user_4.text = $"4. {GameManager.Instance.score4.ToString()}";

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        BestScores();
    }
}