using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
	[SerializeField]
	private RawImage m_icon;

	[SerializeField]
	private TextMeshProUGUI m_label;

	public void Set(Item item)
	{
		m_icon.texture = item.icon;

		m_label.text = item.name;
	}

	public void EquipThis()
    {
		StarterAssets.FirstPersonController.instance.Equip(m_label.text);
    }
}
