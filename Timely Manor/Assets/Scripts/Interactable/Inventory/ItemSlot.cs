using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
	[SerializeField]
	private Image m_icon;

	[SerializeField]
	private TextMeshProUGUI m_label;

	public void Set(Item item)
	{
		m_icon.sprite = item.icon;

		m_label.text = item.name;
	}
}
