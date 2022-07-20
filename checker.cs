using System;
using System.Diagnostics;


class Checker
{ 

    public static bool rangeCheck(float min,float max, float target,string errorMsg)
    {
        if((min > target)&&(max<= target))
        {
            Console.WriteLine("{0} is out of range", errorMsg);
            return false;
        }
        else
        {
            return true;
        }
    }

    public static void Expect(bool Expectation)
    {
        Console.WriteLine("Expected {0}, but got {1}", !Expectation, Expectation);
    }

    static bool batteryIsOk(float temperature, float soc, float chargeRate,Func<float, float, float, string, bool> range) 
    {
        return range(0, 45,temperature,"Temperature") &&
               range(20, 80, soc, "State of Charge") &&
               range(0, 0.8f, chargeRate, "Charge Rate");
    }

    static int Main() {
        Func<float, float, float, string, bool> range = rangeCheck;
        Expect(batteryIsOk(25, 70, 0.7f,range));
        Expect(batteryIsOk(50, 85, 0.0f,range));
        Console.WriteLine("All ok");
        return 0;
    }
}