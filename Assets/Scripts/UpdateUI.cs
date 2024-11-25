using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI distanceText;
    [SerializeField] private TMPro.TextMeshProUGUI bestDistanceText;
    [SerializeField] private TMPro.TextMeshProUGUI goldText;
    [SerializeField] FloorManager floors;
    private float speed;
    private int gold = 0;
    private int bestDistance = 0;
    private float accumulatedDistance = 0f;

    void Start()
    {
        speed = floors.GetSpeed();
    }

    void Update()
    {
        speed = floors.GetSpeed();

        // Accumulate distance based on speed and time
        accumulatedDistance += speed * Time.deltaTime;

        // Update the distance display with the integer part of the accumulated distance
        distanceText.text = ((int)accumulatedDistance) + " M";
    }

    public void SetBestDistance()
    {
        bestDistance = (int)this.accumulatedDistance;
        bestDistanceText.text = "Best: " + bestDistance;
    }

    public void IncrementGold(int gold)
    {
        this.gold += gold;
        goldText.text = this.gold + " Gold";
    }

    public string GetGold()
    {
        return goldText.text;
    }

    public string GetDistance()
    {
        return distanceText.text;
    }

    public string GetBestDistance()
    {
        return bestDistanceText.text;
    }
}
