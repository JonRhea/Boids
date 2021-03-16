using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour{
	
	[Header("Set Dynamically")]
	public Rigidbody rigid;
	
	void Awake(){
		rigid = GetComponent<Rigidbody>();
		pos = Random.insideUnitSphere * Spawner.S.spawnRadius;
		Vector3 vel = Random.onUnitSphere * Spawner.S.velocity;
		rigid.velocity = vel;
		
		LookAhead();
		
		Color randColor = Color.black;
		while(randColor.r + randColor.g + randColor.b < 1.0f){
			randColor = new Color(Random.value, Random.value, Random.value);
		}//end while
		Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
		
		foreach(Renderer r in rends){
			r.material.color = randColor;
		}//end foreach
		
		TrailRenderer tRend = GetComponent<TrailRenderer>();
		tRend.material.SetColor("_TintColor", randColor);
	}//end Awake
	
	void LookAhead(){
		transform.LookAt(pos + rigid.velocity);
	}//end LookAhead
	
	public Vector3 pos{
		get {return transform.position;}
		set {transform.position = value;}
	}//end Vector3 pos
    // Start is called before the first frame update
    void Start()
    {
        
    }//end Start

    // Update is called once per frame
    void Update()
    {
        
    }//end Update
}//end Boid
