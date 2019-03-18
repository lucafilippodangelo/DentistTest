using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.BehavioralPatterns.CreationalPatterns
{

    public sealed class SingletonAptEvent
    {
        public static void Main(string[] args) { }

        private static Dictionary<int, string> _instance = null;

        private static object syncLock = new object();//LD Lock synchronization object


        private SingletonAptEvent() //LD The private constructor will make sure that the class can't be instantiated from outside.
        {
            _instance = new Dictionary<int, string>()
                {
                    { 1, "mailSendingAttempt"},
                    { 2, "calcel"},
                    { 3, "callMeBack"},
                    { 4, "canceled"},
                    { 5, "confirm"}
                };
        }

        /* //LD
         * property which will return the static instance of the object present within the class itself. 
         * Hence the object will be shared between all the external entities.
         */
        public static Dictionary<int, string> Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            new SingletonAptEvent();
                        }
                    }
                }
                return _instance;
            }
        }

    }

}