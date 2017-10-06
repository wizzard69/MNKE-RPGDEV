using System.Collections;
using System.Collections.Generic;

public class PlayerNodePosition
{
    static PlayerNodePosition instance;

    public static PlayerNodePosition Instance()
    {
        if (instance == null)
        {
            instance = new PlayerNodePosition();
        }

        return instance;
    }

    public Node playerNode { get; set; }
}