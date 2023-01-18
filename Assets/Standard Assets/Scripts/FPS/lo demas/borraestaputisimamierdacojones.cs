using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borraestaputisimamierdacojones : MonoBehaviour {

    public Animator m_Animator;
    private float cojones;
    void Start () {
        
        }
	
	// Update is called once per frame
	void Update () {
        cojones += Time.deltaTime;
        if (cojones > 0.5f && cojones < 2)
        {
            m_Animator.enabled = false;
            cojones = 3;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            m_Animator.enabled = true;
            Debug.Log("Spinning");
            // anim.Play("recargahomosexual");
            m_Animator.SetBool("putamadre", true);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Spinning");
            // anim.Play("recargahomosexual");
            m_Animator.SetBool("putamadre", false);
            
            if (cojones > 0.1f)
            {
                m_Animator.enabled = false;
            }
        }

    }
}
