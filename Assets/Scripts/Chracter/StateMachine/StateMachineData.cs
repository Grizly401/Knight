using System;

public class StateMachineData
{
    public float XVelocity;
    public float YVelocity;

    private float _speed;
    private float _xInput;
    private float _yInput;

    public float XIput
    {
        get => _xInput;
        set
        {
            if (value < -1|| value >1)
                throw new ArgumentOutOfRangeException(nameof(_xInput));

            _xInput = value;
        }
    }

    public float YIput
    {
        get => _yInput;
        set
        {
            if (value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(_yInput));

            _yInput = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(_speed));

            _speed = value;
        }
    }
}
