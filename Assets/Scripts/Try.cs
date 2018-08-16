using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Try : MonoBehaviour
{
	SerialPort serial = new SerialPort("COM4", 115200);

	// Use this for initialization
	void Start()
	{
		serial.Open();

	}

	// Update is called once per frame
	void Update()
	{
		if(!serial.IsOpen)
		{
			serial.Open();
		}
		string[] acc = serial.ReadLine().Split(',');
		string[] mag = serial.ReadLine().Split(',');
		string[] gyr = serial.ReadLine().Split(',');

		//transform.Translate (float.Parse(acc [0]) / 100, float.Parse(acc [1]) / 100, float.Parse(acc [2]) / 100);

		Quaternion rot = Quaternion.Euler(new Vector3(float.Parse(gyr[0]), float.Parse(gyr[1]), float.Parse(gyr[2])));
		transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 2.0f);


	}

}