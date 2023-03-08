using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{

    public Slider boostBar;
    private int maxBoost = 100;
    private int currentBoost;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    public static SliderManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        currentBoost = maxBoost;
        boostBar.maxValue = maxBoost;
        boostBar.value = maxBoost;
    }

    public void useBoost(int amount)
    {
        if(currentBoost - amount >= 0)
        {
            currentBoost -= amount;
            boostBar.value = currentBoost;
            StartCoroutine(regenBoost());
        }
        else
        {

        }
    }

    private IEnumerator regenBoost()
    {
        yield return new WaitForSeconds(2);

        while(currentBoost < maxBoost)
        {
            currentBoost += maxBoost / 100;
            boostBar.value = currentBoost;
            yield return regenTick;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveSlider(float sentTime, bool zoomMode)
    {
        float timeSinceZoom = Time.time - sentTime;
        
        if (zoomMode)
        {
           // slider.value = slider.value - timeSinceZoom / 10;
        }
        else
        {
          //  slider.value = timeSinceZoom / 10;
        }

    }

}
