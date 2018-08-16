using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class LeftThigh : MonoBehaviour
{	



	string line;


	static string filename = "Assets/Resources/LeftLeg.txt";

	StreamReader theReader = new StreamReader(filename);


	// Use this for initialization
	void Start()
	{

		line = theReader.ReadLine ();

	}

	// Update is called once per frame
	void Update()
	{
		if (line != null) {
			string[] entries = line.Split (',');

			Quaternion rot = Quaternion.Euler (new Vector3 ((float.Parse (entries [3]) - 110) * 100, float.Parse (entries [5]) * 0, float.Parse (entries [4])- 100));
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime * 2.0f);


			//transform.Translate (float.Parse(entries [0]) / 100, float.Parse(entries [1]) / 100, float.Parse(entries [2]) / 100);


			line = theReader.ReadLine ();
		}
	}

}