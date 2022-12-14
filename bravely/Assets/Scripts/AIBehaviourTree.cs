using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


// data   : 2022/11/09
// writer : 범지원

namespace AI
{
    [System.Serializable] public class BehaviourTree
    {
        #region private-field
        private List<Sequence> sequenceList;
        #endregion

        /**********************************************************
        *                constructor, deconstructor
        **********************************************************/
        #region
        public BehaviourTree() { }
        ~BehaviourTree() { }
        #endregion

        /**********************************************************
        *                          event
        **********************************************************/
        #region
        public void Update()
        {
            foreach (var sequnce in sequenceList)
            {
                sequnce.Update();
            }
        }
        #endregion

        /**********************************************************
        *                         utility
        **********************************************************/
        #region

        /// <summary> 루트에 자식 시퀀스로 추가
        public void AddSequnce(in Sequence sequence_)
        {
            sequenceList.Add(sequence_);
        }

        /// <summary> 특정 시퀀스에 자식 시퀀스로 추가
        public void AddSequence(in Sequence sequence_, in string name_)
        {
            foreach (var sequence in sequenceList)
            {
                sequence.AddSequence(sequence_, name_);
            }
        }

        /// <summary> 특정 시퀀스에 행동 추가
        public void AddTask(in Task task_, in string name_)
        {
            foreach (var sequence in sequenceList)
            {
                sequence.AddTask(task_, name_);
            }
        }

        public Sequence FindSequenceAtName(in string name_)
        {
            Sequence result;

            foreach (var sequence in sequenceList)
            {
                result = sequence.FindSequenceAtName(name_);
                if (result != null) { return result; }
            }

            return null;
        }
        #endregion
    }
    
    public class Sequence
    {
        #region private-field
        private List<Task> taskList;
        private List<Sequence> sequenceList;
        private string name;
        #endregion

        #region property
        public string Name { get; set; }
        #endregion

        public Sequence(string name_)
        {
            taskList = new List<Task>();
            sequenceList = new List<Sequence>();
            name = name_;
        }

        /**********************************************************
        *                          event
        **********************************************************/
        #region
        public void Update()
        {
            foreach (var task in taskList)
            {
                task.Update();
            }

            foreach (var sequnce in sequenceList)
            {
                sequnce.Update();
            }
        }
        #endregion

        /**********************************************************
        *                         utility
        **********************************************************/
        #region
        public Sequence FindSequenceAtName(in string name_)
        {
            if (name == name_)
            {
                return this;
            }

            foreach (var sequence in sequenceList)
            {
                sequence.FindSequenceAtName(name_);
            }

            return null;
        }

        public void AddSequence(in Sequence sequence_, in string name_)
        {
            foreach (var sequence in sequenceList)
            {
                
            }
        }

        public void AddTask(in Task task_, in string name_)
        {
        }
        #endregion
    }

    abstract public class Task
    {
        /**********************************************************
        *                          event
        **********************************************************/
        #region
        public void Update()
        {
            if (onEvent()) { work(); }
        }
        #endregion

        /**********************************************************
        *                     abstract method
        **********************************************************/
        #region
        /// <summary> work() 발동 조건 정의 추상함수
        abstract protected bool onEvent();
        /// <summary> Task의 작업 정의 추상함수
        abstract protected void work();
        #endregion
    }
}