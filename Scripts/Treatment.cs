using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Treatment : MonoBehaviour, ITrackableEventHandler
{

    TrackableBehaviour trackable;
    private bool tracked;

    // Start is called before the first frame update
    void Start()
    {
        trackable = GetComponent<TrackableBehaviour>();
        if (trackable)
            trackable.RegisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(
      TrackableBehaviour.Status previousStatus,
      TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            OnTrackingFound();
        else
            onTrackingLost();
    }
    private void OnTrackingFound()
    {
        if (transform.childCount > 0)
            SetChildrenActive(true);
    }
    private void onTrackingLost()
    {
        if (transform.childCount > 0)
            SetChildrenActive(false);
    }
    private void SetChildrenActive(bool activeState)
    {
        tracked = activeState;
        for (int i = 0; i <= transform.childCount; i++)
            transform.GetChild(i++).gameObject.SetActive(activeState);

    }
}
