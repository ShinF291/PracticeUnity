using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TypedMessageBroker;

namespace MamoriOfChikyu.Meteo
{
    public interface IMeteoMessage
    {
    }

    public class MeteoMessageBroker : TypedMessageBroker<IMeteoMessage>
    {
    }
}
