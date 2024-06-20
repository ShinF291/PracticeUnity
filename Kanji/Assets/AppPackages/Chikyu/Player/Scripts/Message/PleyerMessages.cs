using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MamoriOfChikyu.Player
{
    public class PlayerMoveUp : IPlayerMessage
    {
    }
    public class PlayerMoveDown : IPlayerMessage
    {
    }
    public class PlayerMoveLeft : IPlayerMessage
    {
    }
    public class PlayerMoveRight : IPlayerMessage
    {
    }
    
    public class PlayerMoveBeginRequest : IPlayerMessage
    {
    }

    public class PlayerMoveForbiddenRequest : IPlayerMessage
    {
    }
}
