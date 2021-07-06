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

        private float _eng = 1f;
        private float _str = 1f;
        private float _exc = 1f;
        private float _rel = 1f;
        private float _int = 1f;
        private float _foc = 1f;

        float _timerDataUpdate = 0;
        const float TIME_UPDATE_DATA = 1f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            _timerDataUpdate += Time.deltaTime;
            if (_timerDataUpdate < TIME_UPDATE_DATA)
                return;

            _timerDataUpdate -= TIME_UPDATE_DATA;



            // update pm data
            if (DataStreamManager.Instance.GetNumberPMSamples() > 0)
            {

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

                //}

                //if((float)_dataStreamMgr.GetPMData("eng") != -1)
                //{
                //    _eng = (float)_dataStreamMgr.GetPMData("eng");
                //}
                //if ((float)_dataStreamMgr.GetPMData("str") != -1)
                //{
                //    _str = (float)_dataStreamMgr.GetPMData("str");
                //}
                //if ((float)_dataStreamMgr.GetPMData("exc") != -1)
                //{
                //    _exc = (float)_dataStreamMgr.GetPMData("exc");
                //}
                //if ((float)_dataStreamMgr.GetPMData("rel") != -1)
                //{
                //    _rel = (float)_dataStreamMgr.GetPMData("rel");
                //}
                //if ((float)_dataStreamMgr.GetPMData("int") != -1)
                //{
                //    _int = (float)_dataStreamMgr.GetPMData("int");
                //}
                //if ((float)_dataStreamMgr.GetPMData("foc") != -1)
                //{
                //    _foc = (float)_dataStreamMgr.GetPMData("foc");
                //}

                Stats stats = new Stats(30f * _str, 30f * _exc, 30f * _int, 30f * _rel, 30f * _foc, 30f * _eng);
                uiRadarChart.SetStats(stats);

                Debug.Log(_str);

            //_eng = (float)_dataStreamMgr.GetPMData("eng");
            //_str = (float)_dataStreamMgr.GetPMData("str");
            //_exc = (float)_dataStreamMgr.GetPMData("exc");
            //_rel = (float)_dataStreamMgr.GetPMData("rel");
            //_int = (float)_dataStreamMgr.GetPMData("int");
            //_foc = (float)_dataStreamMgr.GetPMData("foc");



        }


    }
}