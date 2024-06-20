using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace MamoriOfChikyu.Stage1Create
{
    public interface IStage1CreateMessage
    {
    }

    public class Stage1CreateMessageBroker : TypedMessageBroker<IStage1CreateMessage>
    {

    }

}


