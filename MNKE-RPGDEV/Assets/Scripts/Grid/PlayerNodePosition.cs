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

    public int playerXCoord { get; set; }

    public int playerYCoord { get; set; }

    public Node playerNode { get; set; }
}