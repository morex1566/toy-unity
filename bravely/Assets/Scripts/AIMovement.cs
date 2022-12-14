using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AIMovement : MonoBehaviour
    {
        #region private-field
        [SerializeField] private AI.BehaviourTree bt;
        #endregion

        /**********************************************************
         *                          event
         **********************************************************/
        #region
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        /**********************************************************
         *                      private method
         **********************************************************/
        #region
        private void initBT()
        {
            bt = new AI.BehaviourTree();

            
        }
        #endregion
    }

    //private AI.BehaviourTree tree;
    //private DetecterAI detecter;
    //private ScouterAI scouter;
    //private NavMeshAgent agent;

    //void Start()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //    detecter = GetComponentInChildren<DetecterAI>();
    //    scouter = GetComponentInChildren<ScouterAI>();
    //}

    //void Update()
    //{
    //    if (detecter.DetectedObject) { agent.destination = detecter.DetectedObject.transform.position; }
    //    if (scouter.ScoutedObject) {

    //        Quaternion from = transform.rotation;
    //        Quaternion to = Quaternion.LookRotation(scouter.ScoutedObject.transform.position);

    //        transform.rotation = Quaternion.Lerp(from, to, 1.0f * Time.deltaTime);
    //    }
    //}
}