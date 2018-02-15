using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Note", menuName = "Note")]
public class Note : ScriptableObject {

	public new string name;
	public string description;

	public Sprite background;
}
