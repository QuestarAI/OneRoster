namespace Questar.OneRoster.Transforms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var provider = (ITransformProvider) new TransformProvider();
            var transform = provider.GetTransform(typeof(object));
        }
    }
}