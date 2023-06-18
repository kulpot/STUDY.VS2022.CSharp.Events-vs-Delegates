using System;
using System.Runtime.CompilerServices;

//ref link:https://www.youtube.com/watch?v=NgrnCMaxIXM&list=PLAE7FECFFFCBE1A54&index=14
// An event has a two restriction on it:
// 1. you cant invoke the delegate reference directly,
// 2. you cant assign to it directly.

class TrainSignal
{       //      Events vs Delegates
    public Action TrainsAComing; // Delegate
    //public event Action TrainsAComing; // Event
    public void HereComesATrain()   
    {
        // there is a ton of logic here
        if(TrainsAComing != null) 
        TrainsAComing.Invoke();
    }
}

class Car
{
    public Car(TrainSignal trainSignal)
    {
        trainSignal.TrainsAComing += StopTheCar;
    }
    void StopTheCar()
    {
        Console.WriteLine("Screeeetch");
    }
}

class MainClass
{
    static void Main()
    {
        TrainSignal trainSignal = new TrainSignal();
        new Car(trainSignal);
        new Car(trainSignal);
        new Car(trainSignal);
        new Car(trainSignal);
        trainSignal.TrainsAComing();
        trainSignal.TrainsAComing();
        trainSignal.TrainsAComing();
        trainSignal.TrainsAComing();
        trainSignal.TrainsAComing = null;
        // Later on...
        trainSignal.HereComesATrain();
    }
}