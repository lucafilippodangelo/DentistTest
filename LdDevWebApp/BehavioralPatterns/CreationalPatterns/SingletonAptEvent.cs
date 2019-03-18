using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdDevWebApp.BehavioralPatterns.CreationalPatterns
{

    public sealed class SingletonAptEvent
    {
        //public static void Main(string[] args) { }

        private static Dictionary<string, int> _instance = null;

        private static object syncLock = new object();//LD Lock synchronization object


        private SingletonAptEvent() //LD The private constructor will make sure that the class can't be instantiated from outside.
        {
            _instance = new Dictionary<string,int>()
                {
                    //LD user events
                    {"cancel",3},
                    {"callMeBack",4},
                    {"confirm",5},
                    //LD system automatic events
                    {"mailSendError",1},
                    {"mailSent",2},
                    //LD administration manual events
                    {"callMeBackToCanceled",7},
                    {"callMeBackToConfirmed",8}, 
                    {"initialToAborted",9} 
                };
        }

        /* //LD
         * property which will return the static instance of the object present within the class itself. 
         * Hence the object will be shared between all the external entities.
         */
        public static Dictionary<string, int> Instance
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