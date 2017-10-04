using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNodePosition : MonoBehaviour
{
	string code;


		public static PlayerNodePosition instance = null;

		void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else if (instance != this)
			{
				Destroy(gameObject);
			}
		}


	public void AddCode(string _code)
	{
		code = _code;
	}
}
