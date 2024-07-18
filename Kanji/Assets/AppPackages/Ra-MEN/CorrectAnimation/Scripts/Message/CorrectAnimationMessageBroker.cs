using TypedMessageBroker;

namespace RaMen.CorrectAnimation
{
    public interface ICorrectAnimationMessage
    {
    }

    public class CorrectAnimationMessageBroker : TypedMessageBroker<ICorrectAnimationMessage>
    {
    }
}