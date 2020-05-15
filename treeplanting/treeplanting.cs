/*
Concept - position trees by pointing at places during runtime and have those trees persist after runtime or record the positions and 

Placing trees 
------------------
This should be straight forward, like a script for placing bullet-holes on a surface. 
On trigger press, raycast forward from controller to a collider (the ground) and instantiate a tree prefab at the collision point.
 - https://docs.unity3d.com/Manual/InstantiatingPrefabs.html


Saving position 
------------------
 - https://answers.unity.com/questions/727974/how-can-i-keep-the-game-objects-when-i-quit-play-m.html
 - https://www.youtube.com/watch?v=lBzwUKQ3tbw - While this tutorial is for gesture detection it does involve creating a list of transform positions during runtime by adding them to a list then copying the component, stopping play then pasting component values
 - https://github.com/mjelbart/tests/blob/master/treeplanting/TransformSaver.cs
 - https://www.reddit.com/r/Unity3D/comments/8vkdlt/how_does_one_record_and_store_transform_data_at/
 - PlayerPrefs https://docs.unity3d.com/ScriptReference/PlayerPrefs.html / https://answers.unity.com/questions/136426/record-objects-position-in-play-mode.html
 - https://github.com/newyellow/Unity-Runtime-Animation-Recorder - this is for recording animations but perhaps it is helpful.
 
*/


// Ray to see if we hit something
RacastHit hitInfo;
bool hasHit = Physics.Raycast(objectLocation.position, objectLocation.forward, out hitInfo, 100);


//Bullethole script GRESTHOL https://forum.unity.com/threads/bullet-hole-script.186238/
using UnityEngine;
using System.Collections;
 
public class BulletHoleScript : MonoBehaviour {
 
    public float maxDist = 1000000000f;
    public GameObject decalHitWall;
    float floatInFrontOfWall = 0.00001f;
 
    void Update ()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDist))
        {
            if(decalHitWall && hit.transform.tag == "Level Parts")
            Instantiate(decalHitWall, hit.point + (hit.normal * floatInFrontOfWall), Quaternion.LookRotation(hit.normal));
        }
    }
}





public class EeroTheBotanyWizard : MonoBehaviour 
{

	public GameObject TreePrefab;
	
	public Transform RaycastStartPointTransform;
	
	public float MaxRange = 10000f;
	
	public float SpawnRate = 0.1f; // 10 per second
    float lastPlantTime;
	
	public LayerMask ValidLayers;

	public void PlantTree() 
	{
	
		float plantInterval = Time.timeScale < 1 ? 0.3f : SpawnRate;
		if (Time.time - lastPlantTime < shotInterval) 
    {
			return;
		}
			
		RaycastHit hit;
    if (Physics.Raycast(RaycastStartPointTransform.position, RaycastStartPointTransform.forward, out hit, MaxRange, ValidLayers, QueryTriggerInteraction.Ignore)) 
    {
      GameObject impact = Instantiate(TreePrefab, hit.point) as GameObject;
      //add something to do random rotation like GameObject.transform.rotation = new Vector3(currentRotation.x, Random.Range(0, 90f), currentRotation.z);
    }
}


		
