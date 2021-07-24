using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmotivUnityPlugin;
using Zenject;

namespace dirox.emotiv.controller
{
    public class Testing : MonoBehaviour
    {
        private float pmData;

        DataStreamManager _dataStreamMgr = DataStreamManager.Instance;

        [SerializeField] private UIRadarChart uiRadarChart;

        public UIRadarChart UiRadarChart { get => uiRadarChart; set => uiRadarChart = value; }

        private float _eng = 0f;
        private float _str = 0f;
        private float _exc = 0f;
        private float _rel = 0f;
        private float _int = 0f;
        private float _foc = 0f;

        float _timerDataUpdate = 0;
        const float TIME_UPDATE_DATA = 1f;

        [SerializeField] private GameObject uiRadarchart;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            //_timerDataUpdate += Time.deltaTime;
            //if (_timerDataUpdate < TIME_UPDATE_DATA)
            //    return;


            // update pm data
            if (DataStreamManager.Instance.GetNumberPMSamples() > 0)
            {
                uiRadarchart.SetActive(true);
                foreach (var ele in DataStreamManager.Instance.GetPMLists())
                {
                    string chanStr = ele;
                    double data = DataStreamManager.Instance.GetPMData(ele);
                    if (chanStr == "TIMESTAMP" && (data == -1))
                    {
                        // has no new update of performance metric data
                        //hasPMUpdate = false;
                        break;
                    }
                    if (ele == "eng")
                    {
                        _eng = (float)data;
                    }
                    if (ele == "str")
                    {
                        _str = (float)data;
                    }
                    if (ele == "exc")
                    {
                        _exc = (float)data;
                    }
                    if (ele == "rel")
                    {
                        _rel = (float)data;
                    }
                    if (ele == "int")
                    {
                        _int = (float)data;
                    }
                    if (ele == "foc")
                    {
                        _foc = (float)data;
                    }
                    //pmData = (float)data;
                    //Debug.Log(data);
                }
            }

            //Set stats * PM of radar chart, 30 = 100%   
            Stats stats = new Stats(30f * _str, 30f * _exc, 30f * _int, 30f * _rel, 30f * _foc, 30f * _eng);
            uiRadarChart.SetStats(stats);


        }


    }
}