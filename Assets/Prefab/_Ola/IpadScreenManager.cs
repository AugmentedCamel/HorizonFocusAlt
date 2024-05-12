using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GuideStep
{
    public Sprite guideImage;
    public string guideText;
}

public class IpadScreenManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _guideTextPanel;
    [SerializeField] private Image _guideImagePanel;

    [SerializeField] private List<string> keys = new List<string>();
    [SerializeField] private List<GuideStep> values = new List<GuideStep>();

    private Dictionary<string, GuideStep> guideSteps;

    public delegate void GuideStepChanged(string stepKey);
    public event GuideStepChanged OnGuideStepChanged;

    private void Awake()
    {
        guideSteps = new Dictionary<string, GuideStep>();
        for (int i = 0; i < Mathf.Min(keys.Count, values.Count); i++)
        {
            guideSteps.Add(keys[i], values[i]);
        }
    }

    public void ToggleIpadScreen(string stepKey)
    {
        if (guideSteps.ContainsKey(stepKey))
        {
            GuideStep step = guideSteps[stepKey];
            _guideTextPanel.text = step.guideText;
            _guideImagePanel.sprite = step.guideImage;
            OnGuideStepChanged?.Invoke(stepKey);
        }
        else
        {
            Debug.LogError("Step key not found in guideSteps dictionary.");
        }
    }
}