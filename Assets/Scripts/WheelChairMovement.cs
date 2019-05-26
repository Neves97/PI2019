using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChairMovement : MonoBehaviour
{

    /// <summary>
    /// Não esqueça de configurar os eixos LANALOG,RANALOG E BRAKE R E L em preferences pra funcionar
    /// 
    /// 
    /// </summary>


    #region Variaveis Roda Esquerda
    public WheelCollider WheelLeft;
    public WheelCollider WheelLeft2;  //Componente wheelcollider correspondente
    private float CurrentSpeed_L;      //Velocidade de torque roda atual;   
    #endregion
    #region Variaveis Roda Direita
    public WheelCollider WheelRight;
    public WheelCollider WheelRight2;
    private float CurrentSpeed_R;      //Velocidade de torque roda atual;   
    #endregion
    #region Variaveis gerais
    public float Speed = 20f;        //Velocidade base, aumentar pra ir mais rápido
    public float BrakeForce;             //Força do freio , valores pequenos recomendados
    private float temp_BrakeForce_L;               //Mesma coisa de cima, só segura o valor
    private float temp_BrakeForce_R;               //Mesma coisa de cima, só segura o valor
    public Transform transfWhell_L, transfWhell_R;
    Quaternion WheelRot_L, WheelRot_R;
    Vector3 pos;
    #endregion
    private float Analogico1;
    private float Analogico2;
  
   

    public float speedThreshold;
    public int stepsBelowThreshold, stepsAboveThreshold;
    // Start is called before the first frame update
    private void Start()
    {
     
        
    }


    private void Update()
    {
        WheelLeft.ConfigureVehicleSubsteps(speedThreshold, stepsBelowThreshold, stepsAboveThreshold);


        InputRodaDir();   // onde Rece os inputs;
        InputRodaEsq();

        WheelLeft.GetWorldPose( out pos, out WheelRot_L); //pega a rotação do wheel collider e coloca no modelo da roda
        WheelRight.GetWorldPose(out pos, out WheelRot_R);
        transfWhell_L.rotation = WheelRot_L;
        transfWhell_R.rotation = WheelRot_R;
      
    }
    // Update is called once per frame
    void FixedUpdate()
   {

        WheelLeft.brakeTorque = Mathf.Abs(temp_BrakeForce_L * (Speed));
        WheelLeft.motorTorque  = CurrentSpeed_L = Analogico1 *Speed;
        WheelLeft.motorTorque = CurrentSpeed_L ;
        WheelLeft2.motorTorque = CurrentSpeed_L;

        WheelRight.brakeTorque = Mathf.Abs(temp_BrakeForce_R * (Speed));
        WheelRight.motorTorque = CurrentSpeed_R= Analogico2 * Speed;
        WheelRight.motorTorque = CurrentSpeed_R ;
        WheelRight2.motorTorque = CurrentSpeed_R;


    }
  
    void InputRodaEsq()
    {
        Analogico1 = Input.GetAxis("LAnalog");
      
        if (Input.GetButton("Brake_L"))
        {
            Debug.Log("lol");
            temp_BrakeForce_L = BrakeForce;

        }
        else if (Input.GetButtonUp("Brake_L"))
        {
            temp_BrakeForce_L = 0f;
        }

        




    }
    void InputRodaDir()
    {
        
        Analogico2 = Input.GetAxis("RAnalog");
        
        if (Input.GetButton("Brake_R"))
        {

            temp_BrakeForce_R = BrakeForce;

        }
        else if (Input.GetButtonUp("Brake_R"))
        {
            temp_BrakeForce_R = 0f;
        }
    }

   

}
