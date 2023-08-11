using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HumanUIManager : MonoBehaviour
{
	public GameObject humanEntryPrefab; // Assign your UI entry prefab here
	public Transform contentTransform; // Assign the content transform of the ScrollView here
	public HumanManager humanManager; // Assign your HumanManager script here

	public float entryHeight = 100f;
	
	private void Start()
	{
		CreateUIEntries();
	}

	public void CreateUIEntries()
	{
		foreach (var HumanInfo in humanManager.humansList)
		{
			GameObject entry = Instantiate(humanEntryPrefab, contentTransform);

			RectTransform entryRectTransform = entry.GetComponent<RectTransform>();
			entryRectTransform.anchoredPosition = new Vector2(0f, -entryHeight * contentTransform.childCount);

			UpdateUIEntry(entry, HumanInfo);
		}
	}

	private void UpdateUIEntry(GameObject entry, HumanManager.HumanInfo HumanInfo)
	{
		// Update TMP elements within the entry GameObject with HumanInfo values
		TMP_Text healthText = entry.transform.Find("HealthText").GetComponent<TMP_Text>();
		TMP_Text jobText = entry.transform.Find("JobText").GetComponent<TMP_Text>();
		TMP_Text energyText = entry.transform.Find("EnergyText").GetComponent<TMP_Text>();
		Slider healthSlider = entry.transform.Find("HealthSlider").GetComponent<Slider>();
		Slider energySlider = entry.transform.Find("EnergySlider").GetComponent<Slider>();

		healthText.text = "Health: " + HumanInfo.Health.ToString();
		energyText.text = "Energy: " + HumanInfo.Energy.ToString();

		healthSlider.value = HumanInfo.Health;
		energySlider.value = HumanInfo.Energy;

		healthSlider.onValueChanged.AddListener((value) =>
		{
			HumanInfo.Health = (int)value;
			healthText.text = "Health: " + HumanInfo.Health.ToString();
		});

		energySlider.onValueChanged.AddListener((value) =>
		{
			HumanInfo.Energy = value;
			energyText.text = "Energy: " + HumanInfo.Energy.ToString();
		});
	}
}
