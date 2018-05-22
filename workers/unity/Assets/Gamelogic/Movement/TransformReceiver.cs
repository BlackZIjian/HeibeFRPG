using System.Collections;
using System.Collections.Generic;
using Improbable;
using Improbable.Core;
using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using Improbable.Worker;

namespace Gamelogic.Movement
{
	public class TransformReceiver : MonoBehaviour
	{
		[Require] private Position.Reader mPositionReader;

		[Require] private Rotation.Reader mRotationReader;
		// Use this for initialization
		private void OnEnable()
		{
			if (mPositionReader != null)
				mPositionReader.CoordsUpdated.Add(ReceivePositionSync);
			
			if(mRotationReader != null)
				mRotationReader.RotationUpdated.Add(ReceiveRotationSync);
		}

		private void OnDisable()
		{
			if (mPositionReader != null)
				mPositionReader.CoordsUpdated.Remove(ReceivePositionSync);
			
			if(mRotationReader != null)
				mRotationReader.RotationUpdated.Remove(ReceiveRotationSync);
		}

		public void ReceivePositionSync(Coordinates coor)
		{
			if (mPositionReader.Authority == Authority.NotAuthoritative)
				transform.position = coor.ToUnityVector();
		}

		public void ReceiveRotationSync(float eulerY)
		{
			if (mRotationReader.Authority == Authority.NotAuthoritative)
				transform.rotation = Quaternion.Euler(0, eulerY, 0);
		}
	}
}
