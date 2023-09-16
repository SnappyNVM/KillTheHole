using Unity.VisualScripting;
using UnityEngine;

public class MoleAttacker : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left)) Attack();
    }

    private void Attack()
    {
        var target = GetMoleOnMousePosition();
        if (target == null)
            return;
        target.TakeDamage();
    }

    private Mole GetMoleOnMousePosition()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo);
        if (hitInfo.rigidbody == null) return null;
        return hitInfo.rigidbody.gameObject.GetComponent<Mole>();
    }
}
