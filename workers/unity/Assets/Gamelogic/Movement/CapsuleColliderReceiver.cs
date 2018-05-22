using Improbable.Movement;
using Improbable.Unity.Visualizer;
using Improbable.Worker;
using UnityEngine;

namespace Gamelogic.Movement
{
	public class CapsuleColliderReceiver : MonoBehaviour
	{
		[Require] private CapsuleColliderData.Reader mCapsuleColliderDataReader;

		private CapsuleCollider mCollider;
		private void OnEnable()
		{
			mCollider = GetComponent<CapsuleCollider>();
			if(mCapsuleColliderDataReader == null)
				return;
			
			mCapsuleColliderDataReader.CenterXUpdated.Add(OnCenterXReader);
			mCapsuleColliderDataReader.CenterYUpdated.Add(OnCenterYReader);
			mCapsuleColliderDataReader.CenterZUpdated.Add(OnCenterZReader);
			mCapsuleColliderDataReader.RadiusUpdated.Add(OnRadiusReader);
			mCapsuleColliderDataReader.HeightUpdated.Add(OnHeightReader);
			mCapsuleColliderDataReader.TriggerUpdated.Add(OnIsTriggerReader);
		}

		private void OnDisable()
		{
			if(mCapsuleColliderDataReader == null)
				return;
			
			mCapsuleColliderDataReader.CenterXUpdated.Add(OnCenterXReader);
			mCapsuleColliderDataReader.CenterYUpdated.Add(OnCenterYReader);
			mCapsuleColliderDataReader.CenterZUpdated.Add(OnCenterZReader);
			mCapsuleColliderDataReader.RadiusUpdated.Add(OnRadiusReader);
			mCapsuleColliderDataReader.HeightUpdated.Add(OnHeightReader);
			mCapsuleColliderDataReader.TriggerUpdated.Add(OnIsTriggerReader);
		}

		private void OnCenterXReader(float value)
		{
			if(mCapsuleColliderDataReader == null || mCapsuleColliderDataReader.Authority == Authority.NotAuthoritative)
				return;
			
			if(mCollider == null)
				return;

			Vector3 center = mCollider.center;
			center.x = value;
			mCollider.center = center;
		}
		
		private void OnCenterYReader(float value)
		{
			if(mCapsuleColliderDataReader == null || mCapsuleColliderDataReader.Authority == Authority.NotAuthoritative)
				return;

			if(mCollider == null)
				return;

			Vector3 center = mCollider.center;
			center.y = value;
			mCollider.center = center;
		}
		
		private void OnCenterZReader(float value)
		{
			if(mCapsuleColliderDataReader == null || mCapsuleColliderDataReader.Authority == Authority.NotAuthoritative)
				return;

			if(mCollider == null)
				return;

			Vector3 center = mCollider.center;
			center.z = value;
			mCollider.center = center;
		}

		private void OnRadiusReader(float value)
		{
			if(mCapsuleColliderDataReader == null || mCapsuleColliderDataReader.Authority == Authority.NotAuthoritative)
				return;

			if(mCollider == null)
				return;

			mCollider.radius = value;
		}
		
		private void OnHeightReader(float value)
		{
			if(mCapsuleColliderDataReader == null || mCapsuleColliderDataReader.Authority == Authority.NotAuthoritative)
				return;

			if(mCollider == null)
				return;

			mCollider.height = value;
		}
		
		private void OnIsTriggerReader(bool value)
		{
			if(mCapsuleColliderDataReader == null || mCapsuleColliderDataReader.Authority == Authority.NotAuthoritative)
				return;

			if(mCollider == null)
				return;

			mCollider.isTrigger = value;
		}
	}
}