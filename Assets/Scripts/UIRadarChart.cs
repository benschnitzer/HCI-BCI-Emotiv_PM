using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRadarChart : MonoBehaviour
{
    [SerializeField] private Material radarMaterial;
    private Stats stats;
    [SerializeField]
    private CanvasRenderer radarMeshCanvasRenderer;

    public float stressValue;
    private float engagementValue;

    private void Awake()
    {
        //radarMeshCanvasRenderer = transform.Find("RadarMesh").GetComponent<CanvasRenderer>();
    }

    public void SetStats(Stats stats)
    {
        this.stats = stats;
        stats.OnStatsChanged += Stats_OnStatsChanged;
        UpdateStatsVisual();
    }

    private void Stats_OnStatsChanged(object sender, System.EventArgs e)
    {
        UpdateStatsVisual();
    }

    public void UpdateStatsVisual()
    {
        //transform.Find("Met_StressBar").localScale = new Vector3(1, stats.GetStatValueNormalized(Stats.Type.Stress));
        //transform.Find("Met_EngagementBar").localScale = new Vector3(1, stats.GetStatValueNormalized(Stats.Type.Engagement));
        stressValue = stats.GetStatValueNormalized(Stats.Type.Stress);

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[7];
        Vector2[] uv = new Vector2[7];
        int[] triangles = new int[3 * 6];

        float angleIncrement = 360f / 6;
        float radarChartSize = 420f;
        Vector3 stressVertex = Quaternion.Euler(0, 0, - angleIncrement * 0) * Vector3.up * radarChartSize * stats.GetStatValueNormalized(Stats.Type.Stress);
        int stressVertexIndex = 1;
        Vector3 excitementVertex = Quaternion.Euler(0, 0, - angleIncrement * 1) * Vector3.up * radarChartSize * stats.GetStatValueNormalized(Stats.Type.Excitement);
        int excitementVertexIndex = 2;
        Vector3 interestVertex = Quaternion.Euler(0, 0, - angleIncrement * 2) * Vector3.up * radarChartSize * stats.GetStatValueNormalized(Stats.Type.Interest);
        int interestVertexIndex = 3;
        Vector3 relaxationVertex = Quaternion.Euler(0, 0, -angleIncrement * 3) * Vector3.up * radarChartSize * stats.GetStatValueNormalized(Stats.Type.Relaxation);
        int relaxationVertexIndex = 4;
        Vector3 focusVertex = Quaternion.Euler(0, 0, -angleIncrement * 4) * Vector3.up * radarChartSize * stats.GetStatValueNormalized(Stats.Type.Focus);
        int focusVertexIndex = 5;
        Vector3 engagementVertex = Quaternion.Euler(0, 0, -angleIncrement * 5) * Vector3.up * radarChartSize * stats.GetStatValueNormalized(Stats.Type.Engagement);
        int engagementVertexIndex = 6;

        vertices[0] = Vector3.zero;
        vertices[stressVertexIndex] = stressVertex;
        vertices[excitementVertexIndex] = excitementVertex;
        vertices[interestVertexIndex] = interestVertex;
        vertices[relaxationVertexIndex] = relaxationVertex;
        vertices[focusVertexIndex] = focusVertex;
        vertices[engagementVertexIndex] = engagementVertex;

        triangles[0] = 0;
        triangles[1] = stressVertexIndex;
        triangles[2] = excitementVertexIndex;

        triangles[3] = 0;
        triangles[4] = excitementVertexIndex;
        triangles[5] = interestVertexIndex;

        triangles[6] = 0;
        triangles[7] = interestVertexIndex;
        triangles[8] = relaxationVertexIndex;

        triangles[9] = 0;
        triangles[10] = relaxationVertexIndex;
        triangles[11] = focusVertexIndex;

        triangles[12] = 0;
        triangles[13] = focusVertexIndex;
        triangles[14] = engagementVertexIndex;

        triangles[15] = 0;
        triangles[16] = engagementVertexIndex;
        triangles[17] = stressVertexIndex;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        radarMeshCanvasRenderer.SetMesh(mesh);
        radarMeshCanvasRenderer.SetMaterial(radarMaterial, null);
     }

    public void IncreaseStressButton()
    {
        stats.IncreaseStatValue(Stats.Type.Stress);
    }

    public void DecreaseStressButton()
    {
        stats.DecreaseStatValue(Stats.Type.Stress);
    }

    public void IncreaseEngagementButton()
    {
        stats.IncreaseStatValue(Stats.Type.Engagement);
    }

    public void DecreaseEngagementButton()
    {
        stats.DecreaseStatValue(Stats.Type.Engagement);
    }



}
