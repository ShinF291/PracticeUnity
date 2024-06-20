// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace TypedMessageBroker.Examples
// {
//     // var broker1 = new TypedMessageBroker<IMessageType1>();
//     // var broker2 = new TypedMessageBroker<IMessageType2>();

//     public interface IMessageType1
//     {
//     }

//     public interface IMessageType2
//     {
//     }

//     public class hogehogeMessageBroker : TypedMessageBroker<IMessageType1>
//     {

//     }

//     public class hogehogeRequest : IMessageType1
//     {

//     }

//     public class gameMessageBroker : TypedMessageBroker<IMessageType2>
//     {

//     }

//     public class gameStartMessageBroker : TypedMessageBroker<IMessageType2>
//     {

//     }

//     public class gameStartRequest : IMessageType2
//     {

//     }

//     public class countDownStartRequest : IMessageType2
//     {

//     }
//     public class startCountOverRequest : IMessageType2
//     {

//     }

//     public class gameEndMessageBroker : TypedMessageBroker<IMessageType2>
//     {

//     }

//     public class gameEndRequest : IMessageType2
//     {

//     }

//     public class gameEndResponse : IMessageType2
//     {

//     }

//     public class timeOverRequest : IMessageType2
//     {

//     }

//     public class setUFOScore : IMessageType2
//     {

//     }


//     public class hogehogeRequest2 : IMessageType1
//     {
        
//     }

//     public class Message1Hoge : IMessageType1
//     {
//         public Message1Hoge(int value)
//         {
//             Value = value;
//         }

//         public int Value { get; }
//     }

//     public class Message1Fuga : IMessageType1
//     {
//         public Message1Fuga(int value)
//         {
//             Value = value;
//         }

//         public int Value { get; }
//     }

//     public class Message2Hoge : IMessageType2
//     {
//         public Message2Hoge(int value)
//         {
//             Value = value;
//         }

//         public int Value { get; }
//     }

//     public class Message2Fuga : IMessageType2
//     {
//         public Message2Fuga(int value)
//         {
//             Value = value;
//         }

//         public int Value { get; }
//     }
// }
