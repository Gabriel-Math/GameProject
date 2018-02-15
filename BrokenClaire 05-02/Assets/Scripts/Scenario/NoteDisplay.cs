using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteDisplay : MonoBehaviour {

	public Note note;

	public Text nameText;
	public Text descriptionText;

	public Image backgroundNote;

	void Start() {
		nameText.text = note.name;
		descriptionText.text = note.description;

		backgroundNote.sprite = note.background;
	}
}
