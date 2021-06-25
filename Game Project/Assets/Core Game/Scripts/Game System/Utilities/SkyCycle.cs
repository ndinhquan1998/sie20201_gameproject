using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DQ
{
	public class SkyCycle : MonoBehaviour
	{

		//the secondsPerMinute changes the length of a minute. A lower value 
		public float secondsPerMinute = 0.625f;

		//starting time in hours, use decimal points for minutes
		public float startTime = 12.0f;

		//show date/time information?
		public bool showGUI = false;

		//this variable is for the position of the area in degrees from the equator, therfore it must stay between 0 and 90.
		//It determines now high the sun rises throughout the day, but not the length of the day yet.
		public float latitudeAngle = 45.0f;

		//The transform component of the empty that tilts the sun's rotation.(the SunTilt object, not the Sun object itself)
		public GameObject sunTilt;


		private float day;
		private float min;
		private float smoothMin;

		private float texOffset;
		public Material skyMat;
		public GameObject sunOrbit;


		Vector3 sunAngle;
		Vector3 sunOrbitAngle;
		void Start()
		{
			skyMat = GetComponent<Renderer>().sharedMaterial;
			;
			sunAngle = new Vector3(Mathf.Clamp(latitudeAngle, 0, 90), 0, 0);
			sunTilt.transform.eulerAngles = sunAngle; //set the sun tilt

			if (secondsPerMinute == 0)
			{
				Debug.LogError("Error! Can't have a time of zero, changed to 0.01 instead.");
				secondsPerMinute = 0.01f;
			}
		}

		void Update()
		{
			UpdateSky();
		}

		void UpdateSky()
		{
			smoothMin = (Time.time / secondsPerMinute) + (startTime * 60);
			day = Mathf.Floor(smoothMin / 1440) + 1;

			smoothMin = smoothMin - (Mathf.Floor(smoothMin / 1440) * 1440); //clamp smoothMin between 0-1440
			min = Mathf.Round(smoothMin);

			sunOrbitAngle = new Vector3(0, smoothMin / 4, 0);
			sunOrbit.transform.localEulerAngles = sunOrbitAngle;
			texOffset = Mathf.Cos((((smoothMin) / 1440) * 2) * Mathf.PI) * 0.25f + 0.25f;
			skyMat.SetTextureOffset("_MainTex", new Vector2(Mathf.Round((texOffset - (Mathf.Floor(texOffset / 360) * 360)) * 1000) / 1000, 0));
		}




	}
}
