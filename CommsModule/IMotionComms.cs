using System;

namespace CommsModule.Interfaces
{
    interface IMotionComms
    {
        bool startComms();
        bool stopComms();
        bool sendData(Object obj);
        event EventHandler OndataReceived; 
                
    }
}
