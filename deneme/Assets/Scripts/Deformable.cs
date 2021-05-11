using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deformable : MonoBehaviour
{

    /* Deforms this mesh
   point: The point from which deformation of the mesh starts .Deforme olmaya başladığı nokta
   radius: The maximum radius to which the deformation affects .Deforme olacak alanın çapı
   stepRadius: The small step value of the maximum radius
   strength: The maximum strength of the deformation
   stepStrength: The small step value of the maximum strength
   direction: The direction of the deformation relative to mesh
*/
    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.gameObject.tag == "DeformableMesh")
        {
            MeshDeformer meshDeformer = collision.transform.GetComponent<MeshDeformer>();
            ContactPoint[] contactPoints = new ContactPoint[collision.contactCount];
            collision.GetContacts(contactPoints);
           
            foreach (ContactPoint contactPoint in contactPoints)
            {
                meshDeformer.Deform(contactPoint.point, 0.5f, 0.1f, -0.5f, -0.05f, Vector3.up);
                
            }
        }
    }

}
