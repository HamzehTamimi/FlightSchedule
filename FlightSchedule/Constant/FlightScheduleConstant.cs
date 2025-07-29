namespace FlightSchedule.Constant;

public class FlightScheduleConstant
{




    public enum FlightStatus
    {
        OnTime = 1,
        Delayed = 2,
        Cancelled = 3,
        Departed = 4,
        Arrived = 5,
        Boarding = 6,
        GateClosed = 7,
        Diverted = 8,
        InAir = 9,
        Scheduled = 10,
        Unknown = 11,
        ReturnedToGate = 12,
        FinalCall = 13
    }

}