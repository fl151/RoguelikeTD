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

    public Color particleColor = Color.red; // Цвет частиц
    public SphereCollider towerCollider; // Ссылка на Sphere Collider башни
    public GameObject particlePrefab; // Префаб частиц

    private ParticleSystem[] particles; // Массив компонентов ParticleSystem

    private void Start()
    {
        if (towerCollider != null && particlePrefab != null)
        {
            // Рассчитываем радиус для частиц на основе размера коллайдера башни
            float radius = towerCollider.radius * transform.lossyScale.x;

            // Создаем массив для хранения компонентов ParticleSystem
            particles = new ParticleSystem[36];

            // Создаем частицы вокруг башни
            for (int i = 0; i < 36; i++)
            {
                float angle = i * 10;
                Vector3 position = transform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * radius, 0.01f, Mathf.Sin(angle * Mathf.Deg2Rad) * radius);

                // Создаем экземпляр частиц
                GameObject particleObject = Instantiate(particlePrefab, position, Quaternion.identity);
                ParticleSystem particleSystem = particleObject.GetComponent<ParticleSystem>();

                // Настраиваем параметры частиц
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
        // Обновляем положение частиц вокруг башни в соответствии с ее позицией
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