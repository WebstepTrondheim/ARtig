using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;

//public class BallThrower : MonoBehaviour, IMixedRealityGestureHandler<Vector3>, IMixedRealitySpeechHandler
public class GameControl : MonoBehaviour
{
    public GameObject _ballThrower;
    public TextMesh _scoreText;
    public TextMesh _ballsThrownText;

    // Start is called before the first frame update
    private void Awake()
    {

    }

    public void ShowMesh()
    {
        showOrHideMesh(SpatialAwarenessMeshDisplayOptions.Visible);
    }

    public void HideMesh()
    {
        showOrHideMesh(SpatialAwarenessMeshDisplayOptions.None);
    }

    private void showOrHideMesh(SpatialAwarenessMeshDisplayOptions option)
    {
        if (CoreServices.SpatialAwarenessSystem is IMixedRealityDataProviderAccess provider)
        {
            foreach (var observer in provider.GetDataProviders())
            {
                if (observer is IMixedRealitySpatialAwarenessMeshObserver meshObs)
                {
                    meshObs.DisplayOption = option;
                }
            }
        }
    }
}
