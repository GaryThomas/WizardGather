using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
	Animator _anim;

	void Awake ()
	{
		_anim = GetComponent<Animator> ();
	}

	public void FadeToClear ()
	{
		_anim.SetTrigger ("FadeToClear");
	}

	public void FadeToBlack ()
	{
		_anim.SetTrigger ("FadeToBlack");
	}
}
