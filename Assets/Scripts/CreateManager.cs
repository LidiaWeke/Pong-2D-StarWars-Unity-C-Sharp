using UnityEngine;
using TMPro;

public class CreateManager : MonoBehaviour
{
    [SerializeField] private TMP_Text blueScoreText;
    [SerializeField] private TMP_Text redScoreText;

    [SerializeField] private Transform blueTransform;
    [SerializeField] private Transform redTransform;
    [SerializeField] private Transform ballTransform;

    private int blueScore;
    private int redScore;

    private static CreateManager instance;

    public static CreateManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<CreateManager>();
            }
            return instance;
        }
    }

    public void BlueScored()
    {
        blueScore++;
        blueScoreText.text = blueScore.ToString();
    }

    public void RedScored()
    {
        redScore++;
        redScoreText.text = redScore.ToString();
    }

    public void Restart()
    {
        blueTransform.position = new Vector2(blueTransform.position.x, 0);
        redTransform.position = new Vector2(redTransform.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
    }

}
