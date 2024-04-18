using UnityEngine;

public class BuffRangeTower : MonoBehaviour
{
    //[SerializeField] private Color lineColor = Color.red;
    //[SerializeField] private SphereCollider towerCollider;

    //private LineRenderer lineRenderer;

    //private void Start()
    //{
    //    if (towerCollider != null)
    //    {
    //        lineRenderer = gameObject.AddComponent<LineRenderer>();
    //        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
    //        lineRenderer.startColor = lineColor;
    //        lineRenderer.endColor = lineColor;
    //        lineRenderer.startWidth = 0.1f;
    //        lineRenderer.endWidth = 0.1f;
    //        lineRenderer.positionCount = 360;
    //        lineRenderer.useWorldSpace = false;

    //        float radius = towerCollider.radius * transform.lossyScale.x;
    //        Vector3[] positions = new Vector3[360];

    //        for (int i = 0; i < 360; i++)
    //        {
    //            float angle = i * 10 * Mathf.Deg2Rad;
    //            positions[i] = new Vector3(Mathf.Cos(angle) * radius, 0.01f, Mathf.Sin(angle) * radius);
    //        }

    //        lineRenderer.SetPositions(positions);
    //    }
    //}

    public Color particleColor = Color.red; 
    public SphereCollider towerCollider;
    public GameObject particlePrefab; 

    private ParticleSystem[] particles; 

    private void Start()
    {
        if (towerCollider != null && particlePrefab != null)
        {            
            float radius = towerCollider.radius * transform.lossyScale.x;
            
            particles = new ParticleSystem[36];
            
            for (int i = 0; i < 36; i++)
            {
                float angle = i * 10;
                Vector3 position = transform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, 0.01f, Mathf.Sin(angle * Mathf.Deg2Rad) * radius);
                                
                GameObject particleObject = Instantiate(particlePrefab, position, Quaternion.identity);
                ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();

                if (particleSystem != null)
                {
                    ParticleSystem.MainModule main = particleSystem.main;
                    main.startColor = particleColor;
                    particles[i] = particleSystem;
                }                
            }
        }        
    }

    private void Update()
    {        
        if (particles != null)
        {
            for (int i = 0; i < particles.Length; i++)
            {
                if (particles[i] != null)
                {
                    float angle = i * 10;
                    float radius = towerCollider.radius * transform.lossyScale.x;
                    Vector3 position = transform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, 0.01f, Mathf.Sin(angle * Mathf.Deg2Rad) * radius);
                    particles[i].transform.position = position;
                }
            }
        }
    }
}