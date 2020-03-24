using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private GameObject taquicardia, braquicardia, pilula;
    private bool statusTaquicardia, statusBraquicardia, statusPilula;
    public LerpEquationTypes lerp;
    private float maxTaquicardia, maxBraquicardia, minTaquicardia, minBraquicardia, speed;

    // Start is called before the first frame update
    void Start()
    {
        taquicardia = GameObject.Find("TaquicardiaImg");
        braquicardia = GameObject.Find("BraquicardiaImg");
        pilula = GameObject.Find("PillImg");
        minBraquicardia = 0.1f;
        maxBraquicardia = 1;
        minTaquicardia = 1;
        maxTaquicardia = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        statusTaquicardia = taquicardia.transform.GetChild(0).gameObject.activeSelf;
        statusBraquicardia = braquicardia.transform.GetChild(0).gameObject.activeSelf;
        statusPilula = pilula.transform.GetChild(0).gameObject.activeSelf;

        if (statusTaquicardia && statusPilula)
        {
            Debug.Log("statusTaquicardia e statusPilula ativo");

        }

        if (statusTaquicardia && statusPilula)
        {
            //calculadr distância
            float distancia = Vector3.Distance(taquicardia.transform.position, pilula.transform.position);

            // pegar animator && Audio source
            Animator _animator = braquicardia.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
            AudioSource _audioSource = braquicardia.transform.GetChild(0).GetChild(0).GetComponent<AudioSource>();
            if (_animator != null)
            {

                if(distancia > maxTaquicardia)
                {
                    speed = maxTaquicardia;
                } else
                {
                    speed = distancia;
                }

                // diminuir velocidade da animação
                _animator.speed = speed;

                // diminuir velocidade do batimento
                _audioSource.pitch = speed;
                Debug.Log("velocidade => " + _animator.speed);
            }
        }

        if (statusBraquicardia && statusPilula) // braquicardia
        {
            //calculadr distância
            float distancia = Vector3.Distance(taquicardia.transform.position, pilula.transform.position);

            // pegar animator
            Animator _animator = braquicardia.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
            AudioSource _audioSource = braquicardia.transform.GetChild(0).GetChild(0).GetComponent<AudioSource>();
            if (_animator != null)
            {
                if(distancia > maxBraquicardia + 3)
                {
                    speed = maxBraquicardia;
                } else
                {
                    speed = -distancia + 3.3F;
                }
                // diminuir velocidade da animação
                _animator.speed = speed;

                // diminuir velocidade do batimento
                _audioSource.pitch = speed;
                Debug.Log("velocidade => " + _animator.speed);
            }
        }

    }
}
