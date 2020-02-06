// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Microsoft.MixedReality.SpectatorView
{
    /// <summary>
    /// MonoBehaviour that reports tracking information for an ARCore device.
    /// </summary>
    public class ARCoreTrackingObserver : TrackingObserver
    {
        private ARSession ARSession;

        private void Start()
        {
            ARSession = FindObjectOfType<ARSession>();
        }

        /// <inheritdoc/>
        public override TrackingState TrackingState
        {
            get
            {
#if UNITY_ANDROID

                if (ARSession.subsystem.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                {
                    return TrackingState.Tracking;
                }
                
                return TrackingState.LostTracking;
#elif UNITY_EDITOR
                return TrackingState.Tracking;
#else
                return TrackingState.Unknown;
#endif
            }
        }
    }
}