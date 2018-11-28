using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    [SerializeField]
    [Range(0.5f, 5.0f)]
    public float delay = 2f;

    Animator animator;
    bool isRunning = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isRunning)
            StartCoroutine(MoveSpikes());
    }

    IEnumerator MoveSpikes()
    {
        isRunning = true;

        // If the spikes are up -> Make them go down and wait for the delay
        if (animator.GetBool("SpikeIsUp"))
        {
            animator.SetBool("SpikeIsUp", false);
            yield return new WaitForSeconds(delay);
        }
        // Else make the spikes go up
        else
        {
            animator.SetBool("SpikeIsUp", true);
        }

        // One second delay
        yield return new WaitForSeconds(1.0f);

        isRunning = false;
    }
}
